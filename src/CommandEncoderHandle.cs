using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle : IDisposable, IWebGpuHandle<CommandEncoderHandle>
{
    public RenderPassEncoderHandle BeginRenderPass(in RenderPassDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        UFT8CStrFactory utf8Factory = new(allocator);

        fixed (byte* labelPtr = descriptor.label)
        fixed (RenderPassColorAttachmentFFI* colorAttachmentsPtr = descriptor.ColorAttachments)
        fixed (RenderPassDepthStencilAttachmentFFI* depthStencilAttachmentPtr = &descriptor.DepthStencilAttachment)
        {
            RenderPassDescriptorFFI renderPassDescriptor = new()
            {
                Label = utf8Factory.Create(
                    text: labelPtr,
                    length: descriptor.label.Length,
                    is16BitSize: descriptor.label.Is16BitSize,
                    allowPassthrough: true
                ),
                ColorAttachmentCount = (uint)descriptor.ColorAttachments.Length,
                ColorAttachments = colorAttachmentsPtr,
                DepthStencilAttachment = depthStencilAttachmentPtr,
            };

            return WebGPU_FFI.CommandEncoderBeginRenderPass(this, &renderPassDescriptor);
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
}