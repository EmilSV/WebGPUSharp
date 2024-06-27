using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum ErrorFilter
{
    Validation = 1,
    OutOfMemory = 2,
    Internal = 3,
}
