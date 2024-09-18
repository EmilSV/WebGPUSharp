using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct SurfaceDescriptor
{
    internal ref ChainedStruct _next;
    public WGPURefText Label;

    public SurfaceDescriptor(ref SurfaceDescriptorFromCanvasHTMLSelectorFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromXlibWindowFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromMetalLayerFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromWaylandSurfaceFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromAndroidNativeWindowFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromWindowsHWNDFFI chain)
    {
        _next = ref chain.Value.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromWindowsSwapChainPanelFFI chain)
    {
        _next = ref chain.Chain;
    }

    public SurfaceDescriptor(ref SurfaceDescriptorFromWindowsCoreWindowFFI chain)
    {
        _next = ref chain.Chain;
    }
}