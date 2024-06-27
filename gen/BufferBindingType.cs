using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum BufferBindingType
{
    Undefined = 0,
    Uniform = 1,
    Storage = 2,
    ReadOnlyStorage = 3,
}
