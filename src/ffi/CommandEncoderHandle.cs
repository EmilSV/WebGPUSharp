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

        Unsafe.SkipInit(out RenderPassDepthStencilAttachmentFFI depthStencilAttachmentFFI);
        RenderPassDepthStencilAttachmentFFI* depthStencilAttachmentPtr = null;
        if (descriptor.DepthStencilAttachment.HasValue)
        {
            ref readonly var depthStencilAttachment = ref descriptor.DepthStencilAttachment.Value;
            depthStencilAttachmentFFI = new()
            {
                View = GetBorrowHandle(depthStencilAttachment.View),
                DepthLoadOp = depthStencilAttachment.DepthLoadOp,
                DepthStoreOp = depthStencilAttachment.DepthStoreOp,
                DepthClearValue = depthStencilAttachment.DepthClearValue,
                DepthReadOnly = depthStencilAttachment.DepthReadOnly,
                StencilLoadOp = depthStencilAttachment.StencilLoadOp,
                StencilStoreOp = depthStencilAttachment.StencilStoreOp,
                StencilClearValue = depthStencilAttachment.StencilClearValue,
                StencilReadOnly = depthStencilAttachment.StencilReadOnly
            };
            depthStencilAttachmentPtr = &depthStencilAttachmentFFI;
        }

        var labelUtf8Span = ToUtf8Span(descriptor.label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            PassTimestampWritesFFI timestampWritesFFI;
            PassTimestampWritesFFI* timestampWritesFFIPtr;
            if (descriptor.TimestampWrites.HasValue)
            {
                ref readonly var timestampWrites = ref descriptor.TimestampWrites.Value;
                ToFFI(timestampWrites, out timestampWritesFFI);
                timestampWritesFFIPtr = &timestampWritesFFI;
            }
            else
            {
                timestampWritesFFIPtr = null;
            }


            RenderPassDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                ColorAttachmentCount = colorAttachmentsCount,
                ColorAttachments = colorAttachmentsPtr,
                DepthStencilAttachment = depthStencilAttachmentPtr,
                OcclusionQuerySet = GetBorrowHandle(descriptor.OcclusionQuerySet),
                TimestampWrites = timestampWritesFFIPtr
            };
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

    public void ClearBuffer(Buffer buffer, ulong offset, ulong size)
    {
        ClearBuffer(
            buffer: GetBorrowHandle(buffer),
            offset: offset,
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
            GetBorrowHandle(source),
            sourceOffset,
            GetBorrowHandle(destination),
            destinationOffset,
            size
        );
    }

    public void CopyBufferToTexture(in TexelCopyBufferInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        ToFFI(
            input: source,
            dest: out TexelCopyBufferInfoFFI sourceFFI
        );

        TexelCopyTextureInfoFFI destinationFFI = new()
        {
            Texture = GetBorrowHandle(destination.Texture),
            MipLevel = destination.MipLevel,
            Origin = destination.Origin,
            Aspect = destination.Aspect
        };


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

    public void CopyBufferToTexture(in TexelCopyBufferInfoFFI source, in TexelCopyTextureInfoFFI destination, in Extent3D copySize)
    {
        fixed (TexelCopyBufferInfoFFI* sourcePtr = &source)
        fixed (TexelCopyTextureInfoFFI* destinationPtr = &destination)
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

    public void CopyTextureToBuffer(in TexelCopyTextureInfo source, in TexelCopyBufferInfo destination, in Extent3D copySize)
    {
        TexelCopyTextureInfoFFI sourceFFI = new()
        {
            Texture = GetBorrowHandle(source.Texture),
            MipLevel = source.MipLevel,
            Origin = source.Origin,
            Aspect = source.Aspect
        };

        ToFFI(
            input: destination,
            dest: out TexelCopyBufferInfoFFI destinationFFI
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

    public void CopyTextureToBuffer(in TexelCopyTextureInfoFFI source, in TexelCopyBufferInfoFFI destination, in Extent3D copySize)
    {
        fixed (TexelCopyTextureInfoFFI* sourcePtr = &source)
        fixed (TexelCopyBufferInfoFFI* destinationPtr = &destination)
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

    public void CopyTextureToTexture(
        in TexelCopyTextureInfoFFI source, in TexelCopyTextureInfoFFI destination, in Extent3D copySize)
    {
        fixed (TexelCopyTextureInfoFFI* sourcePtr = &source)
        fixed (TexelCopyTextureInfoFFI* destinationPtr = &destination)
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

    public void CopyTextureToTexture(
        in TexelCopyTextureInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        TexelCopyTextureInfoFFI sourceFFI = new()
        {
            Texture = GetBorrowHandle(source.Texture),
            MipLevel = source.MipLevel,
            Origin = source.Origin,
            Aspect = source.Aspect
        };

        TexelCopyTextureInfoFFI destinationFFI = new()
        {
            Texture = GetBorrowHandle(destination.Texture),
            MipLevel = destination.MipLevel,
            Origin = destination.Origin,
            Aspect = destination.Aspect
        };

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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            CommandBufferDescriptorFFI commandBufferDescriptor = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            };

            return WebGPU_FFI.CommandEncoderFinish(this, &commandBufferDescriptor);
        }
    }

    public CommandBufferHandle Finish()
    {
        return WebGPU_FFI.CommandEncoderFinish(this, null);
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var markerLabelUtf8Span = ToUtf8Span(markerLabel, allocator, addNullTerminator: false);

        fixed (byte* markerLabelPtr = markerLabelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderInsertDebugMarker(this, StringViewFFI.CreateExplicitlySized(markerLabelPtr, markerLabelUtf8Span.Length));
        }
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, addNullTerminator: false);

        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderPushDebugGroup(this, StringViewFFI.CreateExplicitlySized(groupLabelPtr, groupLabelUtf8Span.Length));
        }
    }

    public void ResolveQuerySet(
        QuerySet querySet, uint firstQuery, uint queryCount,
        Buffer destination, ulong destinationOffset)
    {
        WebGPU_FFI.CommandEncoderResolveQuerySet(
            commandEncoder: this,
            querySet: GetBorrowHandle(querySet),
            firstQuery: firstQuery,
            queryCount: queryCount,
            destination: GetBorrowHandle(destination),
            destinationOffset: destinationOffset
        );
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }

    [Obsolete("", false)]
    public void WriteTimestamp(QuerySet querySet, uint queryIndex)
    {
        WebGPU_FFI.CommandEncoderWriteTimestamp(
           commandEncoder: this,
           querySet: GetBorrowHandle(querySet),
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
        WebGPU_FFI.CommandEncoderAddRef(handle);
    }

    public static void Release(CommandEncoderHandle handle)
    {
        WebGPU_FFI.CommandEncoderRelease(handle);
    }
}