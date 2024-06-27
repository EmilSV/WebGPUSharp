using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CompositeAlphaMode
{
    Auto = 1,
    Opaque = 2,
    Premultiplied = 3,
    Unpremultiplied = 4,
    Inherit = 5,
}
