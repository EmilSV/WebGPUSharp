using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct RenderPassEncoderHandle : IEquatable<RenderPassEncoderHandle>
{
    private readonly nuint _ptr;
    public static RenderPassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPassEncoderHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(RenderPassEncoderHandle handle) => handle._ptr;

    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr == right._ptr;

    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr != right._ptr;

    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(RenderPassEncoderHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(RenderPassEncoderHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(RenderPassEncoderHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is RenderPassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <param name="queryIndex">The index of the query in the query set.</param>
    public void BeginOcclusionQuery(uint queryIndex) => WebGPU_FFI.RenderPassEncoderBeginOcclusionQuery(this, queryIndex);

    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) => WebGPU_FFI.RenderPassEncoderDraw(this, vertexCount, instanceCount, firstVertex, firstInstance);

    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) => WebGPU_FFI.RenderPassEncoderDrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    public void DrawIndexedIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderPassEncoderDrawIndexedIndirect(this, indirectBuffer, indirectOffset);

    public void DrawIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderPassEncoderDrawIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    public void End() => WebGPU_FFI.RenderPassEncoderEnd(this);

    public void EndOcclusionQuery() => WebGPU_FFI.RenderPassEncoderEndOcclusionQuery(this);

    /// <summary>
    /// Executes the commands previously recorded into the given  <see cref="WebGpuSharp.RenderBundle"/>s as part of
    /// this render pass.
    /// When a  <see cref="WebGpuSharp.RenderBundle"/> is executed, it does not inherit the render pass's pipeline, bind
    /// groups, or vertex and index buffers. After a  <see cref="WebGpuSharp.RenderBundle"/> has executed, the render
    /// pass's pipeline, bind group, and vertex/index buffer state is cleared
    /// (to the initial, empty values).
    /// Note: The state is cleared, not restored to the previous state.
    /// This occurs even if zero  <see cref="WebGpuSharp.RenderBundle">GPURenderBundles</see> are executed.
    /// </summary>
    /// <param name="bundles">List of render bundles to execute.</param>
    public void ExecuteBundles(nuint bundleCount, RenderBundleHandle* bundles) => WebGPU_FFI.RenderPassEncoderExecuteBundles(this, bundleCount, bundles);

    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.RenderPassEncoderInsertDebugMarker(this, markerLabel);

    public void PopDebugGroup() => WebGPU_FFI.RenderPassEncoderPopDebugGroup(this);

    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.RenderPassEncoderPushDebugGroup(this, groupLabel);

    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.RenderPassEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    public void SetBlendConstant(Color* color) => WebGPU_FFI.RenderPassEncoderSetBlendConstant(this, color);

    public void SetIndexBuffer(BufferHandle buffer, IndexFormat format, ulong offset, ulong size) => WebGPU_FFI.RenderPassEncoderSetIndexBuffer(this, buffer, format, offset, size);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderPassEncoderSetLabel(this, label);

    public void SetPipeline(RenderPipelineHandle pipeline) => WebGPU_FFI.RenderPassEncoderSetPipeline(this, pipeline);

    /// <summary>
    /// Sets the scissor rectangle used during the rasterization stage.
    /// After transformation into viewport coordinates any fragments which fall outside the scissor
    /// rectangle will be discarded.
    /// </summary>
    /// <param name="x">Minimum X value of the scissor rectangle in pixels.</param>
    /// <param name="y">Minimum Y value of the scissor rectangle in pixels.</param>
    /// <param name="width">Width of the scissor rectangle in pixels.</param>
    /// <param name="height">Height of the scissor rectangle in pixels.</param>
    public void SetScissorRect(uint x, uint y, uint width, uint height) => WebGPU_FFI.RenderPassEncoderSetScissorRect(this, x, y, width, height);

    /// <summary>
    /// Sets the {{RenderState/stencilReference}} value used during stencil tests with
    /// the  <see cref="StencilOperation.Replace"/>  <see cref="StencilOperation"/>.
    /// </summary>
    /// <param name="reference">The new stencil reference value.</param>
    public void SetStencilReference(uint reference) => WebGPU_FFI.RenderPassEncoderSetStencilReference(this, reference);

    public void SetVertexBuffer(uint slot, BufferHandle buffer, ulong offset, ulong size) => WebGPU_FFI.RenderPassEncoderSetVertexBuffer(this, slot, buffer, offset, size);

    /// <summary>
    /// Sets the viewport used during the rasterization stage to linearly map from
    /// normalized device coordinates to viewport coordinates.
    /// </summary>
    /// <param name="x">Minimum X value of the viewport in pixels.</param>
    /// <param name="y">Minimum Y value of the viewport in pixels.</param>
    /// <param name="width">Width of the viewport in pixels.</param>
    /// <param name="height">Height of the viewport in pixels.</param>
    /// <param name="minDepth">Minimum depth value of the viewport.</param>
    /// <param name="maxDepth">Maximum depth value of the viewport.</param>
    public void SetViewport(float x, float y, float width, float height, float minDepth, float maxDepth) => WebGPU_FFI.RenderPassEncoderSetViewport(this, x, y, width, height, minDepth, maxDepth);

    public void AddRef() => WebGPU_FFI.RenderPassEncoderAddRef(this);

    public void Release() => WebGPU_FFI.RenderPassEncoderRelease(this);

}
