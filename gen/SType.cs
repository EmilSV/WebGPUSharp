using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum SType
{
    ShaderSourceSPIRV = 1,
    ShaderSourceWGSL = 2,
    RenderPassMaxDrawCount = 3,
    SurfaceSourceMetalLayer = 4,
    SurfaceSourceWindowsHWND = 5,
    SurfaceSourceXlibWindow = 6,
    SurfaceSourceWaylandSurface = 7,
    SurfaceSourceAndroidNativeWindow = 8,
    SurfaceSourceXCBWindow = 9,
    TextureBindingViewDimensionDescriptor = 131072,
}
