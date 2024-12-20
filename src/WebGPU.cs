namespace WebGpuSharp;

public static unsafe partial class WebGPU
{
    public static Instance? CreateInstance()
    {
        InstanceDescriptor descriptor = default;
        return WebGPU_FFI.CreateInstance(&descriptor).ToSafeHandle(false);
    }

    public static Instance? CreateInstance(in InstanceDescriptor descriptor)
    {
        fixed (InstanceDescriptor* pDescriptor = &descriptor)
        {
            return WebGPU_FFI.CreateInstance(pDescriptor).ToSafeHandle(false);
        }
    }
}