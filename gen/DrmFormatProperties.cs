using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DrmFormatProperties
{
    public ulong Modifier;
    public uint ModifierPlaneCount;

    public DrmFormatProperties()
    {
    }


    public DrmFormatProperties(ulong modifier = default, uint modifierPlaneCount = default)
    {
        this.Modifier = modifier;
        this.ModifierPlaneCount = modifierPlaneCount;
    }

}
