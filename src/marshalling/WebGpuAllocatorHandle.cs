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
        public readonly unsafe struct StackMode(LogicBlock* block)
        {
            public void Setup(
                WebGpuAllocator* allocator,
                void* memory,
                nuint remainingSize
            )
            {
                block->Allocator = allocator;
                block->Memory = memory;
                block->RemainingSize = remainingSize;
                block->_isStackMemoryOrCount = 0;
            }

            public T* Alloc<T>(nuint amount)
                where T : unmanaged
            {
                nuint byteAmount = amount * (nuint)sizeof(T);
                void* alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<T>(), amount, block->Memory, out nuint remainingSize);
                if (alignedMemory == null || remainingSize < byteAmount)
                {
                    HeapMode heapMode = new(block);
                    heapMode.Setup();
                    return heapMode.Alloc<T>(amount);
                }

                block->Memory = (void*)((nuint)alignedMemory + byteAmount);
                block->RemainingSize = remainingSize - byteAmount;
                return (T*)alignedMemory;
            }
        }

        public readonly struct HeapMode(LogicBlock* block)
        {
            public void Setup()
            {
                block->Memory = block->Allocator->Alloc((nuint)sizeof(nuint) * 4);
                block->RemainingSize = 4;
                block->_isStackMemoryOrCount = 0;
            }

            public T* Alloc<T>(nuint amount)
                where T : unmanaged
            {
                var newMemory = block->Allocator->AlignedAlloc((nuint)sizeof(T) * amount, WebGpuAlignment.GetAlignmentOf<T>());
                if (newMemory == null)
                {
                    throw new OutOfMemoryException("Failed to allocate memory for WebGpuAllocatorHandle.");
                }

                if (block->RemainingSize <= (nuint)block->_isStackMemoryOrCount)
                {
                    var newSize = block->RemainingSize * 2;
                    block->Memory = block->Allocator->Realloc(block->Memory, newSize * (nuint)sizeof(nuint));
                    block->RemainingSize = newSize;
                    var ptrArray = (void**)block->Memory;
                    ptrArray[block->_isStackMemoryOrCount] = newMemory;
                    block->_isStackMemoryOrCount++;
                }

                return (T*)newMemory;
            }

            public void Dispose()
            {
                if (block->Memory != null)
                {
                    for (nuint i = 0; i < (nuint)block->_isStackMemoryOrCount; i++)
                    {
                        var ptrArray = (void**)block->Memory;
                        block->Allocator->Free(ptrArray[i]);
                    }
                    block->Allocator->Free(block->Memory);
                }
            }
        }

        public WebGpuAllocator* Allocator;
        public void* Memory;
        public nuint RemainingSize;
        private nint _isStackMemoryOrCount;
        public DisposableHandleArrayItem* DisposableHandles;
        public readonly bool IsStackMemory
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _isStackMemoryOrCount < 0;
        }

        public void SetUpStackMemory(
            WebGpuAllocator* allocator,
            void* memory,
            nuint remainingSize)
        {
            Allocator = allocator;
            Memory = memory;
            RemainingSize = remainingSize;
            _isStackMemoryOrCount = -1; // Negative value indicates stack memory mode
        }
    }
    private readonly LogicBlock* _logicBlock;

    private LogicBlock.StackMode LogicBlockStackMode => new(_logicBlock);

    private LogicBlock.HeapMode LogicBlockHeapMode => new(_logicBlock);

    internal WebGpuAllocatorHandle(WebGpuAllocator* allocator, void* stackMemory, nuint size)
    {
        var alignedMemory = WebGpuAlignment.GetAlign(WebGpuAlignment.GetAlignmentOf<LogicBlock>(), size, stackMemory, out nuint remainingSize);
        if (alignedMemory == null)
        {
            throw new OutOfMemoryException("Failed to allocate aligned memory for WebGpuAllocatorHandle.");
        }
        _logicBlock = (LogicBlock*)alignedMemory;

        LogicBlockStackMode.Setup(
            allocator,
            alignedMemory,
            remainingSize
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

        if (!_logicBlock->IsStackMemory)
        {
            LogicBlockHeapMode.Dispose();
        }
        else
        {
            // For stack memory, we don't need to free the memory, it will be automatically cleaned up.
        }
    }
}