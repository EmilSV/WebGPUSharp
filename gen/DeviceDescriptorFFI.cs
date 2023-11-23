using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
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

	public DeviceDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.RequiredFeatureCount = default;
		this.RequiredFeatures = default;
		this.RequiredLimits = default;
		this.DefaultQueue = default;
		this.DeviceLostCallback = default;
		this.DeviceLostUserdata = default;
	}

	public DeviceDescriptorFFI(byte* label = default, nuint requiredFeatureCount = default, FeatureName* requiredFeatures = default, RequiredLimits* requiredLimits = default, QueueDescriptorFFI defaultQueue = default, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> deviceLostCallback = default, void* deviceLostUserdata = default)
	{
		this.Label = label;
		this.RequiredFeatureCount = requiredFeatureCount;
		this.RequiredFeatures = requiredFeatures;
		this.RequiredLimits = requiredLimits;
		this.DefaultQueue = defaultQueue;
		this.DeviceLostCallback = deviceLostCallback;
		this.DeviceLostUserdata = deviceLostUserdata;
	}

	public DeviceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint requiredFeatureCount = default, FeatureName* requiredFeatures = default, RequiredLimits* requiredLimits = default, QueueDescriptorFFI defaultQueue = default, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> deviceLostCallback = default, void* deviceLostUserdata = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.RequiredFeatureCount = requiredFeatureCount;
		this.RequiredFeatures = requiredFeatures;
		this.RequiredLimits = requiredLimits;
		this.DefaultQueue = defaultQueue;
		this.DeviceLostCallback = deviceLostCallback;
		this.DeviceLostUserdata = deviceLostUserdata;
	}
}

