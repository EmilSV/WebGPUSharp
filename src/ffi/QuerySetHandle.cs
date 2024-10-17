using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;


public unsafe readonly partial struct QuerySetHandle :
    IWebGpuHandle<QuerySetHandle, QuerySet>, IDisposable
{
    public QueryType GetQueryType()
    {
        return WebGPU_FFI.QuerySetGetType(this);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.QuerySetSetLabel2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    public static ref nuint AsPointer(ref QuerySetHandle handle)
    {
        return ref Unsafe.As<QuerySetHandle, UIntPtr>(ref handle);
    }

    public static QuerySetHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(QuerySetHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(QuerySetHandle handle)
    {
        WebGPU_FFI.QuerySetAddRef(handle);
    }

    public static void Release(QuerySetHandle handle)
    {
        WebGPU_FFI.QuerySetRelease(handle);
    }

    public static QuerySetHandle UnsafeFromPointer(nuint pointer)
    {
        return new QuerySetHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.QuerySetRelease(this);
        }
    }

    public QuerySet? ToSafeHandle(bool isOwnedHandle)
    {
        return QuerySet.FromHandle(this, isOwnedHandle);
    }
}