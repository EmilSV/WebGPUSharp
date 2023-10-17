namespace WebGpuSharp.FFI;

public readonly partial struct CommandBufferHandle : IDisposable
{
    public void Dispose()
    {
        unsafe
        {
            if (_ptr != UIntPtr.Zero)
            {
                WebGPU_FFI.CommandBufferRelease(this);
            }
        }
    }
}
