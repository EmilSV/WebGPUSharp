using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

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
        where TFrom : IWebGpuFFIConvertibleAlloc<TFrom, TTo>
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
            TFrom.UnsafeConvertToFFI(in input[i], allocator, out Unsafe.AsRef<TTo>(newDestPtr + i));
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
    public static unsafe void ToFFI(string? input, WebGpuAllocatorHandle allocator, out StringViewFFI dest)
    {
        dest = ToFFI(input, allocator);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe StringViewFFI ToFFI(string? input, WebGpuAllocatorHandle allocator)
    {
        if (input is null)
        {
            return default;
        }

        var resultSpan = ToUtf8Span(input, allocator);
        return new((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in MemoryMarshal.AsRef<char>(resultSpan))), (uint)resultSpan.Length);
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

    public static unsafe ReadOnlySpan<byte> ToUtf8Span(WGPURefText text, WebGpuAllocatorHandle allocator)
    {
        int length = text.Length;
        if (length == 0)
        {
            return [];
        }

        if (text.Is16BitSize)
        {
            ref var refChar = ref Unsafe.AsRef(in text._reference);
            ReadOnlySpan<char> charTextSpan = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<byte, char>(ref refChar), length);
            return ToUtf8Span(charTextSpan, allocator);
        }
        else
        {
            return MemoryMarshal.CreateReadOnlySpan(in text._reference, length);
        }
    }

    public static unsafe ReadOnlySpan<byte> ToUtf8Span(ReadOnlySpan<char> text, WebGpuAllocatorHandle allocator)
    {
        int utf16Length = text.Length;
        Span<byte> resultSpan = allocator.AllocAsSpan<byte>((nuint)(utf16Length + utf16Length / 2));
        OperationStatus status;
        int totalCharsRead = 0;
        int totalBytesWritten = 0;
        for (; ; )
        {
            status = Utf8.FromUtf16(
                source: text[totalCharsRead..],
                destination: resultSpan[totalBytesWritten..],
                charsRead: out int charsRead,
                bytesWritten: out int bytesWritten,
                replaceInvalidSequences: false,
                isFinalBlock: true
            );
            totalCharsRead += charsRead;
            totalBytesWritten += bytesWritten;
            if (status == OperationStatus.DestinationTooSmall)
            {
                int charRemaining = text.Length - totalCharsRead;
                allocator.ReallocSpan(ref resultSpan, (nuint)(charRemaining + charRemaining / 2));
            }
            else
            {
                break;
            }
        }
        Debug.Assert(status == OperationStatus.Done);
        return resultSpan[..totalBytesWritten];
    }



    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetBorrowHandle<T>(BaseWebGpuSafeHandle<T>? safeHandle)
       where T : unmanaged, IWebGpuHandle<T>
    {
        return safeHandle?.GetHandle() ?? T.Null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetOwnedHandle<T>(BaseWebGpuSafeHandle<T> safeHandle)
        where T : unmanaged, IWebGpuHandle<T>
    {
        var handle = safeHandle.GetHandle();
        T.Reference(handle);
        return handle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RenderPassEncoderHandle GetOwnedHandle(RenderPassEncoder safeHandle)
    {
        return safeHandle.GetOwnedHandle();
    }
}