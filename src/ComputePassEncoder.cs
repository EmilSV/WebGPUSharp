using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class ComputePassEncoder :
    BaseWebGpuSafeHandle<ComputePassEncoder, ComputePassEncoderHandle>
{
    private ComputePassEncoder(ComputePassEncoderHandle handle) : base(handle)
    {
    }

    internal static ComputePassEncoder? FromHandle(ComputePassEncoderHandle handle, bool isOwnedHandle)
    {
        var newComputePassEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new ComputePassEncoder(handle));
        if (isOwnedHandle)
        {
            newComputePassEncoder?.AddReference(false);
        }
        return newComputePassEncoder;
    }
}