using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class CommandEncoder : BaseWebGpuSafeHandle<CommandEncoder, CommandEncoderHandle>
{
    private CommandEncoder(CommandEncoderHandle handle) : base(handle)
    {
    }

    internal static CommandEncoder? FromHandle(CommandEncoderHandle handle, bool isOwnedHandle)
    {
        var newCommandEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new CommandEncoder(handle));
        if (isOwnedHandle)
        {
            newCommandEncoder?.AddReference(false);
        }
        return newCommandEncoder;
    }

    public RenderPassEncoder? BeginRenderPass(in RenderPassDescriptor descriptor) =>
        RenderPassEncoder.FromHandle(_handle.BeginRenderPass(descriptor), true);

    public void CopyBufferToBuffer(
        Buffer source,
        ulong sourceOffset,
        Buffer destination,
        ulong destinationOffset,
        ulong size
    ) => _handle.CopyBufferToBuffer(
        source.GetHandle(),
        sourceOffset,
        destination.GetHandle(),
        destinationOffset,
        size
    );

    public CommandBufferHandle Finish(in CommandBufferDescriptor descriptor) =>
        _handle.Finish(descriptor);
}