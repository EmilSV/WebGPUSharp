using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupEntryList : BaseFFIList<
    BindGroupEntryMarshal, BindGroupEntry,
    BindGroupEntryFFI, BindGroupEntryMarshal.Cache>
{

}