using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderPassEncoderHandle :
    IDisposable, IWebGpuHandle<RenderPassEncoderHandle, RenderPassEncoder>
{

    public readonly void SetPipeline(RenderPipeline pipeline) =>
        SetPipeline(ToFFI<RenderPipeline, RenderPipelineHandle>(pipeline));

    public readonly void SetPipeline(RenderPipelineHandle pipeline) =>
        WebGPU_FFI.RenderPassEncoderSetPipeline(this, pipeline);

    public readonly void Draw(
        uint vertexCount, uint instanceCount,
        uint firstVertex, uint firstInstance)
    {
        WebGPU_FFI.RenderPassEncoderDraw(
            renderPassEncoder: this,
            vertexCount: vertexCount,
            instanceCount: instanceCount,
            firstVertex: firstVertex,
            firstInstance: firstInstance
        );
    }


    public readonly void SetVertexBuffer(
        uint slot, BufferHandle buffer, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderPassEncoderSetVertexBuffer(
            renderPassEncoder: this,
            slot: slot,
            buffer: buffer,
            offset: offset,
            size: size
        );
    }

    public readonly void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        SetVertexBuffer(slot, (BufferHandle)buffer, offset, size);
    }


    public readonly void SetIndexBuffer(
        BufferHandle buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderPassEncoderSetIndexBuffer(
            renderPassEncoder: this,
            buffer: buffer,
            format: format,
            offset: offset,
            size: size
        );
    }

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


    public readonly void SetBindGroup(uint groupIndex, BindGroup group)
    {
        SetBindGroup(groupIndex, (BindGroupHandle)group);
    }
    public readonly void SetBindGroup(uint groupIndex, BindGroup group, uint dynamicOffset)
    {
        SetBindGroup(groupIndex, (BindGroupHandle)group, dynamicOffset);
    }
    public readonly void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        SetBindGroup(groupIndex, (BindGroupHandle)group, dynamicOffsets);
    }

    public readonly void End()
    {
        WebGPU_FFI.RenderPassEncoderEnd(this);
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.RenderPassEncoderRelease(this);
        }
    }

    public void DrawIndexed(
        uint indexCount, uint instanceCount,
        uint firstIndex, int baseVertex, uint firstInstance)
    {
        unsafe
        {
            WebGPU_FFI.RenderPassEncoderDrawIndexed(
                renderPassEncoder: this,
                indexCount: indexCount,
                instanceCount: instanceCount,
                firstIndex: firstIndex,
                baseVertex: baseVertex,
                firstInstance: firstInstance
            );
        }
    }

    public static ref nuint AsPointer(ref RenderPassEncoderHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
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
        WebGPU_FFI.RenderPassEncoderReference(handle);
    }

    public static void Release(RenderPassEncoderHandle handle)
    {
        WebGPU_FFI.RenderPassEncoderRelease(handle);
    }

    public RenderPassEncoder? ToSafeHandle(bool isOwnedHandle)
    {
        return RenderPassEncoder.FromHandle(this, isOwnedHandle);
    }
}