using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DeviceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint RequiredFeatureCount;
    public FeatureName* RequiredFeatures;
    public RequiredLimits* RequiredLimits;
    public QueueDescriptorFFI DefaultQueue;
    public DeviceLostCallbackInfoFFI DeviceLostCallbackInfo;
    public UncapturedErrorCallbackInfoFFI UncapturedErrorCallbackInfo;
    public DeviceLostCallbackInfo2FFI DeviceLostCallbackInfo2;
    public UncapturedErrorCallbackInfo2FFI UncapturedErrorCallbackInfo2;

    public DeviceDescriptorFFI()
    {
    }

}
