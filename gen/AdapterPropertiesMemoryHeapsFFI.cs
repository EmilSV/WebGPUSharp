using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterPropertiesMemoryHeapsFFI
{
    public ChainedStructOut Chain;
    public nuint HeapCount;
    public MemoryHeapInfo* HeapInfo;

    public AdapterPropertiesMemoryHeapsFFI()
    {
    }


    public AdapterPropertiesMemoryHeapsFFI(ChainedStructOut chain = default, nuint heapCount = default, MemoryHeapInfo* heapInfo = default)
    {
        this.Chain = chain;
        this.HeapCount = heapCount;
        this.HeapInfo = heapInfo;
    }

}
