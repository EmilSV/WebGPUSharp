using WebGpuSharp;

namespace WebGPUSharp.Internal;

abstract class WebGPUEventHandlerBase : IDisposable
{
    public abstract void Start();

    public abstract CallbackMode GetCpuCallbackMode();
    public abstract CallbackMode GetQueueCallbackMode();

    public abstract void EnqueueCpuFuture(Future future);
    public abstract void EnqueueQueueFuture(Future future);

    public abstract void Dispose();
}