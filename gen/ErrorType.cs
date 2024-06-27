using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum ErrorType
{
    NoError = 1,
    Validation = 2,
    OutOfMemory = 3,
    Internal = 4,
    Unknown = 5,
    DeviceLost = 6,
}
