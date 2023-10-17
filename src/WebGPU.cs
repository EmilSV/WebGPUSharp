using WebGpuSharp.FFI;

namespace WebGpuSharp;

public static unsafe partial class WebGPU
{
    public static InstanceHandle CreateInstance()
    {
        unsafe
        {
            InstanceDescriptor descriptor = default;
            return WebGPU_FFI.CreateInstance(&descriptor);
        }
    }

    public static InstanceHandle CreateInstance(in InstanceDescriptor descriptor)
    {
        unsafe
        {
            fixed (InstanceDescriptor* pDescriptor = &descriptor)
            {
                return WebGPU_FFI.CreateInstance(pDescriptor);
            }
        }
    }
}