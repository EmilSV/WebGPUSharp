using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct MemoryHeapInfo
{
    public HeapProperty Properties;
    public ulong Size;

    public MemoryHeapInfo()
    {
    }


    public MemoryHeapInfo(HeapProperty properties = default, ulong size = default)
    {
        this.Properties = properties;
        this.Size = size;
    }

}
