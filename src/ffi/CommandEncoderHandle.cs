using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle :
    IDisposable, IWebGpuHandle<CommandEncoderHandle, CommandEncoder>
{
    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        RenderPassColorAttachmentFFI* renderPassColorAttachmentFFI = allocator.Alloc<RenderPassColorAttachmentFFI>(
            (nuint)descriptor.ColorAttachments.Length
        );

        ToFFI(descriptor.ColorAttachments, allocator, out RenderPassColorAttachmentFFI colorAttachments, out uint outCount);

        RenderPassTimestampWriteFFI* renderPassTimestampWriteFFI = allocator.Alloc<RenderPassTimestampWriteFFI>(
            (nuint)descriptor.TimestampWrites.Length
        );

        RenderPassDepthStencilAttachmentFFI* depthStencilAttachmentFFI = null;
        if (descriptor.DepthStencilAttachment.HasValue)
        {
            depthStencilAttachmentFFI = allocator.Alloc<RenderPassDepthStencilAttachmentFFI>(1);
            ref readonly RenderPassDepthStencilAttachment depthStencilAttachment = ref descriptor.DepthStencilAttachment.Value;
            *depthStencilAttachmentFFI = new(
                view: depthStencilAttachment.View?.GetHandle() ?? default,
                depthLoadOp: depthStencilAttachment.DepthLoadOp,
                depthStoreOp: depthStencilAttachment.DepthStoreOp,
                depthClearValue: depthStencilAttachment.DepthClearValue,
                depthReadOnly: depthStencilAttachment.DepthReadOnly,
                stencilLoadOp: depthStencilAttachment.StencilLoadOp,
                stencilStoreOp: depthStencilAttachment.StencilStoreOp,
                stencilClearValue: depthStencilAttachment.StencilClearValue,
                stencilReadOnly: depthStencilAttachment.StencilReadOnly
            );
        }

        int length = descriptor.ColorAttachments.Length;
        for (int i = 0; i < length; i++)
        {
            ref readonly RenderPassColorAttachment attachment = ref descriptor.ColorAttachments[i];
            renderPassColorAttachmentFFI[i] = new(
                view: attachment.View?.GetHandle() ?? default,
                resolveTarget: attachment.ResolveTarget?.GetHandle() ?? default,
                clearValue: attachment.ClearValue,
                loadOp: attachment.LoadOp,
                storeOp: attachment.StoreOp
            );
        }

        length = descriptor.TimestampWrites.Length;
        for (int i = 0; i < length; i++)
        {
            ref readonly RenderPassTimestampWrite timestampWrite = ref descriptor.TimestampWrites[i];
            renderPassTimestampWriteFFI[i] = new(
                querySet: timestampWrite.QuerySet.GetHandle(),
                queryIndex: timestampWrite.QueryIndex,
                location: timestampWrite.Location
            );
        }


        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            RenderPassDescriptorFFI descriptorFFI = new(
                label: labelPtr,
                colorAttachmentCount: (uint)descriptor.ColorAttachments.Length,
                colorAttachments: renderPassColorAttachmentFFI,
                depthStencilAttachment: depthStencilAttachmentFFI,
                occlusionQuerySet: descriptor.OcclusionQuerySet?.GetHandle() ?? default,
                timestampWriteCount: (uint)descriptor.TimestampWrites.Length,
                timestampWrites: renderPassTimestampWriteFFI
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
        UFT8CStrFactory utf8Factory = new(allocator);
        fixed (byte* labelPtr = descriptor.label)
        {
            CommandBufferDescriptorFFI commandBufferDescriptor = new()
            {
                Label = utf8Factory.Create(
                    text: labelPtr,
                    is16BitSize: descriptor.label.Is16BitSize,
                    length: descriptor.label.Length,
                    allowPassthrough: true
                ),
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