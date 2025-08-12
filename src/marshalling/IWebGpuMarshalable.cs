namespace WebGpuSharp.Marshalling;

public interface IWebGpuMarshallable<TSelf, TFFI>
{
    public static abstract void MarshalToFFI(in TSelf input, out TFFI dest);
}