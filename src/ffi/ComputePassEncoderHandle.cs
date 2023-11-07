using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct ComputePassEncoderHandle :
    IDisposable, IWebGpuHandle<ComputePassEncoderHandle>
{
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ)
    {
        WebGPU_FFI.ComputePassEncoderDispatchWorkgroups(
            computePassEncoder: this,
            workgroupCountX: workgroupCountX,
            workgroupCountY: workgroupCountY,
            workgroupCountZ: workgroupCountZ
        );
    }

    public void DispatchWorkgroupsIndirect(BufferHandle indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.ComputePassEncoderDispatchWorkgroupsIndirect(
            computePassEncoder: this,
            indirectBuffer: indirectBuffer,
            indirectOffset: indirectOffset
        );
    }

    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.ComputePassEncoderDispatchWorkgroupsIndirect(
            computePassEncoder: this,
            indirectBuffer: (BufferHandle)indirectBuffer,
            indirectOffset: indirectOffset
        );
    }

    public void End()
    {
        WebGPU_FFI.ComputePassEncoderEnd(
            computePassEncoder: this
        );
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* markerLabelPtr = WebGPUMarshal.ToRefCstrUtf8(markerLabel, allocator))
        {
            WebGPU_FFI.ComputePassEncoderInsertDebugMarker(
                computePassEncoder: this,
                markerLabel: markerLabelPtr
            );
        }
    }

    public void PopDebugGroup()
    {
        WebGPU_FFI.ComputePassEncoderPopDebugGroup(
            computePassEncoder: this
        );
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* groupLabelPtr = WebGPUMarshal.ToRefCstrUtf8(groupLabel, allocator))
        {
            WebGPU_FFI.ComputePassEncoderPushDebugGroup(
                computePassEncoder: this,
                groupLabel: groupLabelPtr
            );
        }
    }

    public void SetBindGroup(
        uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets)
    {
        WebGPU_FFI.ComputePassEncoderSetBindGroup(
            computePassEncoder: this,
            groupIndex: groupIndex,
            group: group,
            dynamicOffsetCount: dynamicOffsetCount,
            dynamicOffsets: dynamicOffsets
        );
    }

    public void SetBindGroup(
        uint groupIndex, BindGroup group, nuint dynamicOffsetCount, uint* dynamicOffsets)
    {
        WebGPU_FFI.ComputePassEncoderSetBindGroup(
            computePassEncoder: this,
            groupIndex: groupIndex,
            group: (BindGroupHandle)group,
            dynamicOffsetCount: dynamicOffsetCount,
            dynamicOffsets: dynamicOffsets
        );

    }


    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = WebGPUMarshal.ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.ComputePassEncoderSetLabel(
                computePassEncoder: this,
                label: labelPtr
            );
        }
    }

    public void SetPipeline(ComputePipelineHandle pipeline)
    {
        WebGPU_FFI.ComputePassEncoderSetPipeline(
            computePassEncoder: this,
            pipeline: pipeline
        );
    }


    
    public void SetPipeline(ComputePipeline pipeline)
    {
        WebGPU_FFI.ComputePassEncoderSetPipeline(
            computePassEncoder: this,
            pipeline: (ComputePipelineHandle)pipeline
        );
    }


    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.ComputePassEncoderRelease(this);
        }
    }

    public ComputePassEncoder? ToSafeHandle(bool isOwnedHandle)
    {
        return ComputePassEncoder.FromHandle(this, isOwnedHandle);
    }

    public static ref UIntPtr AsPointer(ref ComputePassEncoderHandle handle)
    {
        return ref Unsafe.As<ComputePassEncoderHandle, UIntPtr>(ref handle);
    }

    public static bool IsNull(ComputePassEncoderHandle handle)
    {
        return handle == Null;
    }

    public static ComputePassEncoderHandle UnsafeFromPointer(nuint pointer)
    {
        return new ComputePassEncoderHandle(pointer);
    }

    public static void Reference(ComputePassEncoderHandle handle)
    {
        WebGPU_FFI.ComputePassEncoderReference(handle);
    }

    public static void Release(ComputePassEncoderHandle handle)
    {
        WebGPU_FFI.ComputePassEncoderRelease(handle);
    }
}