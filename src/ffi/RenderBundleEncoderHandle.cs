using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderBundleEncoderHandle :
    IDisposable, IWebGpuHandle<RenderBundleEncoderHandle, RenderBundleEncoder>
{
    public void DrawIndexedIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, (BufferHandle)indirectBuffer, indirectOffset);
    }

    public void DrawIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, (BufferHandle)indirectBuffer, indirectOffset);
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
        var labelSpan = ToUtf8Span(descriptor.label, allocator);
        fixed (byte* labelPtr = labelSpan)
        {
            RenderBundleDescriptorFFI descriptorFFI = new() { Label = new(labelPtr, (uint)labelSpan.Length) };
            return WebGPU_FFI.RenderBundleEncoderFinish(this, &descriptorFFI);
        }
    }

    public void InsertDebugMarker(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelSpan = ToUtf8Span(label, allocator);
        fixed (byte* labelPtr = labelSpan)
        {
            WebGPU_FFI.RenderBundleEncoderInsertDebugMarker2(this, new(labelPtr, labelSpan.Length));
        }
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var groupLabelSpan = ToUtf8Span(groupLabel, allocator);
        fixed (byte* groupLabelPtr = groupLabelSpan)
        {
            WebGPU_FFI.RenderBundleEncoderPushDebugGroup2(this, new(groupLabelPtr, groupLabelSpan.Length));
        }
    }

    public void SetBindGroup(uint groupIndex, BindGroupHandle group, ReadOnlySpan<uint> dynamicOffset)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffset)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, (nuint)dynamicOffset.Length, dynamicOffsetPtr);
        }
    }

    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffset)
    {
        fixed (uint* dynamicOffsetPtr = dynamicOffset)
        {
            WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, (BindGroupHandle)group, (nuint)dynamicOffset.Length, dynamicOffsetPtr);
        }
    }

    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, (BufferHandle)buffer, format, offset, size);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelSpan = ToUtf8Span(label, allocator);
        fixed (byte* labelPtr = labelSpan)
        {
            WebGPU_FFI.RenderBundleEncoderSetLabel2(this, new(labelPtr, labelSpan.Length));
        }
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        WebGPU_FFI.RenderBundleEncoderSetPipeline(this, (RenderPipelineHandle)pipeline);
    }

    public void SetVertexBuffer(uint slot, Buffer buffer, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, (BufferHandle)buffer, offset, size);
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