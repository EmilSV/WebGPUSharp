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

    public DawnCacheDeviceDescriptorFFI()
    {
    }


    public DawnCacheDeviceDescriptorFFI(ChainedStruct chain = default, byte* isolationKey = default, DawnLoadCacheDataFunctionFFI loadDataFunction = default, DawnStoreCacheDataFunctionFFI storeDataFunction = default, void* functionUserdata = default)
    {
        this.Chain = chain;
        this.IsolationKey = isolationKey;
        this.LoadDataFunction = loadDataFunction;
        this.StoreDataFunction = storeDataFunction;
        this.FunctionUserdata = functionUserdata;
    }

}
