namespace WebGpuSharp.Marshalling;

public interface IFromHandleWithInstance<TSelf, THandle>
{
    public static abstract TSelf? FromHandle(THandle managedHandle, Instance instance);
    public static abstract Instance GetOwnerInstance(TSelf managedHandle);
}