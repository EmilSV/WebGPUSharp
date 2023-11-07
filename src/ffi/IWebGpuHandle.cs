namespace WebGpuSharp.FFI;

public interface IWebGpuHandle<TSelf>
    where TSelf : unmanaged, IWebGpuHandle<TSelf>
{
    public static abstract ref UIntPtr AsPointer(ref TSelf handle);
    public static abstract TSelf Null { get; }
    public static abstract bool IsNull(TSelf handle);
    public static abstract TSelf UnsafeFromPointer(UIntPtr pointer);
    public static abstract void Reference(TSelf handle);
    public static abstract void Release(TSelf handle);
}

public interface IWebGpuHandle<TSelf, TSafeHandle> : IWebGpuHandle<TSelf>
    where TSelf : unmanaged, IWebGpuHandle<TSelf>
{
    public TSafeHandle? ToSafeHandle(bool isOwnedHandle);
}
