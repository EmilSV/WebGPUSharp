using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnCacheDeviceDescriptorFFI
{
    public ChainedStruct Chain;
    public byte* IsolationKey;
    public DawnLoadCacheDataFunctionFFI LoadDataFunction;
    public DawnStoreCacheDataFunctionFFI StoreDataFunction;
    public void* FunctionUserdata;

    public DawnCacheDeviceDescriptorFFI() { }

}
