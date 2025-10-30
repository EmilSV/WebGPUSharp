using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle :
    IDisposable, IWebGpuHandle<CommandEncoderHandle>
{
    /// <inheritdoc cref="BeginComputePass(ComputePassDescriptorFFI*)"/>
    [SkipLocalsInit]
    public ComputePassEncoderHandle BeginComputePass(in ComputePassDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 256 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );
        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            PassTimestampWritesFFI timestampWritesFFI;
            PassTimestampWritesFFI* timestampWritesFFIPtr;
            if (descriptor.TimestampWrites.HasValue)
            {
                ref readonly var timestampWrites = ref Nullable.GetValueRefOrDefaultRef(in descriptor.TimestampWrites);
                ToFFI(timestampWrites, out timestampWritesFFI);
                timestampWritesFFIPtr = &timestampWritesFFI;
            }
            else
            {
                timestampWritesFFIPtr = null;
            }

            ComputePassDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                TimestampWrites = timestampWritesFFIPtr
            };
            return BeginComputePass(in descriptorFFI);
        }
    }
    /// <inheritdoc cref="BeginComputePass(ComputePassDescriptorFFI*)"/>
    public ComputePassEncoderHandle BeginComputePass(in ComputePassDescriptorFFI descriptor)
    {
        fixed (ComputePassDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.CommandEncoderBeginComputePass(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="BeginRenderPass(RenderPassDescriptorFFI*)"/>
    [SkipLocalsInit]
    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 512 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

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
            ref readonly var depthStencilAttachment = ref Nullable.GetValueRefOrDefaultRef(in descriptor.DepthStencilAttachment);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            PassTimestampWritesFFI timestampWritesFFI;
            PassTimestampWritesFFI* timestampWritesFFIPtr;
            if (descriptor.TimestampWrites.HasValue)
            {
                ref readonly var timestampWrites = ref Nullable.GetValueRefOrDefaultRef(in descriptor.TimestampWrites);
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

    /// <inheritdoc cref="BeginRenderPass(RenderPassDescriptorFFI*)"/>
    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptorFFI descriptor)
    {
        fixed (RenderPassDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.CommandEncoderBeginRenderPass(this, descriptorPtr);
        }
    }


    /// <inheritdoc cref="ClearBuffer(BufferHandle, ulong, ulong)"/>
    public void ClearBuffer(Buffer buffer, ulong offset, ulong size)
    {
        ClearBuffer(
            buffer: GetBorrowHandle(buffer),
            offset: offset,
            size: size
        );
    }

    /// <inheritdoc cref="CopyBufferToBuffer(BufferHandle, ulong, BufferHandle, ulong, ulong)"/>
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

    /// <inheritdoc cref="CopyBufferToTexture(TexelCopyBufferInfoFFI*, TexelCopyTextureInfoFFI*, Extent3D*)"/>
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

    /// <inheritdoc cref="CopyBufferToTexture(TexelCopyBufferInfoFFI*, TexelCopyTextureInfoFFI*, Extent3D*)"/>
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

    /// <inheritdoc cref="CopyTextureToBuffer(TexelCopyTextureInfoFFI*, TexelCopyBufferInfoFFI*, Extent3D*)"/>
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
    /// <inheritdoc cref="CopyTextureToBuffer(TexelCopyTextureInfoFFI*, TexelCopyBufferInfoFFI*, Extent3D*)"/>
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

    /// <inheritdoc cref="CopyTextureToTexture(TexelCopyTextureInfoFFI*, TexelCopyTextureInfoFFI*, Extent3D*)"/>
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

    /// <inheritdoc cref="CopyTextureToTexture(TexelCopyTextureInfoFFI*, TexelCopyTextureInfoFFI*, Extent3D*)"/>
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


    /// <inheritdoc cref="Finish(CommandBufferDescriptorFFI*)"/>
    public CommandBufferHandle Finish(in CommandBufferDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

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

    /// <inheritdoc cref="Finish(CommandBufferDescriptorFFI*)"/>
    public CommandBufferHandle Finish()
    {
        return WebGPU_FFI.CommandEncoderFinish(this, null);
    }

    /// <inheritdoc cref="InsertDebugMarker(StringViewFFI)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var markerLabelUtf8Span = ToUtf8Span(markerLabel, allocator, addNullTerminator: false);

        fixed (byte* markerLabelPtr = markerLabelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderInsertDebugMarker(this, StringViewFFI.CreateExplicitlySized(markerLabelPtr, markerLabelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref="PushDebugGroup(StringViewFFI)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var groupLabelUtf8Span = ToUtf8Span(groupLabel, allocator, addNullTerminator: false);

        fixed (byte* groupLabelPtr = groupLabelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderPushDebugGroup(this, StringViewFFI.CreateExplicitlySized(groupLabelPtr, groupLabelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref="ResolveQuerySet(QuerySetHandle, uint, uint, BufferHandle, ulong)"/>
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

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.CommandEncoderSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
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