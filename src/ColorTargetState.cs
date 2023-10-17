using System.Runtime.InteropServices;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public partial struct ColorTargetState
{
    public TextureFormat Format;
    public BlendState? Blend;
    public ColorWriteMask WriteMask;

    public ColorTargetState(
        TextureFormat format = default, 
        BlendState? blend = default, 
        ColorWriteMask writeMask = default)
    {
        this.Format = format;
        this.Blend = blend;
        this.WriteMask = writeMask;
    }
}
