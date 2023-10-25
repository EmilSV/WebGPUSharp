using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class CommandBuffer : BaseWebGpuSafeHandle<QueueHandle>
{
    public CommandBuffer(QueueHandle handle) : base(handle)
    {
    }
}