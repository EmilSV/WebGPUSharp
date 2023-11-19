using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;


public unsafe static class WebGPUHandleInterlock
{


    /// <summary>
    /// Sets a WebGpuHandle to a specified value and returns the original value, as an atomic operation.
    /// </summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    /// <exception cref="NotSupportedException">The handle type is the same size a pointer.</exception>
    /// <typeparam name="T">The type to be used for <paramref name="location1"/> and <paramref name="value"/>. This type must be a unmanaged, IWebGpuHandle with the same size as a pointer.</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Exchange<T>(ref T location1, T value)
        where T : unmanaged, IWebGpuHandle<T>
    {
        if (sizeof(T) != sizeof(nuint))
        {
            throw new NotSupportedException("WebGPUHandleInterlock only supports handles that are the size of a pointer");
        }

        ref nuint refLocationPtr = ref T.AsPointer(ref location1);
        nuint valuePtr = T.AsPointer(ref value);
        nuint originalValue = Interlocked.Exchange(ref refLocationPtr, valuePtr);
        return T.UnsafeFromPointer(originalValue);
    }


    /// <summary>Compares two platform-specific handles or pointers for equality and, if they are equal, replaces the first one.</summary>
    /// <param name="location1">The destination WebGpuHandle, whose value is compared with the value of <paramref name="comparand"/> and possibly replaced by <paramref name="value"/>.</param>
    /// <param name="value">The WebGpuHandle that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The WebGpuHandle that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    /// <exception cref="NotSupportedException">The handle type is the same size a pointer.</exception>
    /// <typeparam name="T">The type to be used for location1, value and comparand. This type must be a unmanaged, IWebGpuHandle with the same size as a pointer</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T CompareExchange<T>(ref T location1, T value, T comparand)
        where T : unmanaged, IWebGpuHandle<T>
    {
        if (sizeof(T) != sizeof(nuint))
        {
            throw new NotSupportedException("WebGPUHandleInterlock only supports handles that are the size of a pointer");
        }

        ref nuint refLocationPtr = ref T.AsPointer(ref location1);
        nuint valuePtr = T.AsPointer(ref value);
        nuint comparandPtr = T.AsPointer(ref comparand);
        nuint originalValue = Interlocked.CompareExchange(ref refLocationPtr, valuePtr, comparandPtr);
        return T.UnsafeFromPointer(originalValue);
    }
}