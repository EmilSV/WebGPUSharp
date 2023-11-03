using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe static partial class WebGPUMarshal
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>(WGPUNullableRef<TFrom> input, out TTo dest)
        where TFrom : struct, IWebGpuFFIConvertible<TFrom, TTo>
    {
        if (input.HasValue)
        {
            TFrom.UnsafeConvertToFFI(in input.Value, out dest);
        }
        else
        {
            dest = default!;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo ToFFI<TFrom, TTo>(WGPUNullableRef<TFrom> input)
        where TFrom : struct, IWebGpuFFIConvertible<TFrom, TTo>
    {
        if (input.HasValue)
        {
            TFrom.UnsafeConvertToFFI(in input.Value, out var dest);
            return dest;
        }
        else
        {
            return default!;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>(
        WGPUNullableRef<TFrom> input, WebGpuAllocatorHandle allocator, out TTo dest)
        where TFrom : struct, IWebGpuFFIConvertibleAlloc<TFrom, TTo>
    {
        if (input.HasValue)
        {
            TFrom.UnsafeConvertToFFI(in input.Value, allocator, out dest);
        }
        else
        {
            dest = default!;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void ToFFI<TFrom, TTo>(
        WGPUNullableRef<TFrom> input, WebGpuAllocatorHandle allocator, out TTo* dest)
        where TFrom : struct, IWebGpuFFIConvertibleAlloc<TFrom, TTo>
        where TTo : unmanaged
    {
        if (input.HasValue)
        {
            TTo* newDestPtr = allocator.Alloc<TTo>(1);
            TFrom.UnsafeConvertToFFI(in input.Value, allocator, out Unsafe.AsRef<TTo>(newDestPtr));
            dest = newDestPtr;
        }
        else
        {
            dest = null;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>([AllowNull] in TFrom input, out TTo dest)
        where TFrom : IWebGpuFFIConvertible<TFrom, TTo>
    {
        if (input is null)
        {
            dest = default!;
            return;
        }

        TFrom.UnsafeConvertToFFI(in input, out dest);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo ToFFI<TFrom, TTo>([AllowNull] in TFrom input)
        where TFrom : IWebGpuFFIConvertible<TFrom, TTo>
    {
        if (input is null)
        {
            return default!;
        }

        TFrom.UnsafeConvertToFFI(in input, out var dest);
        return dest;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>([AllowNull] in TFrom input, WebGpuAllocatorHandle allocator, out TTo dest)
        where TFrom : IWebGpuFFIConvertibleAlloc<TFrom, TTo>
    {
        if (input is null)
        {
            dest = default!;
            return;
        }

        TFrom.UnsafeConvertToFFI(in input, allocator, out dest);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>(
        ReadOnlySpan<TFrom> input,
        WebGpuAllocatorHandle allocator,
        out TTo* dest,
        out nuint outCount
    )
        where TFrom : IWebGpuFFIConvertible<TFrom, TTo>
        where TTo : unmanaged
    {
        if (input.IsEmpty)
        {
            dest = null;
            outCount = 0;
            return;
        }

        var newDestPtr = allocator.Alloc<TTo>((nuint)input.Length);
        outCount = (nuint)input.Length;
        for (var i = 0; i < input.Length; i++)
        {
            TFrom.UnsafeConvertToFFI(in input[i], out Unsafe.AsRef<TTo>(newDestPtr + i));
        }

        dest = newDestPtr;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>(
        ReadOnlySpan<TFrom> input,
        WebGpuAllocatorHandle allocator,
        out TTo* dest,
        out uint outCount
    )
    where TFrom : IWebGpuFFIConvertible<TFrom, TTo>
    where TTo : unmanaged
    {
        ToFFI(input, allocator, out dest, out nuint outCountNuint);
        outCount = (uint)outCountNuint;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void ToFFI(string input, WebGpuAllocatorHandle allocator, out byte* dest)
    {
        dest = UFT8CStrFactory.Create(input, allocator);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe byte* ToFFI(string input, WebGpuAllocatorHandle allocator)
    {
        return UFT8CStrFactory.Create(input, allocator);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TTo>(
        T? input, WebGpuAllocatorHandle allocator,
        out TTo* dest, out nuint outCount
    )
        where T : IWebGpuFFIConvertibleCollectionAlloc<TTo>
        where TTo : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.UnsafeConvertToFFI(allocator, out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TTo>(
        T? input, WebGpuAllocatorHandle allocator,
        out TTo* dest, out uint outCount
    )
        where T : IWebGpuFFIConvertibleCollectionAlloc<TTo>
        where TTo : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.UnsafeConvertToFFI(allocator, out dest, out var outCountNuint);
        outCount = (uint)outCountNuint;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<T, TTo>(
        T? input, out TTo* dest, out nuint outCount)
        where T : IWebGpuFFIConvertibleCollection<TTo>
        where TTo : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.UnsafeConvertToFFI(out dest, out outCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ToFFI<TFrom, TTo>(
        TFrom? input, out TTo* dest, out uint outCount)
        where TFrom : IWebGpuFFIConvertibleCollection<TTo>
        where TTo : unmanaged
    {
        if (input is null)
        {
            dest = null;
            outCount = 0;
            return;
        }

        input.UnsafeConvertToFFI(out dest, out var outCountNuint);
        outCount = (uint)outCountNuint;
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