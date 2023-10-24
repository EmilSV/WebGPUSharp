namespace WebGpuSharp.Internal;

public interface IUnsafeMarshalAlloc<TSelf, TFFI>
{
    public static abstract void UnsafeMarshalTo(in TSelf input,WebGpuAllocatorHandle allocator, ref TFFI dest);
}