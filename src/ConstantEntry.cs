using System.Diagnostics.CodeAnalysis;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;


/// <inheritdoc cref="ConstantEntryFFI" />
public unsafe partial struct ConstantEntry : IWebGpuMarshallableAlloc<ConstantEntry, ConstantEntryFFI>
{
    /// <inheritdoc cref="ConstantEntryFFI.Key" />
    public required string Key;
    /// <inheritdoc cref="ConstantEntryFFI.Value" />
    public required double Value;


    public ConstantEntry()
    {
    }

    [SetsRequiredMembers]
    public ConstantEntry(string key, double value)
    {
        Key = key;
        Value = value;
    }

    static void IWebGpuMarshallableAlloc<ConstantEntry, ConstantEntryFFI>.MarshalToFFI(
        in ConstantEntry input, WebGpuAllocatorHandle allocator, out ConstantEntryFFI dest)
    {
        dest = new()
        {
            Key = ToStringViewFFI(input.Key, allocator),
            Value = input.Value
        };
    }
}