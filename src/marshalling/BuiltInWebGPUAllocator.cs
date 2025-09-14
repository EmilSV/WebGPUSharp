using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Marshalling;


internal static unsafe class BuiltInWebGPUAllocator
{
    public static WebGpuAllocator GetWebGpuAllocator()
    {
        return new WebGpuAllocator(
            context: null,
            alignedAlloc: &AlignedAlloc,
            alignedFree: &AlignedFree,
            alignedRealloc: &AlignedRealloc,
            alloc: &Alloc,
            allocZeroed: &AllocZeroed,
            free: &Free,
            realloc: &Realloc,
            disposeAllocator: &DisposeAllocator
        );
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* AlignedAlloc(void* _context, nuint byteCount, nuint alignment)
    {
        return NativeMemory.AlignedAlloc(byteCount, alignment);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void AlignedFree(void* _context, void* ptr)
    {
        NativeMemory.AlignedFree(ptr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* AlignedRealloc(void* _context, void* ptr, nuint byteCount, nuint alignment)
    {
        return NativeMemory.AlignedRealloc(ptr, byteCount, alignment);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* Alloc(void* _context, nuint byteCount)
    {
        return NativeMemory.Alloc(byteCount);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* AllocZeroed(void* _context, nuint byteCount)
    {
        return NativeMemory.AllocZeroed(byteCount);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Free(void* _context, void* ptr)
    {
        NativeMemory.Free(ptr);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* Realloc(void* _context, void* ptr, nuint byteCount)
    {
        return NativeMemory.Realloc(ptr, byteCount);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DisposeAllocator(WebGpuAllocator* allocator, void* _context)
    {
        // No-op for built-in allocator
    }
}