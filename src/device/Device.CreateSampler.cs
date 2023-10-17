using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public readonly SamplerHandle CreateSampler(in SamplerDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (SamplerDescriptorFFI* descriptorPtr = &descriptor._unsafeDescriptor)
            fixed (byte* labelPtr = descriptor.Label)
            {
                descriptorPtr->Label = utf8Factory.Create(
                    text: labelPtr,
                    length: descriptor.Label.Length,
                    is16BitSize: descriptor.Label.Is16BitSize,
                    allowPassthrough: true
                );

                return WebGPU_FFI.DeviceCreateSampler(this, descriptorPtr);
            }
        }

        public readonly SamplerHandle CreateSampler(
            WGPURefText label = default,
            AddressMode addressModeU = default,
            AddressMode addressModeV = default,
            AddressMode addressModeW = default,
            FilterMode magFilter = default,
            FilterMode minFilter = default,
            MipmapFilterMode mipmapFilter = default,
            float lodMinClamp = default,
            float lodMaxClamp = default,
            CompareFunction compare = default,
            ushort maxAnisotropy = default
        )
        {
            return CreateSampler(new SamplerDescriptor(
                label: label,
                addressModeU: addressModeU,
                addressModeV: addressModeV,
                addressModeW: addressModeW,
                magFilter: magFilter,
                minFilter: minFilter,
                mipmapFilter: mipmapFilter,
                lodMinClamp: lodMinClamp,
                lodMaxClamp: lodMaxClamp,
                compare: compare,
                maxAnisotropy: maxAnisotropy
            ));
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public Sampler? CreateSampler(in SamplerDescriptor descriptor)
        {
            return Sampler.FromHandle(_handle.CreateSampler(descriptor));
        }

        public Sampler? CreateSampler(
            WGPURefText label = default,
            AddressMode addressModeU = default,
            AddressMode addressModeV = default,
            AddressMode addressModeW = default,
            FilterMode magFilter = default,
            FilterMode minFilter = default,
            MipmapFilterMode mipmapFilter = default,
            float lodMinClamp = default,
            float lodMaxClamp = default,
            CompareFunction compare = default,
            ushort maxAnisotropy = default
        )
        {
            return Sampler.FromHandle(_handle.CreateSampler(
                label,
                addressModeU,
                addressModeV,
                addressModeW,
                magFilter,
                minFilter,
                mipmapFilter,
                lodMinClamp,
                lodMaxClamp,
                compare,
                maxAnisotropy
            ));
        }
    }
}