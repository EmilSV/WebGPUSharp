using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum StorageTextureAccess
{
    Undefined = 0,
    WriteOnly = 1,
    ReadOnly = 2,
    ReadWrite = 3,
}
