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
    public delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> DeviceLostCallback;
    public void* DeviceLostUserdata;
    public DeviceLostCallbackInfoFFI DeviceLostCallbackInfo;
    public UncapturedErrorCallbackInfoFFI UncapturedErrorCallbackInfo;
    public DeviceLostCallbackInfo2FFI DeviceLostCallbackInfo2;
    public UncapturedErrorCallbackInfo2FFI UncapturedErrorCallbackInfo2;

    public DeviceDescriptorFFI()
    {
    }


    public DeviceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint requiredFeatureCount = default, FeatureName* requiredFeatures = default, RequiredLimits* requiredLimits = default, QueueDescriptorFFI defaultQueue = default, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> deviceLostCallback = default, void* deviceLostUserdata = default, DeviceLostCallbackInfoFFI deviceLostCallbackInfo = default, UncapturedErrorCallbackInfoFFI uncapturedErrorCallbackInfo = default, DeviceLostCallbackInfo2FFI deviceLostCallbackInfo2 = default, UncapturedErrorCallbackInfo2FFI uncapturedErrorCallbackInfo2 = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.RequiredFeatureCount = requiredFeatureCount;
        this.RequiredFeatures = requiredFeatures;
        this.RequiredLimits = requiredLimits;
        this.DefaultQueue = defaultQueue;
        this.DeviceLostCallback = deviceLostCallback;
        this.DeviceLostUserdata = deviceLostUserdata;
        this.DeviceLostCallbackInfo = deviceLostCallbackInfo;
        this.UncapturedErrorCallbackInfo = uncapturedErrorCallbackInfo;
        this.DeviceLostCallbackInfo2 = deviceLostCallbackInfo2;
        this.UncapturedErrorCallbackInfo2 = uncapturedErrorCallbackInfo2;
    }


    public DeviceDescriptorFFI(byte* label = default, nuint requiredFeatureCount = default, FeatureName* requiredFeatures = default, RequiredLimits* requiredLimits = default, QueueDescriptorFFI defaultQueue = default, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> deviceLostCallback = default, void* deviceLostUserdata = default, DeviceLostCallbackInfoFFI deviceLostCallbackInfo = default, UncapturedErrorCallbackInfoFFI uncapturedErrorCallbackInfo = default, DeviceLostCallbackInfo2FFI deviceLostCallbackInfo2 = default, UncapturedErrorCallbackInfo2FFI uncapturedErrorCallbackInfo2 = default)
    {
        this.Label = label;
        this.RequiredFeatureCount = requiredFeatureCount;
        this.RequiredFeatures = requiredFeatures;
        this.RequiredLimits = requiredLimits;
        this.DefaultQueue = defaultQueue;
        this.DeviceLostCallback = deviceLostCallback;
        this.DeviceLostUserdata = deviceLostUserdata;
        this.DeviceLostCallbackInfo = deviceLostCallbackInfo;
        this.UncapturedErrorCallbackInfo = uncapturedErrorCallbackInfo;
        this.DeviceLostCallbackInfo2 = deviceLostCallbackInfo2;
        this.UncapturedErrorCallbackInfo2 = uncapturedErrorCallbackInfo2;
    }

}
