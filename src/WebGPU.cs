using WebGpuSharp.FFI;

namespace WebGpuSharp;

public static unsafe partial class WebGPU
{
    /// <inheritdoc cref="WebGPU_FFI.CreateInstance" />
    public static Instance? CreateInstance()
    {
        InstanceDescriptor descriptor = default;
        return WebGPU_FFI.CreateInstance(&descriptor).ToSafeHandle(false);
    }

    /// <inheritdoc cref="WebGPU_FFI.CreateInstance(InstanceDescriptor*)" />
    public static Instance? CreateInstance(in InstanceDescriptor descriptor)
    {
        fixed (InstanceDescriptor* pDescriptor = &descriptor)
        {
            return WebGPU_FFI.CreateInstance(pDescriptor).ToSafeHandle(false);
        }
    }
}