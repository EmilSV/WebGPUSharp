using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyTexture :
    IWebGpuFFIConvertible<ImageCopyTexture, ImageCopyTextureFFI>
{
    public Texture Texture;
    public uint MipLevel;
    public Origin3D Origin;
    public TextureAspect Aspect;

    static void IWebGpuFFIConvertible<ImageCopyTexture, ImageCopyTextureFFI>.UnsafeConvertToFFI(
        in ImageCopyTexture input, out ImageCopyTextureFFI dest)
    {
        dest = new(
            texture: WebGPUMarshal.ToFFI<Texture, TextureHandle>(input.Texture),
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