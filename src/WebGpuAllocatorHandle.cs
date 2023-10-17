using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Internal;

public readonly ref struct WebGpuAllocatorHandle
{
    private readonly WebGpuAllocator _allocator;

    private WebGpuAllocatorHandle(WebGpuAllocator allocator)
    {
        _allocator = allocator;
    }

    internal static WebGpuAllocatorHandle Get()
    {
        return new WebGpuAllocatorHandle(WebGpuAllocator.Rent());
    }

    public unsafe T* Alloc<T>(nuint amount)
        where T : unmanaged
    {
        return _allocator.Alloc<T>(amount);
    }

    public unsafe Span<T> AllocAsSpan<T>(nuint amount)
        where T : unmanaged
    {
        return new Span<T>(_allocator.Alloc<T>(amount), (int)amount);
    }

    public unsafe T* Realloc<T>(T* ptr, nuint amount)
        where T : unmanaged
    {
        return _allocator.Realloc<T>(ptr, amount);
    }

    public unsafe void ReallocSpan<T>(ref Span<T> span, nuint amount)
        where T : unmanaged
    {
        var ptr = Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
        ptr = _allocator.Realloc<T>((T*)ptr, amount);
        span = new Span<T>(ptr, (int)amount);
    }

    public void Dispose()
    {
        WebGpuAllocator.Return(_allocator);
    }
}