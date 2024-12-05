using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct RenderBundleEncoderHandle : IEquatable<RenderBundleEncoderHandle>
{
    private readonly nuint _ptr;
    public static RenderBundleEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderBundleEncoderHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(RenderBundleEncoderHandle handle) => handle._ptr;

    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr == right._ptr;

    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr != right._ptr;

    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(RenderBundleEncoderHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(RenderBundleEncoderHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(RenderBundleEncoderHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is RenderBundleEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) => WebGPU_FFI.RenderBundleEncoderDraw(this, vertexCount, instanceCount, firstVertex, firstInstance);

    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) => WebGPU_FFI.RenderBundleEncoderDrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    public void DrawIndexedIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, indirectBuffer, indirectOffset);

    public void DrawIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    public RenderBundleHandle Finish(RenderBundleDescriptorFFI* descriptor) => WebGPU_FFI.RenderBundleEncoderFinish(this, descriptor);

    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.RenderBundleEncoderInsertDebugMarker(this, markerLabel);

    public void PopDebugGroup() => WebGPU_FFI.RenderBundleEncoderPopDebugGroup(this);

    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.RenderBundleEncoderPushDebugGroup(this, groupLabel);

    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    public void SetIndexBuffer(BufferHandle buffer, IndexFormat format, ulong offset, ulong size) => WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, buffer, format, offset, size);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderBundleEncoderSetLabel(this, label);

    public void SetPipeline(RenderPipelineHandle pipeline) => WebGPU_FFI.RenderBundleEncoderSetPipeline(this, pipeline);

    public void SetVertexBuffer(uint slot, BufferHandle buffer, ulong offset, ulong size) => WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, buffer, offset, size);

    public void AddRef() => WebGPU_FFI.RenderBundleEncoderAddRef(this);

    public void Release() => WebGPU_FFI.RenderBundleEncoderRelease(this);

}
