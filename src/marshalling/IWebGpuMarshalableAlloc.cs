namespace WebGpuSharp.Marshalling;

public interface IWebGpuMarshallableAlloc<TSelf, TFFI>
{
    public static abstract void MarshalToFFI(in TSelf input, WebGpuAllocatorHandle allocator, out TFFI dest);
}