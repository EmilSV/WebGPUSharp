using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A QueueDescriptor is a descriptor for a queue. It is used to create a Queue handle.
/// </summary>
public unsafe partial struct QueueDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label for the queue.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public QueueDescriptorFFI() { }

}
