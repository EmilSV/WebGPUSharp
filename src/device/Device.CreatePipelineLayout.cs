using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {

        public readonly PipelineLayoutHandle CreatePipelineLayout(
            ReadOnlySpan<BindGroupLayoutHandle> bindGroupLayouts
        )
        {
            return CreatePipelineLayout(default, bindGroupLayouts);
        }

        public readonly PipelineLayoutHandle CreatePipelineLayout(
            WGPURefText label,
            ReadOnlySpan<BindGroupLayoutHandle> bindGroupLayouts
        )
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (byte* labelPtr = label)
            fixed (BindGroupLayoutHandle* BindGroupLayoutsPtr = bindGroupLayouts)
            {
                PipelineLayoutDescriptorFFI pipelineLayoutDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        length: label.Length,
                        is16BitSize: label.Is16BitSize,
                        allowPassthrough: true
                    ),
                    BindGroupLayoutCount = (uint)bindGroupLayouts.Length,
                    BindGroupLayouts = BindGroupLayoutsPtr,
                };

                return WebGPU_FFI.DeviceCreatePipelineLayout(this, &pipelineLayoutDescriptor);
            }
        }

        public readonly PipelineLayoutHandle CreatePipelineLayout(
            BindGroupLayoutList bindGroupLayouts
        )
        {
            return CreatePipelineLayout(default, bindGroupLayouts);
        }

        public readonly PipelineLayoutHandle CreatePipelineLayout(
            WGPURefText label,
            BindGroupLayoutList bindGroupLayouts
        )
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (byte* labelPtr = label)
            {
                PipelineLayoutDescriptorFFI pipelineLayoutDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        length: label.Length,
                        is16BitSize: label.Is16BitSize,
                        allowPassthrough: true
                    ),
                    BindGroupLayoutCount = (uint)bindGroupLayouts.Count,
                    BindGroupLayouts = bindGroupLayouts.GetPointerToFFIItems(allocator)
                };

                return WebGPU_FFI.DeviceCreatePipelineLayout(this, &pipelineLayoutDescriptor);
            }
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public PipelineLayout? CreatePipelineLayout(
            BindGroupLayoutList bindGroupLayouts
        )
        {
            return CreatePipelineLayout(default, bindGroupLayouts);
        }

        public PipelineLayout? CreatePipelineLayout(
            WGPURefText label,
            BindGroupLayoutList bindGroupLayouts
        )
        {
            return PipelineLayout.FromHandle(_handle.CreatePipelineLayout(label, bindGroupLayouts));
        }
    }
}