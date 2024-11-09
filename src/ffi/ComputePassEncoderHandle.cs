using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct ComputePassEncoderHandle :
    IDisposable, IWebGpuHandle<ComputePassEncoderHandle>
{
    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        WebGPU_FFI.ComputePassEncoderDispatchWorkgroupsIndirect(
            computePassEncoder: this,
            indirectBuffer: GetBorrowHandle(indirectBuffer),
            indirectOffset: indirectOffset
        );
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var markerLabelUtf8Span = ToUtf8Span(markerLabel, allocator, false);
        fixed (byte* markerLabelPtr = markerLabelUtf8Span)
        {
            WebGPU_FFI.ComputePassEncoderInsertDebugMarker2(
                computePassEncoder: this,
                markerLabel: new(markerLabelPtr, markerLabelUtf8Span.Length)
            );
        }
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, false);
        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.ComputePassEncoderPushDebugGroup2(
                computePassEncoder: this,
                groupLabel: new(groupLabelPtr, groupLabelUtf8Span.Length)
            );
        }
    }

    public void SetBindGroup(
        uint groupIndex, BindGroupHandle group, ReadOnlySpan<uint> dynamicOffsets)
    {
        fixed (uint* dynamicOffsetsPtr = dynamicOffsets)
        {
            WebGPU_FFI.ComputePassEncoderSetBindGroup(
                computePassEncoder: this,
                groupIndex: groupIndex,
                group: group,
                dynamicOffsetCount: (nuint)dynamicOffsets.Length,
                dynamicOffsets: dynamicOffsetsPtr
            );
        }
    }

    public void SetBindGroup(
        uint groupIndex, BindGroup group, nuint dynamicOffsetCount, uint* dynamicOffsets)
    {
        WebGPU_FFI.ComputePassEncoderSetBindGroup(
            computePassEncoder: this,
            groupIndex: groupIndex,
            group: GetBorrowHandle(group),
            dynamicOffsetCount: dynamicOffsetCount,
            dynamicOffsets: dynamicOffsets
        );

    }

    public void SetBindGroup(
        uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        fixed (uint* dynamicOffsetsPtr = dynamicOffsets)
        {
            WebGPU_FFI.ComputePassEncoderSetBindGroup(
                computePassEncoder: this,
                groupIndex: groupIndex,
                group: GetBorrowHandle(group),
                dynamicOffsetCount: (nuint)dynamicOffsets.Length,
                dynamicOffsets: dynamicOffsetsPtr
            );
        }
    }



    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.ComputePassEncoderSetLabel2(
                computePassEncoder: this,
                label: new(labelPtr, labelUtf8Span.Length)
            );
        }
    }

    public void SetPipeline(ComputePipeline pipeline)
    {
        WebGPU_FFI.ComputePassEncoderSetPipeline(
            computePassEncoder: this,
            pipeline: GetBorrowHandle(pipeline)
        );
    }


    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.ComputePassEncoderRelease(this);
        }
    }

    public ComputePassEncoder? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<ComputePassEncoder, ComputePassEncoderHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<ComputePassEncoder, ComputePassEncoderHandle>(this);
        }
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
        WebGPU_FFI.ComputePassEncoderAddRef(handle);
    }

    public static void Release(ComputePassEncoderHandle handle)
    {
        WebGPU_FFI.ComputePassEncoderRelease(handle);
    }
}