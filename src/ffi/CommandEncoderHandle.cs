using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle :
    IDisposable, IWebGpuHandle<CommandEncoderHandle>
{
    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        ToFFI(
            input: descriptor.ColorAttachments,
            allocator: allocator,
            dest: out RenderPassColorAttachmentFFI* colorAttachmentsPtr,
            outCount: out nuint colorAttachmentsCount
        );
        ToFFI(
            input: descriptor.TimestampWrites,
            allocator: allocator,
            dest: out RenderPassTimestampWriteFFI* timestampWritePtr,
            outCount: out nuint timestampWriteCount
        );

        Unsafe.SkipInit(out RenderPassDepthStencilAttachmentFFI depthStencilAttachmentFFI);
        RenderPassDepthStencilAttachmentFFI* depthStencilAttachmentPtr = null;
        if (descriptor.DepthStencilAttachment.HasValue)
        {
            ref readonly var depthStencilAttachment = ref descriptor.DepthStencilAttachment.Value;

            depthStencilAttachmentFFI = new(
                view: depthStencilAttachment.View.GetHandle(),
                depthLoadOp: depthStencilAttachment.DepthLoadOp,
                depthStoreOp: depthStencilAttachment.DepthStoreOp,
                depthClearValue: depthStencilAttachment.DepthClearValue,
                depthReadOnly: depthStencilAttachment.DepthReadOnly,
                stencilLoadOp: depthStencilAttachment.StencilLoadOp,
                stencilStoreOp: depthStencilAttachment.StencilStoreOp,
                stencilClearValue: depthStencilAttachment.StencilClearValue,
                stencilReadOnly: depthStencilAttachment.StencilReadOnly
            );
            depthStencilAttachmentPtr = &depthStencilAttachmentFFI;
        }

        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            RenderPassDescriptorFFI descriptorFFI = new(
                label: labelPtr,
                colorAttachmentCount: colorAttachmentsCount,
                colorAttachments: colorAttachmentsPtr,
                depthStencilAttachment: depthStencilAttachmentPtr,
                occlusionQuerySet: ToFFI<QuerySet, QuerySetHandle>(descriptor.OcclusionQuerySet),
                timestampWriteCount: timestampWriteCount,
                timestampWrites: timestampWritePtr
            );
            return BeginRenderPass(in descriptorFFI);
        }
    }

    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptorFFI descriptor)
    {
        fixed (RenderPassDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.CommandEncoderBeginRenderPass(this, descriptorPtr);
        }
    }

    public void ClearBuffer(BufferHandle buffer, ulong offset, ulong size)
    {
        WebGPU_FFI.CommandEncoderClearBuffer(
            commandEncoder: this,
            buffer: buffer,
            offset: offset,
            size: size
        );
    }

    public void ClearBuffer(Buffer buffer, ulong offset, ulong size)
    {
        ClearBuffer(
            buffer: (BufferHandle)buffer,
            offset: offset,
            size: size
        );
    }


    public void CopyBufferToBuffer(
        BufferHandle source, ulong sourceOffset,
        BufferHandle destination, ulong destinationOffset,
        ulong size
    )
    {
        WebGPU_FFI.CommandEncoderCopyBufferToBuffer(
            commandEncoder: this,
            source: source,
            sourceOffset: sourceOffset,
            destination: destination,
            destinationOffset: destinationOffset,
            size: size
        );
    }


    public void CopyBufferToBuffer(
        Buffer source, ulong sourceOffset,
        Buffer destination, ulong destinationOffset,
        ulong size
    )
    {
        CopyBufferToBuffer(
            (BufferHandle)source,
            sourceOffset,
            (BufferHandle)destination,
            destinationOffset,
            size
        );
    }

    public void CopyBufferToTexture(in ImageCopyBuffer source, in ImageCopyTexture destination, in Extent3D copySize)
    {
        ToFFI(
            input: source,
            dest: out ImageCopyBufferFFI sourceFFI
        );

        ToFFI(
            input: destination,
            dest: out ImageCopyTextureFFI destinationFFI
        );

        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyBufferToTexture(
                commandEncoder: this,
                source: &sourceFFI,
                destination: &destinationFFI,
                copySize: copySizePtr
            );
        }
    }

    public void CopyBufferToTexture(in ImageCopyBufferFFI source, in ImageCopyTextureFFI destination, in Extent3D copySize)
    {
        fixed (ImageCopyBufferFFI* sourcePtr = &source)
        fixed (ImageCopyTextureFFI* destinationPtr = &destination)
        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyBufferToTexture(
                commandEncoder: this,
                source: sourcePtr,
                destination: destinationPtr,
                copySize: copySizePtr
            );
        }
    }

    public void CopyTextureToBuffer(in ImageCopyTexture source, in ImageCopyBuffer destination, in Extent3D copySize)
    {
        ToFFI(
            input: source,
            dest: out ImageCopyTextureFFI sourceFFI
        );

        ToFFI(
            input: destination,
            dest: out ImageCopyBufferFFI destinationFFI
        );
        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyTextureToBuffer(
                commandEncoder: this,
                source: &sourceFFI,
                destination: &destinationFFI,
                copySize: copySizePtr
            );
        }
    }

    public void CopyTextureToBuffer(in ImageCopyTextureFFI source, in ImageCopyBufferFFI destination, in Extent3D copySize)
    {
        fixed (ImageCopyTextureFFI* sourcePtr = &source)
        fixed (ImageCopyBufferFFI* destinationPtr = &destination)
        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyTextureToBuffer(
                commandEncoder: this,
                source: sourcePtr,
                destination: destinationPtr,
                copySize: copySizePtr
            );
        }
    }

    public void CommandEncoderCopyTextureToTexture(
        in ImageCopyTextureFFI source, in ImageCopyTextureFFI destination, in Extent3D copySize)
    {
        fixed (ImageCopyTextureFFI* sourcePtr = &source)
        fixed (ImageCopyTextureFFI* destinationPtr = &destination)
        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyTextureToTexture(
                commandEncoder: this,
                source: sourcePtr,
                destination: destinationPtr,
                copySize: copySizePtr
            );
        }
    }

    public void CommandEncoderCopyTextureToTexture(
        in ImageCopyTexture source, in ImageCopyTexture destination, in Extent3D copySize)
    {
        ToFFI(source, out ImageCopyTextureFFI sourceFFI);
        ToFFI(destination, out ImageCopyTextureFFI destinationFFI);

        fixed (Extent3D* copySizePtr = &copySize)
        {
            WebGPU_FFI.CommandEncoderCopyTextureToTexture(
                commandEncoder: this,
                source: &sourceFFI,
                destination: &destinationFFI,
                copySize: copySizePtr
            );
        }
    }


    public CommandBufferHandle Finish(in CommandBufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            CommandBufferDescriptorFFI commandBufferDescriptor = new(
                label: labelPtr
            );

            return WebGPU_FFI.CommandEncoderFinish(this, &commandBufferDescriptor);
        }
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* markerLabelPtr = ToRefCstrUtf8(markerLabel, allocator))
        {
            WebGPU_FFI.CommandEncoderInsertDebugMarker(this, markerLabelPtr);
        }
    }

    public void PopDebugGroup()
    {
        WebGPU_FFI.CommandEncoderPopDebugGroup(this);
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* groupLabelPtr = ToRefCstrUtf8(groupLabel, allocator))
        {
            WebGPU_FFI.CommandEncoderPushDebugGroup(this, groupLabelPtr);
        }
    }

    public void ResolveQuerySet(
        QuerySetHandle querySet, uint firstQuery, uint queryCount,
        BufferHandle destination, ulong destinationOffset)
    {
        WebGPU_FFI.CommandEncoderResolveQuerySet(
            commandEncoder: this,
            querySet: querySet,
            firstQuery: firstQuery,
            queryCount: queryCount,
            destination: destination,
            destinationOffset: destinationOffset
        );
    }


    public void ResolveQuerySet(
        QuerySet querySet, uint firstQuery, uint queryCount,
        Buffer destination, ulong destinationOffset)
    {
        WebGPU_FFI.CommandEncoderResolveQuerySet(
            commandEncoder: this,
            querySet: (QuerySetHandle)querySet,
            firstQuery: firstQuery,
            queryCount: queryCount,
            destination: (BufferHandle)destination,
            destinationOffset: destinationOffset
        );
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.CommandEncoderSetLabel(this, labelPtr);
        }
    }

    public void WriteTimestamp(QuerySetHandle querySet, uint queryIndex)
    {
        WebGPU_FFI.CommandEncoderWriteTimestamp(
           commandEncoder: this,
           querySet: querySet,
           queryIndex: queryIndex
       );
    }

    public void WriteTimestamp(QuerySet querySet, uint queryIndex)
    {
        WebGPU_FFI.CommandEncoderWriteTimestamp(
           commandEncoder: this,
           querySet: (QuerySetHandle)querySet,
           queryIndex: queryIndex
       );
    }


    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.CommandEncoderRelease(this);
        }
    }

    public static ref nuint AsPointer(ref CommandEncoderHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static CommandEncoderHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(CommandEncoderHandle handle)
    {
        return handle == Null;
    }

    public static CommandEncoderHandle UnsafeFromPointer(nuint pointer)
    {
        return new CommandEncoderHandle(pointer);
    }

    public CommandEncoder ToSafeHandle()
    {
        return CommandEncoder.FromHandle(this);
    }

    public static void Reference(CommandEncoderHandle handle)
    {
        WebGPU_FFI.CommandEncoderReference(handle);
    }

    public static void Release(CommandEncoderHandle handle)
    {
        WebGPU_FFI.CommandEncoderRelease(handle);
    }
}