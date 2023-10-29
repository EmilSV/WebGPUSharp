using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe partial struct AdapterProperties
{
    internal AdapterPropertiesFFI _unmanagedDescriptor;

    public ref uint VendorID
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.VendorID;
    }

    public ref uint DeviceID
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.DeviceID;
    }

    public ref AdapterType AdapterType
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.AdapterType;
    }

    public ref BackendType BackendType
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.BackendType;
    }

    public ref WGPUBool CompatibilityMode
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.CompatibilityMode;
    }


    public readonly ReadOnlySpan<byte> GetVendorName() =>
        MemoryMarshal.CreateReadOnlySpanFromNullTerminated(_unmanagedDescriptor.VendorName);

    public readonly ReadOnlySpan<byte> GetArchitecture() =>
        MemoryMarshal.CreateReadOnlySpanFromNullTerminated(_unmanagedDescriptor.Architecture);

    public readonly ReadOnlySpan<byte> GetName() =>
        MemoryMarshal.CreateReadOnlySpanFromNullTerminated(_unmanagedDescriptor.Name);

    public readonly ReadOnlySpan<byte> GetDriverDescription() =>
        MemoryMarshal.CreateReadOnlySpanFromNullTerminated(_unmanagedDescriptor.DriverDescription);
}