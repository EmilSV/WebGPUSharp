using WebGpuSharp;
using WebGPUSharp.Internal;

internal class WebGPUEventHandlerBrowser : WebGPUEventHandlerBase
{
    public override void Dispose()
    {

    }

    public override void EnqueueFuture(WebGpuAsyncApi api, Future future)
    {

    }


    public override CallbackMode GetCallbackMode(WebGpuAsyncApi api)
    {
        return CallbackMode.AllowSpontaneous;
    }


    public override bool IsSyncApiSupported(WebGpuAsyncApi api) => api switch
    {
        WebGpuAsyncApi.DeviceCreateRenderPipeline => true,
        WebGpuAsyncApi.DeviceCreateComputePipeline => true,
        _ => false,
    };

    public override void Start()
    {
    }
}