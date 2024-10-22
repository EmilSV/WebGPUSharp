using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterPropertiesMemoryHeapsFFI
{
    public ChainedStructOut Chain;
    public nuint HeapCount;
    public MemoryHeapInfo* HeapInfo;

    public AdapterPropertiesMemoryHeapsFFI() { }

}
