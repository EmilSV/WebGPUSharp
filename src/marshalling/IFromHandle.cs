namespace WebGpuSharp.Marshalling;

public interface IFromHandle<TSelf, THandle>
{
    public static abstract TSelf? FromHandle(THandle handle);
}