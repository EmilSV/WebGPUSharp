using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe interface IWebGpuFFIConvertibleCollection<TFFI> : IWebGpuFFIConvertibleCollectionAlloc<TFFI>
    where TFFI : unmanaged
{
    void UnsafeConvertToFFI(out TFFI* dest, out nuint outCount);
}