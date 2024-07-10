using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
public enum TextureUsage : ulong
{
    None = 0,
    CopySrc = 1,
    CopyDst = 2,
    TextureBinding = 4,
    StorageBinding = 8,
    RenderAttachment = 16,
    TransientAttachment = 32,
    StorageAttachment = 64,
}
