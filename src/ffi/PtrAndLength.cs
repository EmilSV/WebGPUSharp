namespace WebGpuSharp.FFI;


public unsafe readonly ref struct PtrAndLength<T>
    where T : unmanaged
{
    public readonly T* Ptr;
    public readonly nuint Length;

    public PtrAndLength(T* ptr, nuint length)
    {
        Ptr = ptr;
        Length = length;
    }


    public void Deconstruct(out T* ptr, out nuint length)
    {
        ptr = Ptr;
        length = Length;
    }
}