using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderBundleEncoderHandle :
    IDisposable, IWebGpuHandle<RenderBundleEncoderHandle>
{
    /// <inheritdoc cref="DrawIndexedIndirect(BufferHandle, ulong)"/>
    public void DrawIndexedIndirect(BufferBase indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, GetBorrowHandle(indirectBuffer), indirectOffset);
    }

    /// <inheritdoc cref="DrawIndexedIndirect(BufferHandle, ulong)"/>
    public void DrawIndirect(BufferBase indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, GetBorrowHandle(indirectBuffer), indirectOffset);
    }

    /// <inheritdoc cref="Finish(RenderBundleDescriptorFFI*)"/>
    public RenderBundleHandle Finish(in RenderBundleDescriptorFFI descriptor)
    {
        fixed (RenderBundleDescriptorFFI* ptr = &descriptor)
        {
            return WebGPU_FFI.RenderBundleEncoderFinish(this, ptr);
        }
    }

    /// <inheritdoc cref="Finish(RenderBundleDescriptorFFI*)"/>
    public RenderBundleHandle Finish(in RenderBundleDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(descriptor.label, allocator, addNullTerminator: true);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            RenderBundleDescriptorFFI descriptorFFI = new() { Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length) };
            return WebGPU_FFI.RenderBundleEncoderFinish(this, &descriptorFFI);
        }
    }

    /// <inheritdoc cref="Finish(RenderBundleDescriptorFFI*)"/>
    public RenderBundleHandle Finish()
    {
        return WebGPU_FFI.RenderBundleEncoderFinish(this, null);
    }

    /// <inheritdoc cref="InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderInsertDebugMarker(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref="PushDebugGroup(StringViewFFI)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, addNullTerminator: false);

        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderPushDebugGroup(this, StringViewFFI.CreateExplicitlySized(groupLabelPtr, groupLabelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public void SetBindGroup(uint groupIndex, BindGroupHandle group, ReadOnlySpan<uint> dynamicOffsets)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffsets)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, (nuint)dynamicOffsets.Length, dynamicOffsetPtr);
        }
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, uint dynamicOffsets)
    {
        WebGPU_FFI.RenderBundleEncoderSetBindGroup(
            renderBundleEncoder: this,
            groupIndex: groupIndex,
            group: GetBorrowHandle(group),
            dynamicOffsetCount: 1,
            dynamicOffsets: &dynamicOffsets
        );
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group)
    {
        WebGPU_FFI.RenderBundleEncoderSetBindGroup(
            renderBundleEncoder: this,
            groupIndex: groupIndex,
            group: GetBorrowHandle(group),
            dynamicOffsetCount: 0,
            dynamicOffsets: null
        );
    }

    /// <inheritdoc cref="SetBindGroup(uint, BindGroupHandle, nuint, uint*)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffset)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffset)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, GetBorrowHandle(group), (nuint)dynamicOffset.Length, dynamicOffsetPtr);
        }
    }

    /// <inheritdoc cref="SetIndexBuffer(BufferHandle, IndexFormat, ulong, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, GetBorrowHandle(buffer), format, offset, size);
    }

    /// <inheritdoc cref="SetIndexBuffer(BufferHandle, IndexFormat, ulong, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset = 0)
    {
        var size = buffer.GetSize() - offset;
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, GetBorrowHandle(buffer), format, offset, size);
    }

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref="SetPipeline(RenderPipelineBase)"/>
    public void SetPipeline(RenderPipelineBase pipeline)
    {
        WebGPU_FFI.RenderBundleEncoderSetPipeline(this, GetBorrowHandle(pipeline));
    }

    /// <inheritdoc cref="SetVertexBuffer(uint, BufferHandle, ulong, ulong)"/>
    public void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, GetBorrowHandle(buffer), offset, size);
    }

    /// <inheritdoc cref="SetVertexBuffer(uint, BufferHandle, ulong, ulong)"/>
    public void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset = 0)
    {
        var size = buffer.GetSize() - offset;
        WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, GetBorrowHandle(buffer), offset, size);
    }

    public static ref nuint AsPointer(ref RenderBundleEncoderHandle handle)
    {
        return ref Unsafe.As<RenderBundleEncoderHandle, nuint>(ref handle);
    }


    public static bool IsNull(RenderBundleEncoderHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(RenderBundleEncoderHandle handle)
    {
        WebGPU_FFI.RenderBundleEncoderAddRef(handle);
    }

    public static void Release(RenderBundleEncoderHandle handle)
    {
        WebGPU_FFI.RenderBundleEncoderRelease(handle);
    }

    public static RenderBundleEncoderHandle UnsafeFromPointer(nuint pointer)
    {
        return new RenderBundleEncoderHandle(pointer);
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.RenderBundleEncoderRelease(this);
        }
    }

    public RenderBundleEncoder ToSafeHandle()
    {
        return RenderBundleEncoder.FromHandle(this);
    }
}