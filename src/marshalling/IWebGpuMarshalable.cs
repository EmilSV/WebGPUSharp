using System.Runtime.CompilerServices;

namespace WebGpuSharp.Marshalling;

public interface IWebGpuMarshallable<TSelf, TFFI> : IWebGpuMarshallableAlloc<TSelf, TFFI>
    where TSelf : IWebGpuMarshallable<TSelf, TFFI>
{
    public static abstract void MarshalToFFI(in TSelf input, out TFFI dest);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static void IWebGpuMarshallableAlloc<TSelf, TFFI>
        .MarshalToFFI(in TSelf input, WebGpuAllocatorHandle allocator, out TFFI dest)
    {
        TSelf.MarshalToFFI(input, out dest);
    }
}