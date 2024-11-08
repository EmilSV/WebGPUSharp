using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderBundleEncoderHandle :
    IDisposable, IWebGpuHandle<RenderBundleEncoderHandle, RenderBundleEncoder>
{
    public void DrawIndexedIndirect(BufferBase indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, GetBorrowHandle(indirectBuffer), indirectOffset);
    }

    public void DrawIndirect(BufferBase indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, GetBorrowHandle(indirectBuffer), indirectOffset);
    }

    public RenderBundleHandle Finish(in RenderBundleDescriptorFFI descriptor)
    {
        fixed (RenderBundleDescriptorFFI* ptr = &descriptor)
        {
            return WebGPU_FFI.RenderBundleEncoderFinish(this, ptr);
        }
    }

    public RenderBundleHandle Finish(in RenderBundleDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(descriptor.label, allocator, addNullTerminator: true);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            RenderBundleDescriptorFFI descriptorFFI = new() { Label = labelPtr };
            return WebGPU_FFI.RenderBundleEncoderFinish(this, &descriptorFFI);
        }
    }

    public void InsertDebugMarker(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderInsertDebugMarker2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, addNullTerminator: false);

        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderPushDebugGroup2(this, new(groupLabelPtr, groupLabelUtf8Span.Length));
        }
    }

    public void SetBindGroup(uint groupIndex, BindGroupHandle group, ReadOnlySpan<uint> dynamicOffset)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffset)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, (nuint)dynamicOffset.Length, dynamicOffsetPtr);
        }
    }

    public void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffset)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffset)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, (BindGroupHandle)group, (nuint)dynamicOffset.Length, dynamicOffsetPtr);
        }
    }

    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, GetBorrowHandle(buffer), format, offset, size);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderBundleEncoderSetLabel2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        WebGPU_FFI.RenderBundleEncoderSetPipeline(this, (RenderPipelineHandle)pipeline);
    }

    public void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset, ulong size)
    {
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

    public RenderBundleEncoder? ToSafeHandle(bool isOwnedHandle)
    {
        return RenderBundleEncoder.FromHandle(this, isOwnedHandle);
    }
}