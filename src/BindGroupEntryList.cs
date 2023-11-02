using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupEntryList : BaseFFIList<
    BindGroupEntryCollectionMarshal, BindGroupEntry,
    BindGroupEntryFFI, BindGroupEntryCollectionMarshal.Cache>
{

}