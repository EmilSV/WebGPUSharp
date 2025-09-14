using System.Runtime.CompilerServices;
using static WebGpuSharp.Marshalling.WebGPUMarshal;


namespace WebGpuSharp.FFI;

public unsafe readonly partial struct SurfaceHandle :
    IDisposable, IWebGpuHandle<SurfaceHandle, Surface>
{
    /// <inheritdoc cref="Configure(SurfaceConfigurationFFI*)"/>
    public void Configure(in SurfaceConfigurationFFI configuration)
    {
        fixed (SurfaceConfigurationFFI* configurationPtr = &configuration)
        {
            WebGPU_FFI.SurfaceConfigure(this, configurationPtr);
        }
    }

    /// <inheritdoc cref="Configure(SurfaceConfigurationFFI*)"/>
    public void Configure(in SurfaceConfiguration configuration)
    {
        fixed (TextureFormat* ViewFormatsPtr = configuration.ViewFormats)
        {
            SurfaceConfigurationFFI surfaceConfigurationFFI = new()
            {
                Device = GetBorrowHandle(configuration.Device),
                Format = configuration.Format,
                Usage = configuration.Usage,
                ViewFormatCount = (nuint)configuration.ViewFormats.Length,
                ViewFormats = ViewFormatsPtr,
                AlphaMode = configuration.AlphaMode,
                Width = configuration.Width,
                Height = configuration.Height,
                PresentMode = configuration.PresentMode
            };
            WebGPU_FFI.SurfaceConfigure(this, &surfaceConfigurationFFI);
        }
    }

    /// <inheritdoc cref="GetCapabilities(AdapterHandle, SurfaceCapabilitiesFFI*)"/>
    public Status GetCapabilities(AdapterHandle adapter, ref SurfaceCapabilitiesFFI capabilities)
    {
        fixed (SurfaceCapabilitiesFFI* capabilitiesPtr = &capabilities)
        {
            return WebGPU_FFI.SurfaceGetCapabilities(this, adapter, capabilitiesPtr);
        }
    }

    /// <inheritdoc cref="GetCurrentTexture(SurfaceTextureFFI*)"/>
    public void GetCurrentTexture(ref SurfaceTextureFFI surfaceTexture)
    {
        fixed (SurfaceTextureFFI* surfaceTexturePtr = &surfaceTexture)
        {
            WebGPU_FFI.SurfaceGetCurrentTexture(this, surfaceTexturePtr);
        }
    }

    /// <inheritdoc cref="GetCurrentTexture(SurfaceTextureFFI*)"/>
    public void GetCurrentTexture(ref SurfaceTexture surfaceTexture)
    {
        surfaceTexture.InternalSetSurfaceTextureFFI(this);
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

    public Surface? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Surface, SurfaceHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Surface, SurfaceHandle>(this);
        }
    }
}