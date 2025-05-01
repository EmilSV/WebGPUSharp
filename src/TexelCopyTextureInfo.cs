using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct TexelCopyTextureInfo :
    IWebGpuFFIConvertibleAlloc<TexelCopyTextureInfo, TexelCopyTextureInfoFFI>
{
    public required TextureBase Texture;
    public uint MipLevel = 0;
    public Origin3D Origin = new();
    public TextureAspect Aspect = TextureAspect.All;

    public TexelCopyTextureInfo()
    {
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