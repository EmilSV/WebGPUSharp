using WebGpuSharp;
using WebGPUSharp.Internal;

internal class WebGPUEventHandlerBrowser : WebGPUEventHandlerBase
{
    public override void Dispose()
    {

    }

    public override void EnqueueCpuFuture(Future future)
    {

    }

    public override void EnqueueQueueFuture(Future future)
    {

    }

    public override CallbackMode GetCpuCallbackMode()
    {
        return CallbackMode.AllowSpontaneous;
    }

    public override CallbackMode GetQueueCallbackMode()
    {
        return CallbackMode.AllowSpontaneous;
    }

    public override void Start()
    {
    }
}