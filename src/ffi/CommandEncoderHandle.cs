using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle :
    IDisposable, IWebGpuHandle<CommandEncoderHandle, CommandEncoder>
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
                view: ToFFI<TextureView, TextureViewHandle>(depthStencilAttachment.View),
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

    public void CopyBufferToBuffer(
        BufferHandle source,
        ulong sourceOffset,
        BufferHandle destination,
        ulong destinationOffset,
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

    public CommandBufferHandle Finish(in CommandBufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            CommandBufferDescriptorFFI commandBufferDescriptor = new()
            {
                Label = labelPtr,
            };

            return WebGPU_FFI.CommandEncoderFinish(this, &commandBufferDescriptor);
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
        return ref Unsafe.AsRef(handle._ptr);
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

    public CommandEncoder? ToSafeHandle(bool incrementReferenceCount)
    {
        return CommandEncoder.FromHandle(this, incrementReferenceCount);
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