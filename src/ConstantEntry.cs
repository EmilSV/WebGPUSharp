using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;


/// <inheritdoc cref="ConstantEntryFFI" />
public unsafe partial struct ConstantEntry : IWebGpuFFIConvertibleAlloc<ConstantEntry, ConstantEntryFFI>
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

    static void IWebGpuFFIConvertibleAlloc<ConstantEntry, ConstantEntryFFI>.UnsafeConvertToFFI(
        in ConstantEntry input, WebGpuAllocatorHandle allocator, out ConstantEntryFFI dest)
    {
        dest = new()
        {
            Key = ToStringViewFFI(input.Key, allocator),
            Value = input.Value
        };
    }
}