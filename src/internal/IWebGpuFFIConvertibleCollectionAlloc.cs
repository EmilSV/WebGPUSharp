using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe interface IWebGpuFFIConvertibleCollectionAlloc<TFFI>
    where TFFI : unmanaged
{
    void UnsafeConvertToFFI(WebGpuAllocatorHandle allocator, out TFFI* dest, out nuint outCount);
}