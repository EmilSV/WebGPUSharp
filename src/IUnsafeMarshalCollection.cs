using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe interface IUnsafeMarshalCollection<TFFI> : IUnsafeMarshalCollectionAlloc<TFFI>
    where TFFI : unmanaged
{
    void GetPointerToFFIItems(out TFFI* dest, out nuint outCount);
    void GetPointerToFFIItems(out TFFI* dest, out uint outCount);
}