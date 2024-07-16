using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct SurfaceHandle :
    IDisposable, IWebGpuHandle<SurfaceHandle, Surface>
{
    public TextureFormat GetPreferredFormat(AdapterHandle adapter) =>
        WebGPU_FFI.SurfaceGetPreferredFormat(this, adapter);
    public TextureFormat GetPreferredFormat(Adapter adapter) =>
        GetPreferredFormat((AdapterHandle)adapter);


    public void Configure(in SurfaceConfigurationFFI configuration)
    {
        fixed (SurfaceConfigurationFFI* configurationPtr = &configuration)
        {
            WebGPU_FFI.SurfaceConfigure(this, configurationPtr);
        }
    }

    public void Configure(in SurfaceConfiguration configuration)
    {
        fixed (TextureFormat* ViewFormatsPtr = configuration.ViewFormats)
        {
            SurfaceConfigurationFFI surfaceConfigurationFFI = new(
                device: (DeviceHandle)configuration.Device,
                format: configuration.Format,
                usage: configuration.Usage,
                viewFormatCount: (nuint)configuration.ViewFormats.Length,
                viewFormats: ViewFormatsPtr,
                alphaMode: configuration.AlphaMode,
                width: configuration.Width,
                height: configuration.Height,
                presentMode: configuration.PresentMode
            );
            WebGPU_FFI.SurfaceConfigure(this, &surfaceConfigurationFFI);
        }
    }

    public Status GetCapabilities(AdapterHandle adapter, ref SurfaceCapabilitiesFFI capabilities)
    {
        fixed (SurfaceCapabilitiesFFI* capabilitiesPtr = &capabilities)
        {
            return WebGPU_FFI.SurfaceGetCapabilities(this, adapter, capabilitiesPtr);
        }
    }

    public void GetCurrentTexture(ref SurfaceTextureFFI surfaceTexture)
    {
        fixed (SurfaceTextureFFI* surfaceTexturePtr = &surfaceTexture)
        {
            WebGPU_FFI.SurfaceGetCurrentTexture(this, surfaceTexturePtr);
        }
    }

    public void GetCurrentTexture(ref SurfaceTexture surfaceTexture)
    {
        surfaceTexture.InternalSetSurfaceTextureFFI(this);
    }

    public void Present()
    {
        WebGPU_FFI.SurfacePresent(this);
    }

    public void Unconfigure()
    {
        WebGPU_FFI.SurfaceUnconfigure(this);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.SurfaceRelease(this);
        }
    }

    public static ref nuint AsPointer(ref SurfaceHandle handle)
    {
        return ref Unsafe.As<SurfaceHandle, nuint>(ref handle);
    }

    public static SurfaceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(SurfaceHandle handle)
    {
        return handle == Null;
    }

    public static SurfaceHandle UnsafeFromPointer(nuint pointer)
    {
        return new SurfaceHandle(pointer);
    }

    public static void Reference(SurfaceHandle handle)
    {
        WebGPU_FFI.SurfaceAddRef(handle);
    }

    public static void Release(SurfaceHandle handle)
    {
        WebGPU_FFI.SurfaceRelease(handle);
    }

    public Surface? ToSafeHandle(bool isOwnedHandle)
    {
        return Surface.FromHandle(this, isOwnedHandle);
    }
}