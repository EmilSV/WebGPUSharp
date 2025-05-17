using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderPassEncoderHandle :
    IDisposable, IWebGpuHandle<RenderPassEncoderHandle>
{
    /// <inheritdoc cref="DrawIndexedIndirect(BufferHandle, ulong)"/>
    public void DrawIndexedIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderPassEncoderDrawIndexedIndirect(
            renderPassEncoder: this,
            indirectBuffer: GetBorrowHandle(indirectBuffer),
            indirectOffset: indirectOffset
        );
    }

    /// <inheritdoc cref="DrawIndexedIndirect(BufferHandle, ulong)"/>
    public void DrawIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)

    {
        WebGPU_FFI.RenderPassEncoderDrawIndirect(
            renderPassEncoder: this,
            indirectBuffer: GetBorrowHandle(indirectBuffer),
            indirectOffset: indirectOffset
        );
    }

    /// <param name="bundle"> The bundle to execute.</param>
    /// <inheritdoc cref="ExecuteBundles(nuint, RenderBundleHandle*)"/>
    public void ExecuteBundle(RenderBundleHandle bundle)
    {
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: 1,
            bundles: &bundle
        );
    }

    /// <inheritdoc cref="ExecuteBundle(RenderBundleHandle)"/>
    public void ExecuteBundle(RenderBundleBase bundle)
    {
        RenderBundleHandle handle = GetBorrowHandle(bundle);
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: 1,
            bundles: &handle
        );
    }

    /// <inheritdoc cref="ExecuteBundles(nuint, RenderBundleHandle*)"/>
    public void ExecuteBundles(ReadOnlySpan<RenderBundleHandle> bundles)
    {
        fixed (RenderBundleHandle* bundlesPtr = bundles)
        {
            WebGPU_FFI.RenderPassEncoderExecuteBundles(
                renderPassEncoder: this,
                bundleCount: (uint)bundles.Length,
                bundles: bundlesPtr
            );
        }
    }

    /// <inheritdoc cref="ExecuteBundles(nuint, RenderBundleHandle*)"/>
    public void ExecuteBundles(ReadOnlySpan<RenderBundle> bundles)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var (ptr, length) = GetBorrowHandlesAsPtrAndLength<RenderBundleHandle, RenderBundle>(bundles, allocator);
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: length,
            bundles: ptr
        );
    }

    /// <inheritdoc cref="InsertDebugMarker(StringViewFFI)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var markerLabelUtf8Span = ToUtf8Span(markerLabel, allocator, addNullTerminator: false);
        fixed (byte* markerLabelPtr = markerLabelUtf8Span)
        {
            WebGPU_FFI.RenderPassEncoderInsertDebugMarker(
                renderPassEncoder: this,
                markerLabel: StringViewFFI.CreateExplicitlySized(markerLabelPtr, markerLabelUtf8Span.Length)
            );
        }
    }

    /// <inheritdoc cref="PushDebugGroup(StringViewFFI)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, addNullTerminator: false);
        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.RenderPassEncoderPushDebugGroup(
                renderPassEncoder: this,
                groupLabel: StringViewFFI.CreateExplicitlySized(groupLabelPtr, groupLabelUtf8Span.Length)
            );
        }
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupHandle group)
    {
        WebGPU_FFI.RenderPassEncoderSetBindGroup(
            renderPassEncoder: this,
            groupIndex: groupIndex,
            group: group,
            dynamicOffsetCount: 0,
            dynamicOffsets: null
        );
    }

    /// <param name="dynamicOffset">A buffer offsets in bytes for each entry in bindGroup marked as <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Buffer">Buffer</see>.<see cref="BufferBindingLayout.HasDynamicOffset">HasDynamicOffset</see>, ordered by <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Binding">BindGroupLayoutEntry.Binding</see>.</param>
    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupHandle group, uint dynamicOffset)
    {
        WebGPU_FFI.RenderPassEncoderSetBindGroup(
            renderPassEncoder: this,
            groupIndex: groupIndex,
            group: group,
            dynamicOffsetCount: 1,
            dynamicOffsets: &dynamicOffset
        );
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupHandle group, ReadOnlySpan<uint> dynamicOffsets)
    {
        fixed (uint* dynamicOffsetsPtr = dynamicOffsets)
        {
            WebGPU_FFI.RenderPassEncoderSetBindGroup(
                renderPassEncoder: this,
                groupIndex: groupIndex,
                group: group,
                dynamicOffsetCount: (uint)dynamicOffsets.Length,
                dynamicOffsets: dynamicOffsetsPtr
            );
        }
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupBase group)
    {
        SetBindGroup(groupIndex, GetBorrowHandle(group));
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, uint)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupBase group, uint dynamicOffset)
    {
        SetBindGroup(groupIndex, GetBorrowHandle(group), dynamicOffset);
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public readonly void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffsets)
    {
        SetBindGroup(groupIndex, GetBorrowHandle(group), dynamicOffsets);
    }

    /// <inheritdoc cref="SetBlendConstant(Color*)"/>
    public void SetBlendConstant(in Color color)
    {
        fixed (Color* colorPtr = &color)
        {
            WebGPU_FFI.RenderPassEncoderSetBlendConstant(this, colorPtr);
        }
    }

    /// <inheritdoc cref="SetIndexBuffer(BufferHandle, IndexFormat, ulong, ulong)"/>
    public readonly void SetIndexBuffer(
        BufferBase buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderPassEncoderSetIndexBuffer(
            renderPassEncoder: this,
            buffer: GetBorrowHandle(buffer),
            format: format,
            offset: offset,
            size: size
        );
    }

    /// <inheritdoc cref="SetIndexBuffer(BufferHandle, IndexFormat, ulong, ulong)"/>
    public readonly void SetIndexBuffer(
    BufferBase buffer, IndexFormat format, ulong offset = 0)
    {
        var size = buffer.GetSize() - offset;
        WebGPU_FFI.RenderPassEncoderSetIndexBuffer(
            renderPassEncoder: this,
            buffer: GetBorrowHandle(buffer),
            format: format,
            offset: offset,
            size: size
        );
    }

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderPassEncoderSetLabel(
                renderPassEncoder: this,
                label: StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            );
        }
    }

    /// <inheritdoc cref="SetPipeline(RenderPipelineHandle)"/>
    public readonly void SetPipeline(RenderPipelineBase pipeline) =>
        SetPipeline(GetBorrowHandle(pipeline));

    /// <inheritdoc cref="SetVertexBuffer(uint, BufferHandle, ulong, ulong)"/>
    public readonly void SetVertexBuffer(
        uint slot, BufferBase buffer, ulong offset, ulong size)
    {
        SetVertexBuffer(slot, GetBorrowHandle(buffer), offset, size);
    }

    /// <inheritdoc cref="SetVertexBuffer(uint, BufferHandle, ulong, ulong)"/>
    public readonly void SetVertexBuffer(
        uint slot, BufferBase buffer, ulong offset = 0)
    {
        var size = buffer.GetSize() - offset;
        SetVertexBuffer(slot, GetBorrowHandle(buffer), offset, size);
    }

    /// <inheritdoc cref="SetViewport(float, float, float, float, float, float)"/>
    public void SetViewport(
        uint x, uint y, uint width, uint height, float minDepth, float maxDepth)
    {
        WebGPU_FFI.RenderPassEncoderSetViewport(
            renderPassEncoder: this,
            x: x,
            y: y,
            width: width,
            height: height,
            minDepth: minDepth,
            maxDepth: maxDepth
        );
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.RenderPassEncoderRelease(this);
        }
    }

    public static ref nuint AsPointer(ref RenderPassEncoderHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static RenderPassEncoderHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(RenderPassEncoderHandle handle)
    {
        return handle == Null;
    }

    public static RenderPassEncoderHandle UnsafeFromPointer(nuint pointer)
    {
        return new RenderPassEncoderHandle(pointer);
    }

    public static void Reference(RenderPassEncoderHandle handle)
    {
        WebGPU_FFI.RenderPassEncoderAddRef(handle);
    }

    public static void Release(RenderPassEncoderHandle handle)
    {
        WebGPU_FFI.RenderPassEncoderRelease(handle);
    }

    public RenderPassEncoder ToSafeHandle()
    {
        return RenderPassEncoder.FromHandle(this);
    }
}