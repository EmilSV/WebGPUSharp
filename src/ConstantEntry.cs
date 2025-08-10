using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;


/// <inheritdoc cref="ConstantEntryFFI" />
public unsafe partial struct ConstantEntry : IWebGpuMarshallable<ConstantEntry, ConstantEntryFFI>
{
    /// <inheritdoc cref="ConstantEntryFFI.Key" />
    public required string Key;
    /// <inheritdoc cref="ConstantEntryFFI.Value" />
    public required double Value;


    public ConstantEntry()
    {
    }

    public ConstantEntry(string key, double value)
    {
        Key = key;
        Value = value;
    }

    static void IWebGpuMarshallable<ConstantEntry, ConstantEntryFFI>.MarshalToFFI(
        in ConstantEntry input, WebGpuAllocatorHandle allocator, out ConstantEntryFFI dest)
    {
        dest = new()
        {
            Key = ToStringViewFFI(input.Key, allocator),
            Value = input.Value
        };
    }
}