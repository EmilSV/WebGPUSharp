using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Flags
{
    public uint Value;

    public Flags()
    {
    }


    public Flags(uint value = default)
    {
        this.Value = value;
    }

}
