using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct SurfaceDescriptor
{
    internal ref ChainedStruct _next;
    public WGPURefText Label;

    public SurfaceDescriptor(ref SurfaceSourceXCBWindowFFI source)
    {
        _next = ref source.Chain;
    }

    public SurfaceDescriptor(ref SurfaceSourceMetalLayerFFI source)
    {
        _next = ref source.Chain;
    }

    public SurfaceDescriptor(ref SurfaceSourceXlibWindowFFI source)
    {
        _next = ref source.Chain;
    }

    public SurfaceDescriptor(ref SurfaceSourceWindowsHWNDFFI source)
    {
        _next = ref source.Chain;
    }

    public SurfaceDescriptor(ref SurfaceSourceWaylandSurfaceFFI source)
    {
        _next = ref source.Chain;
    }

    public SurfaceDescriptor(ref SurfaceSourceAndroidNativeWindowFFI source)
    {
        _next = ref source.Chain;
    }
}