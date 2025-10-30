using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPassDescriptorFFI"/>
public ref partial struct RenderPassDescriptor
{
    /// <inheritdoc cref="RenderPassDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref="RenderPassDescriptorFFI.ColorAttachments"/>
    public required ReadOnlySpan<RenderPassColorAttachment> ColorAttachments;
    /// <inheritdoc cref="RenderPassDescriptorFFI.DepthStencilAttachment"/>
    public RenderPassDepthStencilAttachment? DepthStencilAttachment;
    /// <inheritdoc cref="RenderPassDescriptorFFI.OcclusionQuerySet"/>
    public QuerySet? OcclusionQuerySet;
    /// <inheritdoc cref="RenderPassDescriptorFFI.TimestampWrites"/>
    public PassTimestampWrites? TimestampWrites;
}