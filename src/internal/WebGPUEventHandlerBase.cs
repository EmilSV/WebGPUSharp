using WebGpuSharp;

namespace WebGPUSharp.Internal;

abstract class WebGPUEventHandlerBase : IDisposable
{
    public abstract void Start();

    public abstract CallbackMode GetCallbackMode(WebGpuAsyncApi api);

    public abstract void EnqueueFuture(WebGpuAsyncApi api, Future future);

    public abstract bool IsSyncApiSupported(WebGpuAsyncApi api);

    public abstract void Dispose();
}