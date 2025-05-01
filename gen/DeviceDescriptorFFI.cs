using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Device.
/// </summary>
public unsafe partial struct DeviceDescriptorFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label for the device.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// the number of items in the <see cref="RequiredFeatures" /> sequence.
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
    public Limits* RequiredLimits;
    /// <summary>
    /// The descriptor for the default <see cref="Queue" />.
    /// </summary>
    public QueueDescriptorFFI DefaultQueue = new();
    /// <summary>
    /// Callback for when the device is lost.
    /// </summary>
    public DeviceLostCallbackInfoFFI DeviceLostCallbackInfo = new();
    /// <summary>
    /// Callback for when an uncaptured error occurs.
    /// </summary>
    public UncapturedErrorCallbackInfoFFI UncapturedErrorCallbackInfo = new();

    public DeviceDescriptorFFI() { }

}
