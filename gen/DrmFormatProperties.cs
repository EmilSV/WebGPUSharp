using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DrmFormatProperties
{
    public ulong Modifier;
    public uint ModifierPlaneCount;

    public DrmFormatProperties() { }

}
