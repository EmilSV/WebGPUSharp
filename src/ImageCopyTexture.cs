using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyTexture :
    IWebGpuFFIConvertibleAlloc<ImageCopyTexture, ImageCopyTextureFFI>
{
    public required TextureBase Texture;
    public uint MipLevel = 0;
    public Origin3D Origin;
    public TextureAspect Aspect = TextureAspect.All;

    public ImageCopyTexture()
    {
    }

    static void IWebGpuFFIConvertibleAlloc<ImageCopyTexture, ImageCopyTextureFFI>.UnsafeConvertToFFI(
        in ImageCopyTexture input, WebGpuAllocatorHandle allocator, out ImageCopyTextureFFI dest)
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