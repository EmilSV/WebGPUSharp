using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Marshalling;

[StructLayout(LayoutKind.Auto)]
public unsafe struct WebGpuAllocatorLogicBlock
{
    [StructLayout(LayoutKind.Explicit)]
    private struct DisposableHandleArrayItem
    {
        [FieldOffset(0)]
        public (nuint size, nuint count) SizeInfo;
        [FieldOffset(0)]
        public DisposableHandle DisposableHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct StackModeData
    {
        public required byte* Memory;
        public required uint RemainingBytes;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct HeapModeData
    {
        public required void** AllocPtr;
        public required ushort Size;
        public required ushort Count;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct ModeData
    {
        [FieldOffset(0)]
        public StackModeData Stack;
        [FieldOffset(0)]
        public HeapModeData Heap;
    }

    private WebGpuAllocator* _allocator;
    private ModeData _data;
    private bool _isInStackMode;
    private DisposableHandleArrayItem* _disposableHandles;

    internal void SetupStackMemory(
        WebGpuAllocator* allocator,
        byte* memory,
        uint remainingBytes)
    {
        _allocator = allocator;
        _disposableHandles = null;
        _data.Stack = new()
        {
            Memory = memory,
            RemainingBytes = remainingBytes,
        };
        _isInStackMode = true;
    }

    internal void SetupHeapMemory(WebGpuAllocator* allocator)
    {
        _disposableHandles = null;
        _data.Heap = new()
        {
            AllocPtr = (void**)_allocator->AlignedAlloc((nuint)sizeof(void*) * 4, WebGpuAlignment.GetAlignmentOf<nuint>()),
            Size = 4,
            Count = 0,
        };
        _isInStackMode = false;
    }

    internal void SwitchToHeapMemory()
    {
        _data.Heap = new()
        {
            AllocPtr = (void**)_allocator->AlignedAlloc((nuint)sizeof(void*) * 4, WebGpuAlignment.GetAlignmentOf<nuint>()),
            Size = 4,
            Count = 0,
        };
        _isInStackMode = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T* AllocStack<T>(nuint amount)
        where T : unmanaged
    {
        nuint byteAmount = amount * (nuint)sizeof(T);
        void* alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<T>(), _data.Stack.RemainingBytes, _data.Stack.Memory, out nuint remainingSize);
        if (alignedMemory == null || remainingSize < byteAmount)
        {
            SwitchToHeapMemory();
            return AllocHeap<T>(amount);
        }

        _data.Stack.Memory = (byte*)((nuint)alignedMemory + byteAmount);
        _data.Stack.RemainingBytes = (uint)(remainingSize - byteAmount);
        return (T*)alignedMemory;
    }

    private T* ReallocStack<T>(T* previousMemory, nuint previousSize, nuint newSize)
        where T : unmanaged
    {
        if (newSize == previousSize)
        {
            return (T*)_data.Stack.Memory;
        }

        var previousSizeInBytes = previousSize * (nuint)sizeof(T);

        if ((nuint)_data.Stack.Memory - previousSizeInBytes == (nuint)previousMemory)
        {
            var newSizeInBytes = (nuint)sizeof(T) * newSize;
            var differenceInBytes = newSizeInBytes - previousSizeInBytes;
            if (differenceInBytes <= _data.Stack.RemainingBytes)
            {
                _data.Stack.Memory = (byte*)((nuint)previousMemory + newSizeInBytes);
                _data.Stack.RemainingBytes -= (uint)differenceInBytes;
                return previousMemory;
            }
        }

        var newMemory = AllocStack<T>(newSize);
        Unsafe.CopyBlockUnaligned(newMemory, previousMemory, (uint)previousSize);
        return newMemory;
    }

    private T* AllocHeap<T>(nuint amount)
        where T : unmanaged
    {
        var newMemory = _allocator->AlignedAlloc((nuint)sizeof(T) * amount, WebGpuAlignment.GetAlignmentOf<T>());
        if (newMemory == null)
        {
            throw new OutOfMemoryException("Failed to allocate memory for WebGpuAllocatorHandle.");
        }

        if (_data.Heap.Size <= _data.Heap.Count)
        {
            var newSize = _data.Heap.Size * 2;
            _data.Heap.AllocPtr = (void**)_allocator->AlignedRealloc(
                _data.Heap.AllocPtr,
                (nuint)(newSize * sizeof(void**)),
                WebGpuAlignment.GetAlignmentOf<nuint>()
            );
            _data.Heap.Size = (ushort)newSize;
        }
        _data.Heap.AllocPtr[_data.Heap.Count] = newMemory;
        _data.Heap.Count++;

        return (T*)newMemory;
    }

    private T* ReallocHeap<T>(T* previousMemory, nuint previousSize, nuint newSize)
        where T : unmanaged
    {
        if (newSize == previousSize)
        {
            return previousMemory;
        }

        for (int i = 0; i < _data.Heap.Count; i++)
        {
            if (_data.Heap.AllocPtr[i] == previousMemory)
            {
                _data.Heap.AllocPtr[i] = _allocator->AlignedRealloc(previousMemory, (nuint)sizeof(T) * newSize, WebGpuAlignment.GetAlignmentOf<T>());
                return (T*)_data.Heap.AllocPtr[i];
            }
        }

        throw new InvalidOperationException("Previous memory not found in heap allocation.");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T* Alloc<T>(nuint amount)
        where T : unmanaged
    {
        if (_isInStackMode)
        {
            return AllocStack<T>(amount);
        }
        else
        {
            return AllocHeap<T>(amount);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T* Realloc<T>(T* previousMemory, nuint previousSize, nuint newSize)
        where T : unmanaged
    {
        Debug.Assert(previousMemory != null, "Previous memory cannot be null when reallocating.");
        Debug.Assert(previousSize > 0, "Previous size must be greater than zero when reallocating.");
        Debug.Assert(newSize > 0, "New size must be greater than zero when reallocating.");
        Debug.Assert(newSize >= previousSize, "New size must be greater than or equal to previous size when reallocating.");

        if (_isInStackMode)
        {
            return ReallocStack(previousMemory, previousSize, newSize);
        }
        else
        {
            return ReallocHeap(previousMemory, previousSize, newSize);
        }
    }

    internal void AddDisposableHandle(DisposableHandle newDisposableHandle)
    {
        if (_disposableHandles == null)
        {
            _disposableHandles = (DisposableHandleArrayItem*)_allocator->AlignedAlloc(
                byteCount: (nuint)sizeof(DisposableHandleArrayItem) * 4,
                alignment: WebGpuAlignment.GetAlignmentOf<DisposableHandleArrayItem>()
            );
            _disposableHandles[0].SizeInfo = (4, 1);
        }

        var index = _disposableHandles->SizeInfo.count++;
        if (_disposableHandles->SizeInfo.size <= index)
        {
            var newSize = _disposableHandles->SizeInfo.size * 2;
            _disposableHandles = (DisposableHandleArrayItem*)_allocator->AlignedRealloc(
              ptr: _disposableHandles,
              byteCount: newSize * (nuint)sizeof(DisposableHandleArrayItem),
              alignment: WebGpuAlignment.GetAlignmentOf<DisposableHandleArrayItem>()
            );
            _disposableHandles->SizeInfo.size = newSize;
        }
    }

    internal void Dispose()
    {
        if (_disposableHandles != null)
        {
            var count = _disposableHandles[0].SizeInfo.count;
            for (nuint i = 1; i < count; i++)
            {
                _disposableHandles[i].DisposableHandle.Dispose();
            }
            _allocator->AlignedFree(_disposableHandles);
        }

        if (!_isInStackMode)
        {
            for (int i = 0; i < _data.Heap.Count; i++)
            {
                _allocator->AlignedFree(_data.Heap.AllocPtr[i]);
            }
            _allocator->AlignedFree(_data.Heap.AllocPtr);
        }
    }
}