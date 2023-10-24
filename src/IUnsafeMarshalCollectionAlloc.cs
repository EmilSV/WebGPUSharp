using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe interface IUnsafeMarshalCollectionAlloc<TFFI>
    where TFFI : unmanaged
{
    void GetPointerToFFIItems(WebGpuAllocatorHandle allocator, out TFFI* dest, out nuint outCount);
    void GetPointerToFFIItems(WebGpuAllocatorHandle allocator, out TFFI* dest, out uint outCount);
}