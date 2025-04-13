using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
[Flags]
public enum BufferUsage : ulong
{
    None = 0,
    MapRead = 1,
    MapWrite = 2,
    CopySrc = 4,
    CopyDst = 8,
    Index = 16,
    Vertex = 32,
    Uniform = 64,
    Storage = 128,
    Indirect = 256,
    QueryResolve = 512,
}
