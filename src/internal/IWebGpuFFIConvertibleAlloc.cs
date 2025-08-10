using WebGpuSharp.Marshalling;

namespace WebGpuSharp.Internal;

public interface IWebGpuFFIConvertibleAlloc<TSelf, TFFI>
{
    public static abstract void UnsafeConvertToFFI(in TSelf input, WebGpuAllocatorHandle allocator, out TFFI dest);
}