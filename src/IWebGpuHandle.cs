namespace WebGpuSharp;

public interface IWebGpuHandle<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    public static abstract ref UIntPtr AsPointer(ref T handle);
    public static abstract T GetNullHandle();
    public static abstract bool IsNull(T handle);
    public static abstract T UnsafeFromPointer(UIntPtr pointer);
}