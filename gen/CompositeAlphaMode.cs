using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CompositeAlphaMode
{
    Auto = 0,
    Opaque = 1,
    Premultiplied = 2,
    Unpremultiplied = 3,
    Inherit = 4,
}
