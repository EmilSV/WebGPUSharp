using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <summary>
/// Handle to a texture on the GPU.
/// 
/// It can be created with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
/// </summary>
public sealed class Texture :
    TextureBase,
    IFromHandle<Texture, TextureHandle>
{
    /// <inheritdoc cref="WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED"/>
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    private readonly WebGpuSafeHandle<TextureHandle> _safeHandle;

    private Texture(TextureHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<TextureHandle>(handle);
    }

    protected override TextureHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    static Texture? IFromHandle<Texture, TextureHandle>.FromHandle(
        TextureHandle handle)
    {
        if (TextureHandle.IsNull(handle))
        {
            return null;
        }

        TextureHandle.Reference(handle);
        return new(handle);
    }

    static Texture? IFromHandle<Texture, TextureHandle>.FromHandleNoRefIncrement(
        TextureHandle handle)
    {
        if (TextureHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}
