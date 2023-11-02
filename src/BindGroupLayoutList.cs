using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupLayoutList : BaseFFIList<
    BindGroupLayoutCollectionMarshal, BindGroupLayout,
    BindGroupLayoutHandle, BindGroupLayoutCollectionMarshal.Cache>
{ }