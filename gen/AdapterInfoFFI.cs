using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterInfoFFI
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
    /// The name of the adapter vendor. Returns an empty string if it is not available.
    /// </summary>
    public StringViewFFI Vendor = StringViewFFI.NullValue;
    /// <summary>
    /// The name of the family or class of GPUs the adapter belongs to. Returns an empty
    /// string if it is not available.
    /// </summary>
    public StringViewFFI Architecture = StringViewFFI.NullValue;
    /// <summary>
    /// A vendor-specific identifier for the adapter. Returns an empty string if it is not
    /// available.
    /// </summary>
    public StringViewFFI Device = StringViewFFI.NullValue;
    /// <summary>
    /// A human-readable string describing the adapter. Returns an empty string if it is
    /// not available.
    /// </summary>
    public StringViewFFI Description = StringViewFFI.NullValue;
    /// <summary>
    /// The name of the adapter vendor. Returns an empty string if it is not available.
    /// </summary>
    public BackendType BackendType;
    /// <summary>
    /// The name of the adapter vendor. Returns an empty string if it is not available.
    /// </summary>
    public AdapterType AdapterType;
    /// <summary>
    /// Backend-specific vendor ID of the adapter
    /// 
    /// This generally is a 16-bit PCI vendor ID in the least significant bytes of this field.
    /// However, more significant bytes may be non-zero if the backend uses a different
    /// representation.
    /// 
    /// For Vulkan backend, the VkPhysicalDeviceProperties::vendorID is used, which is a
    /// superset of PCI IDs.
    /// </summary>
    public uint VendorID;
    /// <summary>
    /// Backend-specific device ID of the adapter
    /// 
    /// This generally is a 16-bit PCI device ID in the least significant bytes of this field.
    /// However, more significant bytes may be non-zero if the backend uses a different
    /// representation.
    /// 
    /// For Vulkan backend, the VkPhysicalDeviceProperties::vendorID is used, which is a
    /// superset of PCI IDs.
    /// </summary>
    public uint DeviceID;
    public WebGPUBool CompatibilityMode = new();

    public AdapterInfoFFI() { }

}
