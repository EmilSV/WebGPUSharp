using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnCacheDeviceDescriptorFFI
{
    public ChainedStruct Chain = new();
    public StringViewFFI IsolationKey = new();
    public DawnLoadCacheDataFunctionFFI LoadDataFunction = new();
    public DawnStoreCacheDataFunctionFFI StoreDataFunction = new();
    public void* FunctionUserdata;

    public DawnCacheDeviceDescriptorFFI() { }

}
