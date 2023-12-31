using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderBundleEncoderHandle :
IDisposable, IWebGpuHandle<RenderBundleEncoderHandle, RenderBundleEncoder>
{
    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance)
    {
        WebGPU_FFI.RenderBundleEncoderDraw(this, vertexCount, instanceCount, firstVertex, firstInstance);
    }

    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);
    }

    public void DrawIndexedIndirect(BufferHandle indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, indirectBuffer, indirectOffset);
    }

    public void DrawIndexedIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, (BufferHandle)indirectBuffer, indirectOffset);
    }

    public void DrawIndirect(BufferHandle indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, indirectBuffer, indirectOffset);
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
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            RenderBundleDescriptorFFI descriptorFFI = new RenderBundleDescriptorFFI(labelPtr);
            return WebGPU_FFI.RenderBundleEncoderFinish(this, &descriptorFFI);
        }
    }

    public void InsertDebugMarker(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.RenderBundleEncoderInsertDebugMarker(this, labelPtr);
        }
    }

    public void PopDebugGroup()
    {
        WebGPU_FFI.RenderBundleEncoderPopDebugGroup(this);
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* groupLabelPtr = ToRefCstrUtf8(groupLabel, allocator))
        {
            WebGPU_FFI.RenderBundleEncoderPushDebugGroup(this, groupLabelPtr);
        }
    }

    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets)
    {
        WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);
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

    public void SetIndexBuffer(BufferHandle buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, buffer, format, offset, size);
    }

    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, (BufferHandle)buffer, format, offset, size);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.RenderBundleEncoderSetLabel(this, labelPtr);
        }
    }

    public void SetPipeline(RenderPipelineHandle pipeline)
    {
        WebGPU_FFI.RenderBundleEncoderSetPipeline(this, pipeline);
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        WebGPU_FFI.RenderBundleEncoderSetPipeline(this, (RenderPipelineHandle)pipeline);
    }

    public void SetVertexBuffer(uint slot, BufferHandle buffer, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, buffer, offset, size);
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
        WebGPU_FFI.RenderBundleEncoderReference(handle);
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