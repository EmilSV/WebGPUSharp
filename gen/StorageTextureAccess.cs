using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum StorageTextureAccess
{
    BindingNotUsed = 0,
    Undefined = 1,
    WriteOnly = 2,
    ReadOnly = 3,
    ReadWrite = 4,
}
