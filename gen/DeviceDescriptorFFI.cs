using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Device.
/// </summary>
public unsafe partial struct DeviceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label for the device.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// the number of required features in the requiredFeatures sequence.
    /// </summary>
    public nuint RequiredFeatureCount;
    /// <summary>
    /// Specifies the features that are required by the device request.
    /// The request will fail if the adapter cannot provide these features.
    /// Exactly the specified set of features, and no more or less, will be allowed in validation
    /// of API calls on the resulting device.
    /// </summary>
    public FeatureName* RequiredFeatures;
    /// <summary>
    /// Specifies the limits that are required by the device request.
    /// The request will fail if the adapter cannot provide these limits.
    /// Each key with a non-`undefined` value must be the name of a member of supported limits.
    /// API calls on the resulting device perform validation according to the exact limits of the
    /// device (not the adapter; see #limits).
    /// 
    /// </summary>
    public RequiredLimits* RequiredLimits;
    /// <summary>
    /// The descriptor for the default  <see cref="WebGpuSharp.Queue"/>.
    /// </summary>
    public QueueDescriptorFFI DefaultQueue = new();
    public DeviceLostCallbackInfoFFI DeviceLostCallbackInfo = new();
    public UncapturedErrorCallbackInfoFFI UncapturedErrorCallbackInfo = new();

    public DeviceDescriptorFFI() { }

}
