using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Marshalling;

public readonly unsafe ref struct WebGpuAllocatorHandle
    : IDisposable
{
    private readonly ref WebGpuAllocatorLogicBlock _logicBlock;
    internal WebGpuAllocatorHandle(
        ref WebGpuAllocatorLogicBlock logicBlock,
        WebGpuAllocator* allocator,
        byte* stackMemory,
        uint size)
    {
        _logicBlock = ref logicBlock;

        if (stackMemory == null && size == 0)
        {
            _logicBlock.SetupHeapMemory(allocator);
            return;
        }
        else
        {
            _logicBlock.SetupStackMemory(allocator, stackMemory, size);
        }
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
    public unsafe void ReallocSpan<T>(ref Span<T> previousMemory, int newSize)
        where T : unmanaged
    {
        Span<T> newMemorySpan;
        nuint previousSize = (nuint)previousMemory.Length;
        fixed (T* previousPtr = previousMemory)
        {
            var newPtr = _logicBlock.Realloc(previousPtr, previousSize, (nuint)newSize);
            newMemorySpan = new Span<T>(newPtr, (int)newSize);
        }
        previousMemory = newMemorySpan;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe void AddHandleToDispose<THandle>(THandle handle)
        where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return;
        }

        _logicBlock.AddDisposableHandle(DisposableHandle.FromHandle(handle));
    }

    public void Dispose()
    {
        _logicBlock.Dispose();
    }
}