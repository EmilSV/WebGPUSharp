namespace WebGpuSharp.Internal;

public interface IUnsafeMarshal<TSelf, TFFI> : IUnsafeMarshalAlloc<TSelf, TFFI>
{
    public static abstract void UnsafeMarshalTo(in TSelf input, ref TFFI dest);
}