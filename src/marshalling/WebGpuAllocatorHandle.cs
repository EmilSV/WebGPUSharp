using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp.Marshalling;

public readonly unsafe ref struct WebGpuAllocatorHandle
{
    [StructLayout(LayoutKind.Explicit)]
    private struct DisposableHandleArrayItem
    {
        [FieldOffset(0)]
        public (nuint size, nuint count) SizeInfo;
        [FieldOffset(0)]
        public DisposableHandle DisposableHandle;
    }

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
        public bool IsInStackMode { get; private set; }

        public DisposableHandleArrayItem* DisposableHandles;

        public void SetUpStackMemory(
            WebGpuAllocator* allocator,
            void* memory,
            nuint remainingBytes)
        {
            IsInStackMode = true;
            Allocator = allocator;
            Data.Stack.Memory = (byte*)memory;
            Data.Stack.RemainingBytes = remainingBytes;
        }

        public void SetUpHeapMemory()
        {
            IsInStackMode = false;
            Data.Heap.AllocPtr = (void**)Allocator->Alloc((nuint)sizeof(void*) * 4);
            Data.Heap.Size = 4;
            Data.Heap.Count = 0;
        }

        public T* AllocStack<T>(nuint amount)
            where T : unmanaged
        {
            nuint byteAmount = amount * (nuint)sizeof(T);
            void* alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<T>(), amount, Data.Stack.Memory, out nuint remainingSize);
            if (alignedMemory == null || remainingSize < byteAmount)
            {
                SetUpHeapMemory();
                return AllocHeap<T>(amount);
            }

            Data.Stack.Memory = (byte*)((nuint)alignedMemory + byteAmount);
            Data.Stack.RemainingBytes = remainingSize - byteAmount;
            return (T*)alignedMemory;
        }

        public T* AllocHeap<T>(nuint amount)
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
    }
    private readonly LogicBlock* _logicBlock;

    internal WebGpuAllocatorHandle(WebGpuAllocator* allocator, void* stackMemory, nuint size)
    {
        var alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<LogicBlock>(), size, stackMemory, out nuint remainingSize);
        if (alignedMemory == null)
        {
            throw new OutOfMemoryException("Failed to allocate aligned memory for WebGpuAllocatorHandle.");
        }
        _logicBlock = (LogicBlock*)alignedMemory;

        _logicBlock->SetUpStackMemory(
            allocator: allocator,
            memory: alignedMemory,
            remainingBytes: remainingSize
        );
    }


    public unsafe T* Alloc<T>(nuint amount)
        where T : unmanaged
    {
        if (_logicBlock->IsStackMemory)
        {
            return LogicBlockStackMode.Alloc<T>(amount);
        }
        else
        {
            return LogicBlockHeapMode.Alloc<T>(amount);
        }
    }

    public unsafe Span<T> AllocAsSpan<T>(nuint amount)
        where T : unmanaged
    {
        return new Span<T>(Alloc<T>(amount), (int)amount);
    }

    public unsafe void AddHandleToDispose<THandle>(THandle handle)
        where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return;
        }

        if (_logicBlock->DisposableHandles == null)
        {
            _logicBlock->DisposableHandles = Alloc<DisposableHandleArrayItem>(4);
            _logicBlock->DisposableHandles[0].SizeInfo = (4, 1);
        }

        ref var sizeInfo = ref _logicBlock->DisposableHandles[0].SizeInfo;
        var index = sizeInfo.count++;
        if (sizeInfo.size <= index)
        {
            var newSize = sizeInfo.size * 2;
            _logicBlock->DisposableHandles = (DisposableHandleArrayItem*)_logicBlock->Allocator->Realloc(
              ptr: _logicBlock->DisposableHandles,
              byteCount: newSize * (nuint)sizeof(DisposableHandleArrayItem)
            );
            _logicBlock->DisposableHandles[0].SizeInfo.size = newSize;
        }
        _logicBlock->DisposableHandles[index].DisposableHandle = DisposableHandle.FromHandle(handle);
    }

    public unsafe THandle GetHandle<THandle>(WebGPUHandleWrapperBase<THandle>? safeHandle)
        where THandle : unmanaged, IWebGpuHandle<THandle>, IEquatable<THandle>
    {
        if (safeHandle == null)
        {
            return THandle.Null;
        }

        if (WebGPUMarshal.IsHandleWrapperSameLifetime(safeHandle))
        {
            return WebGPUHandleWrapperBase<THandle>.GetHandle(safeHandle);
        }
        else
        {
            var ownedHandle = WebGPUHandleWrapperBase<THandle>.GetHandle(safeHandle);
            THandle.Reference(ownedHandle);
            AddHandleToDispose(ownedHandle);
            return ownedHandle;
        }
    }


    public void Dispose()
    {
        if (_logicBlock->DisposableHandles != null)
        {
            for (nuint i = 1; i < _logicBlock->DisposableHandles[0].SizeInfo.count; i++)
            {
                _logicBlock->DisposableHandles[i].DisposableHandle.Dispose();
            }
            _logicBlock->Allocator->Free(_logicBlock->DisposableHandles);
        }

        if (!_logicBlock->IsInStackMode)
        {
            LogicBlockHeapMode.Dispose();
        }
        else
        {
            // For stack memory, we don't need to free the memory, it will be automatically cleaned up.
        }
    }
}