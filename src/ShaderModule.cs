using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class ShaderModule :
    ShaderModuleBase,
    IFromHandle<ShaderModule, ShaderModuleHandle>
{
    private readonly WebGpuSafeHandle<ShaderModuleHandle> _safeHandle;

    protected override ShaderModuleHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private ShaderModule(ShaderModuleHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<ShaderModuleHandle>(handle);
    }

    static ShaderModule? IFromHandle<ShaderModule, ShaderModuleHandle>.FromHandle(
        ShaderModuleHandle handle)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        ShaderModuleHandle.Reference(handle);
        return new(handle);
    }

    static ShaderModule? IFromHandle<ShaderModule, ShaderModuleHandle>.FromHandleNoRefIncrement(
        ShaderModuleHandle handle)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}