using WebGpuSharp.FFI;
using WebGpuSharp.Internal;


namespace WebGpuSharp;


public unsafe sealed class ConstantEntryList : BaseFFIList<
    ConstantEntryMarshal, ConstantEntry,
    ConstantEntryFFI, ConstantEntryMarshal.Cache
>
{

}