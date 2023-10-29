using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe static partial class WebGPUMarshal
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TSelf, TFFI>(WGPUNullableRef<TSelf> input, ref TFFI dest)
        where TSelf : struct, IUnsafeMarshal<TSelf, TFFI>
    {
        if (input.HasValue)
        {
            TSelf.UnsafeMarshalTo(in input.Value, ref dest);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TSelf, TFFI>(
        WGPUNullableRef<TSelf> input, WebGpuAllocatorHandle allocator, ref TFFI dest)
        where TSelf : struct, IUnsafeMarshalAlloc<TSelf, TFFI>
    {
        if (input.HasValue)
        {
            TSelf.UnsafeMarshalTo(in input.Value, allocator, ref dest);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void ToFFI<TSelf, TFFI>(
        WGPUNullableRef<TSelf> input, WebGpuAllocatorHandle allocator, out TFFI* dest)
        where TSelf : struct, IUnsafeMarshalAlloc<TSelf, TFFI>
        where TFFI : unmanaged
    {
        if (input.HasValue)
        {
            TFFI* newDestPtr = allocator.Alloc<TFFI>(1);
            TSelf.UnsafeMarshalTo(in input.Value, allocator, ref Unsafe.AsRef<TFFI>(newDestPtr));
            dest = newDestPtr;
        }
        else
        {
            dest = null;
        }
    }


    public static void ToFFI<TSafeHandle, THandle>(
        ReadOnlySpan<TSafeHandle> handles,
        WebGpuAllocatorHandle allocator,
        out THandle* outHandles,
        out nuint outCount
    )
         where TSafeHandle : BaseWebGpuSafeHandle<THandle>
         where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        int length = handles.Length;
        outHandles = allocator.Alloc<THandle>((nuint)length);
        for (int i = 0; i < length; i++)
        {
            outHandles[i] = handles[i].GetHandle();
        }

        outCount = (nuint)handles.Length;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TSelf, TFFI>(in TSelf input, ref TFFI dest)
        where TSelf : IUnsafeMarshal<TSelf, TFFI>
    {
        TSelf.UnsafeMarshalTo(in input, ref dest);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TSelf, TFFI>(in TSelf input, WebGpuAllocatorHandle allocator, ref TFFI dest)
        where TSelf : IUnsafeMarshalAlloc<TSelf, TFFI>
    {
        TSelf.UnsafeMarshalTo(in input, allocator, ref dest);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void ToFFI(string input, WebGpuAllocatorHandle allocator, out byte* dest)
    {
        dest = UFT8CStrFactory.Create(input, allocator);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TFFI>(
        T? input, WebGpuAllocatorHandle allocator,
        out TFFI* dest, out nuint outCount
    )
        where T : IUnsafeMarshalCollectionAlloc<TFFI>
        where TFFI : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.GetPointerToFFIItems(allocator, out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TFFI>(
        T? input, WebGpuAllocatorHandle allocator,
        out TFFI* dest, out uint outCount
    )
        where T : IUnsafeMarshalCollectionAlloc<TFFI>
        where TFFI : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.GetPointerToFFIItems(allocator, out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TFFI>(
        T? input,
        out TFFI* dest, out nuint outCount)
        where T : IUnsafeMarshalCollection<TFFI>
        where TFFI : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.GetPointerToFFIItems(out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TFFI>(
        T? input,
        out TFFI* dest, out uint outCount)
        where T : IUnsafeMarshalCollection<TFFI>
        where TFFI : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.GetPointerToFFIItems(out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T>(BaseWebGpuSafeHandle<T> safeHandle, out T handle)
         where T : unmanaged, IWebGpuHandle<T>
    {
        handle = safeHandle.GetHandle();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T>(
        BaseWebGpuSafeHandle<T> safeHandle,
        WebGpuAllocatorHandle _allocator, out T handle)
     where T : unmanaged, IWebGpuHandle<T>
    {
        handle = safeHandle.GetHandle();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WGPURefCStrUTF8 ToRefCstrUtf8(WGPURefText text, WebGpuAllocatorHandle allocator)
    {
        return new(text, allocator);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetBorrowHandle<T>(BaseWebGpuSafeHandle<T> safeHandle)
       where T : unmanaged, IWebGpuHandle<T>
    {
        return safeHandle.GetHandle();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetOwnedHandle<T>(BaseWebGpuSafeHandle<T> safeHandle)
        where T : unmanaged, IWebGpuHandle<T>
    {
        var handle = safeHandle.GetHandle();
        T.Reference(handle);
        return handle;
    }
}