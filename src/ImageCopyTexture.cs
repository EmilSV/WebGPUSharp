using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyTexture :
    IWebGpuFFIConvertible<ImageCopyTexture, ImageCopyTextureFFI>
{
    public required TextureSource Texture;
    public uint MipLevel = 0;
    public Origin3D Origin;
    public TextureAspect Aspect = TextureAspect.All;

    public ImageCopyTexture()
    {
    }

    static void IWebGpuFFIConvertible<ImageCopyTexture, ImageCopyTextureFFI>.UnsafeConvertToFFI(
        in ImageCopyTexture input, out ImageCopyTextureFFI dest)
    {
        dest = new(
            texture: input.Texture.GetHandle(),
            mipLevel: input.MipLevel,
            origin: input.Origin,
            aspect: input.Aspect
        );
    }

    static void IWebGpuFFIConvertibleAlloc<ImageCopyTexture, ImageCopyTextureFFI>.UnsafeConvertToFFI(
        in ImageCopyTexture input, WebGpuAllocatorHandle allocator, out ImageCopyTextureFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}