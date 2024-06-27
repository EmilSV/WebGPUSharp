using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CallbackMode
{
    WaitAnyOnly = 1,
    AllowProcessEvents = 2,
    AllowSpontaneous = 3,
}
