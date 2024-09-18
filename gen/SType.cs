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
    SurfaceSourceCanvasHTMLSelector_Emscripten = 262144,
    SurfaceDescriptorFromWindowsCoreWindow = 327680,
    ExternalTextureBindingEntry = 327681,
    ExternalTextureBindingLayout = 327682,
    SurfaceDescriptorFromWindowsSwapChainPanel = 327683,
    DawnTextureInternalUsageDescriptor = 327684,
    DawnEncoderInternalUsageDescriptor = 327685,
    DawnInstanceDescriptor = 327686,
    DawnCacheDeviceDescriptor = 327687,
    DawnAdapterPropertiesPowerPreference = 327688,
    DawnBufferDescriptorErrorInfoFromWireClient = 327689,
    DawnTogglesDescriptor = 327690,
    DawnShaderModuleSPIRVOptionsDescriptor = 327691,
    RequestAdapterOptionsLUID = 327692,
    RequestAdapterOptionsGetGLProc = 327693,
    RequestAdapterOptionsD3D11Device = 327694,
    DawnRenderPassColorAttachmentRenderToSingleSampled = 327695,
    RenderPassPixelLocalStorage = 327696,
    PipelineLayoutPixelLocalStorage = 327697,
    BufferHostMappedPointer = 327698,
    DawnExperimentalSubgroupLimits = 327699,
    AdapterPropertiesMemoryHeaps = 327700,
    AdapterPropertiesD3D = 327701,
    AdapterPropertiesVk = 327702,
    DawnComputePipelineFullSubgroups = 327703,
    DawnWireWGSLControl = 327704,
    DawnWGSLBlocklist = 327705,
    DrmFormatCapabilities = 327706,
    ShaderModuleCompilationOptions = 327707,
    ColorTargetStateExpandResolveTextureDawn = 327708,
    RenderPassDescriptorExpandResolveRect = 327709,
    SharedTextureMemoryVkDedicatedAllocationDescriptor = 327710,
    SharedTextureMemoryAHardwareBufferDescriptor = 327711,
    SharedTextureMemoryDmaBufDescriptor = 327712,
    SharedTextureMemoryOpaqueFDDescriptor = 327713,
    SharedTextureMemoryZirconHandleDescriptor = 327714,
    SharedTextureMemoryDXGISharedHandleDescriptor = 327715,
    SharedTextureMemoryD3D11Texture2DDescriptor = 327716,
    SharedTextureMemoryIOSurfaceDescriptor = 327717,
    SharedTextureMemoryEGLImageDescriptor = 327718,
    SharedTextureMemoryInitializedBeginState = 327719,
    SharedTextureMemoryInitializedEndState = 327720,
    SharedTextureMemoryVkImageLayoutBeginState = 327721,
    SharedTextureMemoryVkImageLayoutEndState = 327722,
    SharedTextureMemoryD3DSwapchainBeginState = 327723,
    SharedFenceVkSemaphoreOpaqueFDDescriptor = 327724,
    SharedFenceVkSemaphoreOpaqueFDExportInfo = 327725,
    SharedFenceVkSemaphoreSyncFDDescriptor = 327726,
    SharedFenceVkSemaphoreSyncFDExportInfo = 327727,
    SharedFenceVkSemaphoreZirconHandleDescriptor = 327728,
    SharedFenceVkSemaphoreZirconHandleExportInfo = 327729,
    SharedFenceDXGISharedHandleDescriptor = 327730,
    SharedFenceDXGISharedHandleExportInfo = 327731,
    SharedFenceMTLSharedEventDescriptor = 327732,
    SharedFenceMTLSharedEventExportInfo = 327733,
    SharedBufferMemoryD3D12ResourceDescriptor = 327734,
    StaticSamplerBindingLayout = 327735,
    YCbCrVkDescriptor = 327736,
    SharedTextureMemoryAHardwareBufferProperties = 327737,
    AHardwareBufferProperties = 327738,
}
