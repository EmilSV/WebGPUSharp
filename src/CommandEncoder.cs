using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class CommandEncoder : WebGpuSafeHandle<CommandEncoderHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<CommandEncoderHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<CommandEncoderHandle> Create(CommandEncoderHandle handle)
        {
            return new CommandEncoder(handle);
        }
    }

    private CommandEncoder(CommandEncoderHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.CommandEncoderReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.CommandEncoderRelease(_handle);
    }

    internal static CommandEncoder? FromHandle(CommandEncoderHandle handle, bool incrementReferenceCount = true)
    {
        var newCommandEncoder = WebGpuSafeHandleCache<CommandEncoderHandle>.GetOrCreate<CacheFactory>(handle) as CommandEncoder;
        if (incrementReferenceCount && newCommandEncoder != null)
        {
            newCommandEncoder.AddReference(false);
        }
        return newCommandEncoder;
    }

    public RenderPassEncoder? BeginRenderPass(in RenderPassDescriptor descriptor) =>
        RenderPassEncoder.FromHandle(_handle.BeginRenderPass(descriptor));

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