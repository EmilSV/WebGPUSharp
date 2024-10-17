using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public class AdapterInfo
{
    public readonly string? Vendor;
    public readonly string? Architecture;
    public readonly string? Device;
    public readonly string? Description;
    public readonly BackendType BackendType;
    public readonly AdapterType AdapterType;
    public readonly uint VendorID;
    public readonly uint DeviceID;

    unsafe internal AdapterInfo(AdapterInfoFFI adapterInfoFFI)
    {
        static string? GetString(byte* ptr)
        {
            if (ptr == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ptr));
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