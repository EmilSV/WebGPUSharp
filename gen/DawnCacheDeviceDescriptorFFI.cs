using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnCacheDeviceDescriptorFFI
{
    public ChainedStruct Chain;
    public StringViewFFI IsolationKey = StringViewFFI.NullValue;
    public DawnLoadCacheDataFunctionFFI LoadDataFunction = new();
    public DawnStoreCacheDataFunctionFFI StoreDataFunction = new();
    public void* FunctionUserdata;

    public DawnCacheDeviceDescriptorFFI() { }

}
