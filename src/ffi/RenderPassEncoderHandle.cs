using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderPassEncoderHandle :
    IDisposable, IWebGpuHandle<RenderPassEncoderHandle>
{
    public void DrawIndexedIndirect(
        Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.RenderPassEncoderDrawIndexedIndirect(
            renderPassEncoder: this,
            indirectBuffer: (BufferHandle)indirectBuffer,
            indirectOffset: indirectOffset
        );
    }

    public void DrawIndirect(
        Buffer indirectBuffer, ulong indirectOffset)

    {
        WebGPU_FFI.RenderPassEncoderDrawIndirect(
            renderPassEncoder: this,
            indirectBuffer: (BufferHandle)indirectBuffer,
            indirectOffset: indirectOffset
        );
    }

    public void ExecuteBundle(RenderBundleHandle bundle)
    {
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: 1,
            bundles: &bundle
        );
    }

    public void ExecuteBundle(RenderBundle bundle)
    {
        RenderBundleHandle handle = (RenderBundleHandle)bundle;
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: 1,
            bundles: &handle
        );
    }

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

    public void ExecuteBundles(ReadOnlySpan<RenderBundle> bundles)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        ToFFI(bundles, allocator, out RenderBundleHandle* bundlesPtr, out nuint bundlesLength);
        WebGPU_FFI.RenderPassEncoderExecuteBundles(
            renderPassEncoder: this,
            bundleCount: bundlesLength,
            bundles: bundlesPtr
        );
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* markerLabelPtr = ToRefCstrUtf8(markerLabel, allocator))
        {
            WebGPU_FFI.RenderPassEncoderInsertDebugMarker(
                renderPassEncoder: this,
                markerLabel: markerLabelPtr
            );
        }
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* groupLabelPtr = ToRefCstrUtf8(groupLabel, allocator))
        {
            WebGPU_FFI.RenderPassEncoderPushDebugGroup(
                renderPassEncoder: this,
                groupLabel: groupLabelPtr
            );
        }
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


    public void SetBlendConstant(in Color color)
    {
        fixed (Color* colorPtr = &color)
        {
            WebGPU_FFI.RenderPassEncoderSetBlendConstant(this, colorPtr);
        }
    }

    public readonly void SetIndexBuffer(
        Buffer buffer, IndexFormat format, ulong offset, ulong size)
    {
        WebGPU_FFI.RenderPassEncoderSetIndexBuffer(
            renderPassEncoder: this,
            buffer: (BufferHandle)buffer,
            format: format,
            offset: offset,
            size: size
        );
    }

    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.RenderPassEncoderSetLabel(
                renderPassEncoder: this,
                label: labelPtr
            );
        }
    }

    public readonly void SetPipeline(RenderPipeline pipeline) =>
        SetPipeline(ToFFI<RenderPipeline, RenderPipelineHandle>(pipeline));

    public readonly void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        SetVertexBuffer(slot, (BufferHandle)buffer, offset, size);
    }


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