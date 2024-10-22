using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct StencilFaceState
{
    /// <summary>
    /// The  <see cref="CompareFunction"/> used when testing the {{RenderState/stencilReference}} value
    /// against the fragment's  <see cref="WebGpuSharp.RenderPassDescriptor.DepthStencilAttachment"/> stencil values.
    /// </summary>
    public CompareFunction Compare = CompareFunction.Always;
    /// <summary>
    /// The  <see cref="StencilOperation"/> performed if the fragment stencil comparison test described by
    ///  <see cref="Compare"/> fails.
    /// </summary>
    public StencilOperation FailOp = StencilOperation.Keep;
    /// <summary>
    /// The  <see cref="StencilOperation"/> performed if the fragment depth comparison described by
    ///  <see cref="DepthStencilState.DepthCompare"/> fails.
    /// </summary>
    public StencilOperation DepthFailOp = StencilOperation.Keep;
    /// <summary>
    /// The  <see cref="StencilOperation"/> performed if the fragment stencil comparison test described by
    ///  <see cref="Compare"/> passes.
    /// </summary>
    public StencilOperation PassOp = StencilOperation.Keep;

    public StencilFaceState() { }

}
