namespace WebGpuSharp.Internal;

public interface IFromHandle<TSelf, THandle>
{
    public static abstract TSelf? FromHandle(THandle handle);
    public static abstract TSelf? FromHandleNoRefIncrement(THandle handle);
}