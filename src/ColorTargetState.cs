using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public unsafe partial struct ColorTargetState : IWebGpuFFIConvertibleAlloc<ColorTargetState, ColorTargetStateFFI>
{
    public TextureFormat Format;
    public BlendState? Blend;
    public ColorWriteMask WriteMask = ColorWriteMask.All;

    public ColorTargetState() { }

    static void IWebGpuFFIConvertibleAlloc<ColorTargetState, ColorTargetStateFFI>.UnsafeConvertToFFI(
        in ColorTargetState input, WebGpuAllocatorHandle allocator, out ColorTargetStateFFI dest)
    {
        if (input.Blend.HasValue)
        {
            var blendStatePtr = allocator.Alloc<BlendState>(1);
            *blendStatePtr = input.Blend.Value;
            dest = new()
            {
                Format = input.Format,
                Blend = blendStatePtr,
                WriteMask = input.WriteMask
            };
        }
        else
        {
            dest = new()
            {
                Format = input.Format,
                Blend = null,
                WriteMask = input.WriteMask
            };
        }
    }
}
