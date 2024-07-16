using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyTexture :
    IWebGpuFFIConvertibleAlloc<ImageCopyTexture, ImageCopyTextureFFI>
{
    public required ITextureSource Texture;
    public uint MipLevel = 0;
    public Origin3D Origin;
    public TextureAspect Aspect = TextureAspect.All;

    public ImageCopyTexture()
    {
    }

    static void IWebGpuFFIConvertibleAlloc<ImageCopyTexture, ImageCopyTextureFFI>.UnsafeConvertToFFI(
        in ImageCopyTexture input, WebGpuAllocatorHandle allocator, out ImageCopyTextureFFI dest)
    {
        var ownedTextureHandle = input.Texture.UnsafeGetCurrentOwnedTextureHandle();
        allocator.AddHandleToDispose(ownedTextureHandle);

        dest = new ImageCopyTextureFFI(
            texture: ownedTextureHandle,
            mipLevel: input.MipLevel,
            origin: input.Origin,
            aspect: input.Aspect
        );
    }
}