using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp.Marshalling;

public readonly unsafe ref struct WebGpuAllocatorHandle
    : IDisposable
{
    [StructLayout(LayoutKind.Explicit)]
    private struct DisposableHandleArrayItem
    {
        [FieldOffset(0)]
        public (nuint size, nuint count) SizeInfo;
        [FieldOffset(0)]
        public DisposableHandle DisposableHandle;
    }

    [StructLayout(LayoutKind.Auto)]
    private struct LogicBlock
    {
        public unsafe struct StackModeData
        {
            public byte* Memory;
            public nuint RemainingBytes;
        }

        public unsafe struct HeapModeData
        {
            public void** AllocPtr;
            public int Size;
            public int Count;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ModeData
        {
            [FieldOffset(0)]
            public StackModeData Stack;
            [FieldOffset(0)]
            public HeapModeData Heap;
        }

        public WebGpuAllocator* Allocator;
        public ModeData Data;
        public DisposableHandleArrayItem* DisposableHandles;
        public bool IsInStackMode { get; private set; }
        public bool IsLogicBlockHeapAllocated { get; private set; }

        public void SetupStackMemory(
            WebGpuAllocator* allocator,
            void* memory,
            nuint remainingBytes)
        {
            IsInStackMode = true;
            IsLogicBlockHeapAllocated = false;
            Allocator = allocator;
            DisposableHandles = null;
            Data.Stack.Memory = (byte*)memory;
            Data.Stack.RemainingBytes = remainingBytes;
        }

        public void SetupHeapMemory(WebGpuAllocator* allocator)
        {
            IsInStackMode = false;
            IsLogicBlockHeapAllocated = true;
            DisposableHandles = null;
            Data.Heap.AllocPtr = (void**)Allocator->Alloc((nuint)sizeof(void*) * 4);
            Data.Heap.Size = 4;
            Data.Heap.Count = 0;
        }

        private void SwitchToHeapMemory()
        {
            IsInStackMode = false;
            Data.Heap.AllocPtr = (void**)Allocator->Alloc((nuint)sizeof(void*) * 4);
            Data.Heap.Size = 4;
            Data.Heap.Count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T* AllocStack<T>(nuint amount)
            where T : unmanaged
        {
            nuint byteAmount = amount * (nuint)sizeof(T);
            void* alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<T>(), amount, Data.Stack.Memory, out nuint remainingSize);
            if (alignedMemory == null || remainingSize < byteAmount)
            {
                SwitchToHeapMemory();
                return AllocHeap<T>(amount);
            }

            Data.Stack.Memory = (byte*)((nuint)alignedMemory + byteAmount);
            Data.Stack.RemainingBytes = remainingSize - byteAmount;
            return (T*)alignedMemory;
        }

        private T* ReallocStack<T>(T* previousMemory, nuint previousSize, nuint newSize)
            where T : unmanaged
        {
            if (newSize == previousSize)
            {
                return (T*)Data.Stack.Memory;
            }

            if ((nuint)Data.Stack.Memory - previousSize == (nuint)previousMemory)
            {
                var newAllocSize = (nuint)sizeof(T) * newSize;
                if (newAllocSize <= Data.Stack.RemainingBytes)
                {
                    Data.Stack.Memory = (byte*)((nuint)previousMemory + newSize);
                    Data.Stack.RemainingBytes -= newAllocSize;
                    return (T*)Data.Stack.Memory;
                }
            }

            var newMemory = AllocStack<T>(newSize);
            Unsafe.CopyBlockUnaligned(newMemory, Data.Stack.Memory, (uint)previousSize);
            return newMemory;
        }

        private T* AllocHeap<T>(nuint amount)
            where T : unmanaged
        {
            var newMemory = Allocator->AlignedAlloc((nuint)sizeof(T) * amount, WebGpuAlignment.GetAlignmentOf<T>());
            if (newMemory == null)
            {
                throw new OutOfMemoryException("Failed to allocate memory for WebGpuAllocatorHandle.");
            }

            if (Data.Heap.Size <= Data.Heap.Count)
            {
                var newSize = Data.Heap.Size * 2;
                Data.Heap.AllocPtr = (void**)Allocator->Realloc(Data.Heap.AllocPtr, (nuint)(newSize * sizeof(void**)));
                Data.Heap.Size = newSize;
                Data.Heap.AllocPtr[Data.Heap.Count] = newMemory;
                Data.Heap.Count++;
            }

            return (T*)newMemory;
        }

        private T* ReallocHeap<T>(T* previousMemory, nuint previousSize, nuint newSize)
            where T : unmanaged
        {
            if (newSize == previousSize)
            {
                return previousMemory;
            }

            for (int i = 0; i < Data.Heap.Count; i++)
            {
                if (Data.Heap.AllocPtr[i] == previousMemory)
                {
                    Data.Heap.AllocPtr[i] = Allocator->Realloc(previousMemory, (nuint)sizeof(T) * newSize);
                    return (T*)Data.Heap.AllocPtr[i];
                }
            }

            throw new InvalidOperationException("Previous memory not found in heap allocation.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T* Alloc<T>(nuint amount)
            where T : unmanaged
        {
            if (IsInStackMode)
            {
                return AllocStack<T>(amount);
            }
            else
            {
                return AllocHeap<T>(amount);
            }
        }

        public T* Realloc<T>(T* previousMemory, nuint previousSize, nuint newSize)
            where T : unmanaged
        {
            if (IsInStackMode)
            {
                return ReallocStack(previousMemory, previousSize, newSize);
            }
            else
            {
                return ReallocHeap(previousMemory, previousSize, newSize);
            }
        }

        public void Dispose()
        {
            if (DisposableHandles != null)
            {
                for (nuint i = 1; i < DisposableHandles[0].SizeInfo.count; i++)
                {
                    DisposableHandles[i].DisposableHandle.Dispose();
                }
                Allocator->Free(DisposableHandles);
            }

            if (!IsInStackMode)
            {
                for (int i = 0; i < Data.Heap.Count; i++)
                {
                    Allocator->Free(Data.Heap.AllocPtr[i]);
                }
                Allocator->Free(Data.Heap.AllocPtr);
            }
        }
    }
    private readonly LogicBlock* _logicBlockPtr;
    private readonly ref LogicBlock _logicBlock => ref *_logicBlockPtr;

    internal WebGpuAllocatorHandle(WebGpuAllocator* allocator, void* stackMemory, nuint size)
    {
        if (stackMemory == null && size == 0)
        {
            _logicBlockPtr = (LogicBlock*)allocator->Alloc((nuint)sizeof(LogicBlock));
            _logicBlock.SetupHeapMemory(allocator);
            return;
        }

        var alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<LogicBlock>(), size, stackMemory, out nuint remainingSize);
        if (alignedMemory == null)
        {
            throw new OutOfMemoryException("Failed to allocate aligned memory for WebGpuAllocatorHandle.");
        }
        _logicBlockPtr = (LogicBlock*)alignedMemory;

        _logicBlock.SetupStackMemory(
            allocator: allocator,
            memory: alignedMemory,
            remainingBytes: remainingSize
        );
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe T* Alloc<T>(nuint amount)
        where T : unmanaged
    {
        return _logicBlock.Alloc<T>(amount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe Span<T> AllocAsSpan<T>(int amount)
        where T : unmanaged
    {
        return new Span<T>(Alloc<T>((nuint)amount), amount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe T* Realloc<T>(T* previousMemory, nuint previousSize, nuint newSize)
        where T : unmanaged
    {
        return _logicBlock.Realloc(previousMemory, previousSize, newSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe Span<T> ReallocSpan<T>(ref Span<T> previousMemory, int newSize)
        where T : unmanaged
    {
        Span<T> newMemorySpan;
        nuint previousSize = (nuint)previousMemory.Length;
        fixed (T* previousPtr = previousMemory)
        {
            var newPtr = _logicBlock.Realloc(previousPtr, previousSize, (nuint)newSize);
            newMemorySpan = new Span<T>(newPtr, (int)newSize);
        }
        return newMemorySpan;
    }

    public unsafe void AddHandleToDispose<THandle>(THandle handle)
        where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return;
        }

        if (_logicBlock.DisposableHandles == null)
        {
            _logicBlock.DisposableHandles = Alloc<DisposableHandleArrayItem>(4);
            _logicBlock.DisposableHandles[0].SizeInfo = (4, 1);
        }

        var index = _logicBlock.DisposableHandles->SizeInfo.count++;
        if (_logicBlock.DisposableHandles->SizeInfo.size <= index)
        {
            var newSize = _logicBlock.DisposableHandles->SizeInfo.size * 2;
            _logicBlock.DisposableHandles = (DisposableHandleArrayItem*)_logicBlock.Allocator->Realloc(
              ptr: _logicBlock.DisposableHandles,
              byteCount: newSize * (nuint)sizeof(DisposableHandleArrayItem)
            );
            _logicBlock.DisposableHandles[0].SizeInfo.size = newSize;
        }
        _logicBlock.DisposableHandles[index].DisposableHandle = DisposableHandle.FromHandle(handle);
    }

    public void Dispose()
    {
        if (_logicBlock.DisposableHandles != null)
        {
            for (nuint i = 1; i < _logicBlock.DisposableHandles[0].SizeInfo.count; i++)
            {
                _logicBlock.DisposableHandles[i].DisposableHandle.Dispose();
            }
            _logicBlock.Allocator->Free(_logicBlock.DisposableHandles);
        }
        _logicBlock.Dispose();
        if (_logicBlock.IsLogicBlockHeapAllocated)
        {
            _logicBlock.Allocator->Free(_logicBlockPtr);
        }
    }
}