using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public unsafe partial struct ConstantEntry : IWebGpuFFIConvertibleAlloc<ConstantEntry, ConstantEntryFFI>
{
    public string Key;
    public double Value;

    public ConstantEntry(string key, double value)
    {
        Key = key;
        Value = value;
    }

    static void IWebGpuFFIConvertibleAlloc<ConstantEntry, ConstantEntryFFI>.UnsafeConvertToFFI(
        in ConstantEntry input, WebGpuAllocatorHandle allocator, out ConstantEntryFFI dest)
    {
        dest = new(
            key: WebGPUMarshal.ToFFI(input.Key, allocator),
            value: input.Value
        );
    }
}