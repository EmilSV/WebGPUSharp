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
    public static unsafe ReadOnlySpan<byte> ToUtf8Span(WGPURefText text, WebGpuAllocatorHandle allocator, bool addNullTerminator)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ReadOnlySpan<byte> TryAddNullTerminator(ReadOnlySpan<byte> utf8Span, WebGpuAllocatorHandle allocator, bool addNullTerminator)
        {
            if (addNullTerminator)
            {
                if (utf8Span[^1] == 0)
                {
                    return utf8Span;
                }

                int newSize = utf8Span.Length + 1;
                byte* result = allocator.Alloc<byte>((nuint)newSize);
                Span<byte> resultSpan = new(result, newSize);
                utf8Span.CopyTo(resultSpan);
                resultSpan[^1] = 0;
                return resultSpan[..^1];
            }
            else
            {
                if (utf8Span[^1] == 0)
                {
                    return utf8Span[..^1];
                }

                return utf8Span;
            }
        }

        var encoding = text.OutputToMatchingEncoding(out ReadOnlySpan<byte> utf8Span, out ReadOnlySpan<char> utf16Span);
        return encoding switch
        {
            WGPURefText.Encoding.Empty => [],
            WGPURefText.Encoding.Utf8 => TryAddNullTerminator(utf8Span, allocator, addNullTerminator),
            WGPURefText.Encoding.Utf16 => ToUtf8Span(utf16Span, allocator, addNullTerminator),
            _ => throw new ArgumentOutOfRangeException(nameof(text), encoding, null),
        };
    }

    public static unsafe Span<byte> ToUtf8Span(ReadOnlySpan<char> text, WebGpuAllocatorHandle allocator, bool addNullTerminator)
    {
        if (text.IsEmpty)
        {
            return [];
        }

        int utf16Length = text.Length;
        nuint allocSize = (nuint)(utf16Length + utf16Length / 2 + (addNullTerminator ? 1 : 0));
        Span<byte> resultSpan = allocator.AllocAsSpan<byte>(allocSize);
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
                allocSize = (nuint)(charRemaining + charRemaining / 2 + (addNullTerminator ? 1 : 0));
                allocator.ReallocSpan(ref resultSpan, allocSize);
            }
            else
            {
                break;
            }
        }
        if (addNullTerminator)
        {
            resultSpan[totalBytesWritten] = 0;
            totalBytesWritten++;
        }

        Debug.Assert(status == OperationStatus.Done);
        return resultSpan[..totalBytesWritten];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe StringViewFFI ToStringViewFFI(string? text, WebGpuAllocatorHandle allocator)
    {
        if (text == null)
        {
            return ToStringViewFFI(ReadOnlySpan<char>.Empty, allocator);
        }
        else
        {
            return ToStringViewFFI(text.AsSpan(), allocator);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe StringViewFFI ToStringViewFFI(ReadOnlySpan<char> text, WebGpuAllocatorHandle allocator)
    {
        var utf8Span = ToUtf8Span(text, allocator, addNullTerminator: false);
        return StringViewFFI.CreateExplicitlySized(
            data: (byte*)Unsafe.AsPointer(ref utf8Span.GetPinnableReference()),
            length: (nuint)utf8Span.Length
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetBorrowHandle<T>(WebGPUHandleWrapperBase<T>? safeHandle)
        where T : unmanaged, IWebGpuHandle<T>, IEquatable<T>
    {
        if (safeHandle == null)
        {
            return T.Null;
        }
        return WebGPUHandleWrapperBase<T>.GetHandle(safeHandle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetOwnedHandle<T>(WebGPUHandleWrapperBase<T> safeHandle)
        where T : unmanaged, IWebGpuHandle<T>, IEquatable<T>
    {
        if (safeHandle == null)
        {
            return T.Null;
        }
        var handle = WebGPUHandleWrapperBase<T>.GetHandle(safeHandle);
        T.Reference(handle);
        return handle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrAndLength<THandle> GetBorrowHandlesAsPtrAndLength<THandle, TWrapper>(
        ReadOnlySpan<TWrapper> safeHandles,
        WebGpuAllocatorHandle allocatorHandle)
        where TWrapper : WebGPUHandleWrapperBase<THandle>
        where THandle : unmanaged, IWebGpuHandle<THandle>, IEquatable<THandle>
    {
        if (safeHandles.IsEmpty)
        {
            return default;
        }

        var length = (nuint)safeHandles.Length;
        THandle* handles = allocatorHandle.Alloc<THandle>(length);
        for (int i = 0; i < safeHandles.Length; i++)
        {
            handles[i] = GetBorrowHandle(safeHandles[i]);
        }
        return new(handles, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RenderPassEncoderHandle GetOwnedHandle(RenderPassEncoder safeHandle)
    {
        return safeHandle.GetOwnedHandle();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RenderBundleEncoderHandle GetOwnedHandle(RenderBundleEncoder safeHandle)
    {
        return safeHandle.GetOwnedHandle();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSafeHandle? ToSafeHandle<TSafeHandle, THandle>(THandle handle)
        where TSafeHandle : IFromHandle<TSafeHandle, THandle>
         where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        return TSafeHandle.FromHandleNoRefIncrement(handle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSafeHandle? ToSafeHandleNoRefIncrement<TSafeHandle, THandle>(THandle handle)
        where TSafeHandle : IFromHandle<TSafeHandle, THandle>
    {
        return TSafeHandle.FromHandleNoRefIncrement(handle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsHandleWrapperSameLifetime<THandle>(WebGPUHandleWrapperBase<THandle> handleWrapper)
        where THandle : unmanaged, IEquatable<THandle>
    {
        return WebGPUHandleWrapperBase<THandle>.IsHandleWrapperSameLifetime(handleWrapper);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* AllocUserData(object? userData)
    {
        if (userData == null)
        {
            return null;
        }

        var userDataHandle = GCHandle.Alloc(userData);
        return (void*)GCHandle.ToIntPtr(userDataHandle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe object? GetObjectFromUserData(void* userData)
    {
        if (userData == null)
        {
            return null;
        }

        var userDataHandle = GCHandle.FromIntPtr((nint)userData);
        return userDataHandle.Target;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe object? ConsumeUserDataIntoObject(void* userData)
    {
        if (userData == null)
        {
            return null;
        }

        var userDataHandle = GCHandle.FromIntPtr((nint)userData);
        if (!userDataHandle.IsAllocated)
        {
            return null;
        }

        var target = userDataHandle.Target;
        userDataHandle.Free();
        return target;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void FreeUserData(void* userData)
    {
        if (userData == null)
        {
            return;
        }

        var userDataHandle = Unsafe.BitCast<nuint, GCHandle>((nuint)userData);
        if (userDataHandle.IsAllocated)
        {
            userDataHandle.Free();
        }
    }
}