using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Future
{
    public ulong Id;

    public Future()
    {
    }


    public Future(ulong id = default)
    {
        this.Id = id;
    }

}