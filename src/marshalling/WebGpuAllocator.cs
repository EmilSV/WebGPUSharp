using System.Runtime.CompilerServices;

namespace WebGpuSharp.Marshalling;


public readonly unsafe struct WebGpuAllocator
{
    private readonly void* _context;
    private readonly delegate* unmanaged[Cdecl]<void*, nuint, nuint, void*> _alignedAlloc;
    private readonly delegate* unmanaged[Cdecl]<void*, void*, void> _alignedFree;
    private readonly delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, void*> _alignedRealloc;
    private readonly delegate* unmanaged[Cdecl]<void*, nuint, void*> _alloc;
    private readonly delegate* unmanaged[Cdecl]<void*, nuint, void*> _allocZeroed;
    private readonly delegate* unmanaged[Cdecl]<void*, void*, void> _free;
    private readonly delegate* unmanaged[Cdecl]<void*, void*, nuint, void*> _realloc;
    private readonly delegate* unmanaged[Cdecl]<WebGpuAllocator*, void*, void> _disposeAllocator;

    public WebGpuAllocator(
        void* context,
        delegate* unmanaged[Cdecl]<void*, nuint, nuint, void*> alignedAlloc,
        delegate* unmanaged[Cdecl]<void*, void*, void> alignedFree,
        delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, void*> alignedRealloc,
        delegate* unmanaged[Cdecl]<void*, nuint, void*> alloc,
        delegate* unmanaged[Cdecl]<void*, nuint, void*> allocZeroed,
        delegate* unmanaged[Cdecl]<void*, void*, void> free,
        delegate* unmanaged[Cdecl]<void*, void*, nuint, void*> realloc,
        delegate* unmanaged[Cdecl]<WebGpuAllocator*, void*, void> disposeAllocator)
    {
        _context = context;
        _alignedAlloc = alignedAlloc;
        _alignedFree = alignedFree;
        _alignedRealloc = alignedRealloc;
        _alloc = alloc;
        _allocZeroed = allocZeroed;
        _free = free;
        _realloc = realloc;
        _disposeAllocator = disposeAllocator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void* AlignedAlloc(nuint byteCount, nuint alignment)
    {
        return _alignedAlloc(_context, byteCount, alignment);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void AlignedFree(void* ptr)
    {
        _alignedFree(_context, ptr);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void* AlignedRealloc(void* ptr, nuint byteCount, nuint alignment)
    {
        return _alignedRealloc(_context, ptr, byteCount, alignment);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void* Alloc(nuint byteCount)
    {
        return _alloc(_context, byteCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void* AllocZeroed(nuint byteCount)
    {
        return _allocZeroed(_context, byteCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Free(void* ptr)
    {
        _free(_context, ptr);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void* Realloc(void* ptr, nuint byteCount)
    {
        return _realloc(_context, ptr, byteCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DisposeAllocator(WebGpuAllocator* allocator)
    {
        allocator->_disposeAllocator(allocator, allocator->_context);
    }
}