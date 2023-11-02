using WebGpuSharp.FFI;
using WebGpuSharp.Internal;


namespace WebGpuSharp;


public unsafe sealed class ConstantEntryList : BaseFFIList<
    ConstantEntryCollectionMarshal, ConstantEntry,
    ConstantEntryFFI, ConstantEntryCollectionMarshal.Cache
>
{

}