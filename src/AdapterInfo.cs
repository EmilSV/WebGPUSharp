using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="AdapterInfoFFI" />
public class AdapterInfo
{
    /// <inheritdoc cref="AdapterInfoFFI.Vendor" />
    public readonly string? Vendor;
    /// <inheritdoc cref="AdapterInfoFFI.Architecture" />
    public readonly string? Architecture;
    /// <inheritdoc cref="AdapterInfoFFI.Device" />
    public readonly string? Device;
    /// <inheritdoc cref="AdapterInfoFFI.Description" />
    public readonly string? Description;
    /// <inheritdoc cref="AdapterInfoFFI.BackendType" />
    public readonly BackendType BackendType;
    /// <inheritdoc cref="AdapterInfoFFI.AdapterType" />
    public readonly AdapterType AdapterType;
    /// <inheritdoc cref="AdapterInfoFFI.VendorID" />
    public readonly uint VendorID;
    /// <inheritdoc cref="AdapterInfoFFI.DeviceID" />
    public readonly uint DeviceID;

    unsafe internal AdapterInfo(in AdapterInfoFFI adapterInfoFFI)
    {
        static string? GetString(StringViewFFI stringView)
        {
            if (stringView.Data == null || stringView.Length == 0)
            {
                return null;
            }

            return Encoding.UTF8.GetString(stringView.AsSpan());
        }

        Vendor = GetString(adapterInfoFFI.Vendor);
        Architecture = GetString(adapterInfoFFI.Architecture);
        Device = GetString(adapterInfoFFI.Device);
        Description = GetString(adapterInfoFFI.Description);
        BackendType = adapterInfoFFI.BackendType;
        AdapterType = adapterInfoFFI.AdapterType;
        VendorID = adapterInfoFFI.VendorID;
        DeviceID = adapterInfoFFI.DeviceID;
    }
}