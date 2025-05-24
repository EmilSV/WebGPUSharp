using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="ComputePassEncoderHandle"/>
public sealed class ComputePassEncoder :
    ComputePassEncoderBase,
    IFromHandle<ComputePassEncoder, ComputePassEncoderHandle>
{
    private readonly WebGpuSafeHandle<ComputePassEncoderHandle> _safeHandle;

    protected override ComputePassEncoderHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private ComputePassEncoder(ComputePassEncoderHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<ComputePassEncoderHandle>(handle);
    }

    static ComputePassEncoder? IFromHandle<ComputePassEncoder, ComputePassEncoderHandle>.FromHandle(
        ComputePassEncoderHandle handle)
    {
        if (ComputePassEncoderHandle.IsNull(handle))
        {
            return null;
        }

        ComputePassEncoderHandle.Reference(handle);
        return new(handle);
    }

    static ComputePassEncoder? IFromHandle<ComputePassEncoder, ComputePassEncoderHandle>.FromHandleNoRefIncrement(
        ComputePassEncoderHandle handle)
    {
        if (ComputePassEncoderHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}