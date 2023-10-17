using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupLayoutList : BaseFFIList<
    BindGroupLayoutMarshal, BindGroupLayout,
    BindGroupLayoutHandle, BindGroupLayoutMarshal.Cache>
{ }