using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// In-progress recording of a render pass: a list of render commands in a <see cref="CommandEncoderHandle" />.
/// 
/// It can be created with <see cref="CommandEncoderHandle.BeginRenderPass" />, whose RenderPassDescriptor specifies the attachments (textures) that will be rendered to.
/// 
/// Most of the methods on RenderPassEncoderHandle serve one of two purposes, identifiable by their names:
/// 
/// Draw*(): Drawing (that is, encoding a render command, which, when executed by the GPU, will rasterize something and execute shaders).
/// Set*(): Setting part of the render state for future drawing commands.
/// 
/// A render pass may contain any number of drawing commands, and before/between each command the render state may be updated however you wish;
/// each drawing command will be executed using the render state that has been set when the Draw*() function is called.
/// </summary>
public unsafe partial struct RenderPassEncoderHandle : IEquatable<RenderPassEncoderHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static RenderPassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPassEncoderHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(RenderPassEncoderHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(RenderPassEncoderHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(RenderPassEncoderHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(RenderPassEncoderHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is RenderPassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Start a occlusion query on this render pass. It can be ended with end_occlusion_query. Occlusion queries may not be nested.
    /// </summary>
    /// <param name="queryIndex">The index of the query in the query set.</param>
    public void BeginOcclusionQuery(uint queryIndex) => WebGPU_FFI.RenderPassEncoderBeginOcclusionQuery(this, queryIndex);

    /// <summary>
    /// Draws primitives from the active vertex buffer(s).
    /// 
    /// The active vertex buffer(s) can be set with <see cref="SetVertexBuffer" />. Does not use an Index Buffer. If you need this see <see cref="DrawIndexed" />.
    /// 
    /// Errors if vertices Range is outside of the range of the vertices range of any set vertex buffer.
    /// </summary>
    /// <param name="firstInstance">First instance to draw.</param>
    /// <param name="firstVertex">Offset into the vertex buffers, in vertices, to begin drawing from.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="vertexCount">The number of vertices to draw.</param>
    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) => WebGPU_FFI.RenderPassEncoderDraw(this, vertexCount, instanceCount, firstVertex, firstInstance);

    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers.
    /// 
    /// The active index buffer can be set with <see cref="SetIndexBuffer" /> The active vertex buffers can be set with <see cref="SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    /// <param name="firstInstance">First instance to draw.</param>
    /// <param name="baseVertex">Added to each index value before indexing into the vertex buffers.</param>
    /// <param name="firstIndex">Offset into the index buffer, in indices, begin drawing from.</param>
    /// <param name="instanceCount">The number of indices to draw.</param>
    /// <param name="indexCount">The number of indices to draw.</param>
    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) => WebGPU_FFI.RenderPassEncoderDrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// This is like calling <see cref="DrawIndexed" /> but the contents of the call are specified in the indirectBuffer.
    /// </summary>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    public void DrawIndexedIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderPassEncoderDrawIndexedIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Draws primitives from the active vertex buffer(s) based on the contents of the <paramref name="indirectBuffer" />.
    /// 
    /// The active vertex buffers can be set with <see cref="FFI.RenderEncoder.SetVertexBuffer" />.
    /// 
    /// The indirect draw parameters encoded in the buffer must be a tightly packed block of four 32-bit unsigned integer values (16 bytes total), given in the same order as the arguments for <see cref="FFI.RenderEncoder.Draw" />.
    /// </summary>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect draw parameters.</param>
    public void DrawIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderPassEncoderDrawIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    public void End() => WebGPU_FFI.RenderPassEncoderEnd(this);

    /// <summary>
    /// End the occlusion query on this render pass. It can be started with <see cref="BeginOcclusionQuery" />. Occlusion queries may not be nested.
    /// </summary>
    public void EndOcclusionQuery() => WebGPU_FFI.RenderPassEncoderEndOcclusionQuery(this);

    /// <summary>
    /// Executes the commands previously recorded into the given  <see cref="RenderBundle"/>s as part of
    /// this render pass.
    /// When a  <see cref="RenderBundle"/> is executed, it does not inherit the render pass's pipeline, bind
    /// groups, or vertex and index buffers. After a  <see cref="RenderBundle"/> has executed, the render
    /// pass's pipeline, bind group, and vertex/index buffer state is cleared
    /// (to the initial, empty values).
    /// Note: The state is cleared, not restored to the previous state.
    /// This occurs even if zero  <see cref="RenderBundle">GPURenderBundles</see> are executed.
    /// </summary>
    /// <param name="bundles">List of render bundles to execute.</param>
    /// <param name="bundleCount">The number item in the <paramref name="bundles" /> sequence.</param>
    public void ExecuteBundles(nuint bundleCount, RenderBundleHandle* bundles) => WebGPU_FFI.RenderPassEncoderExecuteBundles(this, bundleCount, bundles);

    /// <summary>
    /// Inserts a debug marker into the command stream.
    /// </summary>
    /// <param name="markerLabel">The label of the debug marker.</param>
    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.RenderPassEncoderInsertDebugMarker(this, markerLabel);

    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    public void PopDebugGroup() => WebGPU_FFI.RenderPassEncoderPopDebugGroup(this);

    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    /// <param name="groupLabel">The label of the debug group.</param>
    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.RenderPassEncoderPushDebugGroup(this, groupLabel);

    /// <summary>
    /// Sets the active bind group for a given bind group index. The bind group layout in the active pipeline when any Draw*() method is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in binding order. These offsets have to be aligned to Limits.MinUniformBufferOffsetAlignment or Limits.MinStorageBufferOffsetAlignment appropriately.
    /// 
    /// Subsequent draw calls' shader executions will be able to access data in these bind groups.
    /// </summary>
    /// <param name="dynamicOffsets">Sequence containing buffer offsets in bytes for each entry in bindGroup marked as <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Buffer">Buffer</see>.<see cref="BufferBindingLayout.HasDynamicOffset">HasDynamicOffset</see>, ordered by <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Binding">BindGroupLayoutEntry.Binding</see>.</param>
    /// <param name="dynamicOffsetCount">The number of item in the <paramref name="dynamicOffsets" />.</param>
    /// <param name="group">Bind group to use for subsequent render commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.RenderPassEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    public void SetBlendConstant(Color* color) => WebGPU_FFI.RenderPassEncoderSetBlendConstant(this, color);

    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to <see cref="DrawIndexed" /> on this RenderPassEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    /// <param name="size">Size in bytes of the index data in buffer. Defaults to the size of the buffer minus the offset.</param>
    /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
    /// <param name="format">Format of the index data contained in buffer.</param>
    /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
    public void SetIndexBuffer(BufferHandle buffer, IndexFormat format, ulong offset, ulong size) => WebGPU_FFI.RenderPassEncoderSetIndexBuffer(this, buffer, format, offset, size);

    /// <summary>
    /// Sets the debug label of the RenderPassEncoderHandle.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderPassEncoderSetLabel(this, label);

    /// <summary>
    /// Sets the active render pipeline.
    /// 
    /// Subsequent draw calls will exhibit the behavior defined by pipeline.
    /// </summary>
    /// <param name="pipeline">The render pipeline to use for subsequent drawing commands.</param>
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

    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderPass will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
    /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
    /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
    /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
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

    /// <summary>
    /// Increments the reference count of the <see cref="RenderPassEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.RenderPassEncoderAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="RenderPassEncoderHandle"/>. When the reference count reaches zero, the <see cref="RenderPassEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderPassEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.RenderPassEncoderRelease(this);

}
