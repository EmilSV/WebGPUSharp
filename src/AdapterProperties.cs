using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe partial struct AdapterProperties
{
    internal AdapterPropertiesFFI _unmanagedDescriptor;

    public readonly uint VendorID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _unmanagedDescriptor.VendorID;
    }

    public readonly uint DeviceID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _unmanagedDescriptor.DeviceID;
    }

    public readonly AdapterType AdapterType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _unmanagedDescriptor.AdapterType;
    }

    public readonly BackendType BackendType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _unmanagedDescriptor.BackendType;
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