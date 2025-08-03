using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

internal static class WebGpuManagedSpanBuilder
{
    internal static WebGpuManagedSpan<T> Create<T>(ReadOnlySpan<T> span)
    {
        return new WebGpuManagedSpan<T>(span.ToArray());
    }
}

[CollectionBuilder(typeof(WebGpuManagedSpanBuilder), "Create")]
public readonly struct WebGpuManagedSpan<T>
{


    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct NullRef { }

    private readonly IReadOnlyList<T>? _listLike;
    private readonly int _start;
    private readonly int _count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WebGpuManagedSpan(T[] array)
    {
        _listLike = array;
        _start = 0;
        _count = array.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WebGpuManagedSpan(T[] array, int start, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(start, nameof(start));
        ArgumentOutOfRangeException.ThrowIfNegative(count, nameof(count));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(array.Length - start, count, nameof(count));
        _listLike = array ?? throw new ArgumentNullException(nameof(array), "Array must not be null.");
        _start = start;
        _count = count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WebGpuManagedSpan(ArraySegment<T> array)
    {
        _listLike = array.Array ?? throw new ArgumentNullException(nameof(array), "ArraySegment must have a non-null array.");
        _start = array.Offset;
        _count = array.Count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WebGpuManagedSpan(List<T> list)
    {
        _listLike = list ?? throw new ArgumentNullException(nameof(list), "List must not be null.");
        _start = 0;
        _count = -1; // Indicates the entire list
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WebGpuManagedSpan(List<T> list, int start, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(start, nameof(start));
        ArgumentOutOfRangeException.ThrowIfNegative(count, nameof(count));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(list.Count - start, count, nameof(count));
        _listLike = list ?? throw new ArgumentNullException(nameof(list), "List must not be null.");
        _start = start;
        _count = count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WebGpuManagedSpan<T>(NullRef? _)
    {
        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WebGpuManagedSpan<T>(T[] array)
    {
        return new WebGpuManagedSpan<T>(array);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WebGpuManagedSpan<T>(List<T> list)
    {
        return new WebGpuManagedSpan<T>(list);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WebGpuManagedSpan<T>(ArraySegment<T> array)
    {
        return new WebGpuManagedSpan<T>(array);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ReadOnlySpan<T> InternalGetAsSpan()
    {
        if (_listLike is T[] array)
        {
            return array.AsSpan(_start, _count);
        }
        else if (_listLike is List<T> list)
        {
            var length = _count >= 0 ? _count : list.Count - _start;

            if (_start + length > list.Count)
            {
                throw new WebGPUException("The specified range is out of bounds of the list.");
            }

            return CollectionsMarshal.AsSpan(list).Slice(_start, length);
        }
        else if (_listLike is null)
        {
            // If _listLike is null or an IReadOnlyList, we return an empty span
            return ReadOnlySpan<T>.Empty;
        }
        else
        {
            throw new InvalidOperationException("Unsupported type for WebGpuManagedSpan.");
        }
    }
}