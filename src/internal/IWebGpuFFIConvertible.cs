namespace WebGpuSharp.Internal;

public interface IWebGpuFFIConvertible<TSelf, TFFI> : IWebGpuFFIConvertibleAlloc<TSelf, TFFI>
{
    public static abstract void UnsafeConvertToFFI(in TSelf input, out TFFI dest);
}