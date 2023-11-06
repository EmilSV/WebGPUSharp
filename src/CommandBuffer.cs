using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class CommandBuffer : BaseWebGpuSafeHandle<CommandBuffer, CommandBufferHandle>
{
    private CommandBuffer(CommandBufferHandle handle) : base(handle)
    {
    }

    internal static CommandBuffer? FromHandle(CommandBufferHandle handle, bool isOwnedHandle)
    {
        var newCommandBuffer = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new CommandBuffer(handle));
        if (isOwnedHandle)
        {
            newCommandBuffer?.AddReference(false);
        }
        return newCommandBuffer;
    }

    public void SetLabel(WGPURefText label) => _handle.SetLabel(label);
}