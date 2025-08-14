using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="TexelCopyTextureInfoFFI"/>
public struct TexelCopyTextureInfo :
    IWebGpuFFIConvertibleAlloc<TexelCopyTextureInfo, TexelCopyTextureInfoFFI>
{
    /// <inheritdoc cref="TexelCopyTextureInfoFFI.Texture"/>
    public required Texture Texture;
    /// <inheritdoc cref="TexelCopyTextureInfoFFI.MipLevel"/>
    public uint MipLevel = 0;
    /// <summary>
    /// The base texel of the texture in the selected <see cref="MipLevel" />.
    /// Together with the copySize argument to copy functions, defines the sub-region of the texture to copy.
    /// </summary>
    public Origin3D Origin = new();
    /// <inheritdoc cref="TexelCopyTextureInfoFFI.Aspect"/>
    public TextureAspect Aspect = TextureAspect.All;

    public TexelCopyTextureInfo()
    {
    }

    public static void UnsafeConvertToFFI(in TexelCopyTextureInfo input, WebGpuAllocatorHandle allocator, out TexelCopyTextureInfoFFI dest)
    {
        throw new NotImplementedException();
    }

    static void IWebGpuFFIConvertibleAlloc<TexelCopyTextureInfo, TexelCopyTextureInfoFFI>.UnsafeConvertToFFI(
        in TexelCopyTextureInfo input, WebGpuAllocatorHandle allocator, out TexelCopyTextureInfoFFI dest)
    {
        dest = new()
        {
            Texture = allocator.GetHandle(input.Texture),
            MipLevel = input.MipLevel,
            Origin = input.Origin,
            Aspect = input.Aspect
        };
    }
}