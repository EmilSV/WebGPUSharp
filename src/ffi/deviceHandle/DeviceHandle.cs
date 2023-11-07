using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct DeviceHandle : IDisposable, IWebGpuHandle<DeviceHandle, Device>
{
    public BindGroupHandle CreateBindGroup(in BindGroupDescriptorFFI descriptor)
    {
        fixed (BindGroupDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroup(this, descriptorPtr);
        }
    }

    public BindGroupHandle CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        ToFFI(
            input: descriptor.Entries,
            allocator: allocator,
            dest: out BindGroupEntryFFI* entriesPtr,
            outCount: out nuint entriesCount
        );
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            BindGroupDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            ToFFI(descriptor.Layout, out descriptorFFI.Layout);
            descriptorFFI.EntryCount = entriesCount;
            descriptorFFI.Entries = entriesPtr;
            return WebGPU_FFI.DeviceCreateBindGroup(this, &descriptorFFI);
        }
    }

    public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptorFFI descriptor)
    {
        fixed (BindGroupLayoutDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroupLayout(this, descriptorPtr);
        }
    }

    public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (BindGroupLayoutEntry* entriesPtr = descriptor.Entries)
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            return CreateBindGroupLayout(new BindGroupLayoutDescriptorFFI(
                label: labelPtr,
                entries: entriesPtr,
                entryCount: (nuint)descriptor.Entries.Length
            ));
        }
    }

    public BufferHandle CreateBuffer(ref BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            descriptorPtr->Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, descriptorPtr);
        }
    }

    public BufferHandle CreateBuffer(BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unmanagedDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, &descriptor._unmanagedDescriptor);
        }
    }

    public CommandEncoderHandle CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            CommandEncoderDescriptorFFI commandEncoderDescriptor = new(label: LabelPtr);
            return WebGPU_FFI.DeviceCreateCommandEncoder(this, &commandEncoderDescriptor);
        }
    }

    public ComputePipelineHandle CreateComputePipeline(in ComputePipelineDescriptorFFI descriptor)
    {
        fixed (ComputePipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateComputePipeline(this, descriptorPtr);
        }
    }


    public ComputePipelineHandle CreateComputePipeline(in ComputePipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* entryPointPtr = ToRefCstrUtf8(descriptor.Compute.EntryPoint, allocator))
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new(
                label: labelPtr,
                layout: (PipelineLayoutHandle)descriptor.Layout,
                compute: new(
                    module: (ShaderModuleHandle)descriptor.Compute.Module,
                    entryPoint: entryPointPtr,
                    constantCount: constantEntryCount,
                    constants: constantEntryPtr
                )
            
            );

            return WebGPU_FFI.DeviceCreateComputePipeline(this, &descriptorFFI);
        }
    }


    public PipelineLayoutHandle CreatePipelineLayout(in PipelineLayoutDescriptorFFI descriptor)
    {
        fixed (PipelineLayoutDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptorPtr);
        }
    }

    public PipelineLayoutHandle CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            PipelineLayoutDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            ToFFI(
                descriptor.BindGroupLayouts,
                allocator,
                out descriptorFFI.BindGroupLayouts,
                out descriptorFFI.BindGroupLayoutCount
            );

            return CreatePipelineLayout(descriptorFFI);
        }
    }

    public RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptorFFI descriptor)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptorPtr);
        }
    }

    public RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            ToFFI(descriptor.Layout, out descriptorFFI.Layout);
            ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
            descriptorFFI.Primitive = descriptor.Primitive;
            descriptorFFI.DepthStencil = depthStencilPtr;
            descriptorFFI.Multisample = descriptor.Multisample;
            ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

            return CreateRenderPipeline(descriptorFFI);
        }
    }

    public SamplerHandle CreateSampler(ref SamplerDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        SamplerDescriptorFFI descriptorFFI = descriptor._unsafeDescriptor;

        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptorFFI.Label = labelPtr;
            return WebGPU_FFI.DeviceCreateSampler(this, &descriptorFFI);
        }
    }

    public SamplerHandle CreateSampler(SamplerDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unsafeDescriptor.Label = labelPtr;
            return WebGPU_FFI.DeviceCreateSampler(this, &descriptor._unsafeDescriptor);
        }
    }

    public readonly void AddDeviceLostCallback(DeviceLostCallbackDelegate callback)
    {
        DeviceLostCallbackHandler.AddDeviceLostCallback(this, callback);
    }

    public readonly void RemoveDeviceLostCallback(DeviceLostCallbackDelegate callback)
    {
        DeviceLostCallbackHandler.RemoveDeviceLostCallback(this, callback);
    }

    public QueueHandle GetQueue()
    {
        return WebGPU_FFI.DeviceGetQueue(this);
    }

    public void AddUncapturedErrorCallback(UncapturedErrorDelegate callback)
    {
        UncapturedErrorCallbackHandler.AddUncapturedErrorCallback(this, callback);
    }

    public void RemoveUncapturedErrorCallback(UncapturedErrorDelegate callback)
    {
        UncapturedErrorCallbackHandler.RemoveUncapturedErrorCallback(this, callback);
    }

    public void Tick()
    {
        WebGPU_FFI.DeviceTick(this);
    }

    public SwapChainHandle CreateSwapChain(SurfaceHandle surface, ref SwapChainDescriptor descriptor)
    {
        WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (SwapChainDescriptorFFI* descriptorPtr = &descriptor._unsafeDescriptor)
        {
            descriptorPtr->Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateSwapChain(this, surface, descriptorPtr);
        }
    }

    public SwapChainHandle CreateSwapChain(SurfaceHandle surface, SwapChainDescriptor descriptor)
    {
        WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unsafeDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateSwapChain(this, surface, &descriptor._unsafeDescriptor);
        }
    }

    public ShaderModuleHandle CreateShaderModule(in ShaderModuleDescriptor descriptor)
    {
        if (descriptor.IsWgslNext())
        {
            return CreateShaderModuleWgsl(descriptor, descriptor.GetNextWgsl().Code);
        }
        else if (descriptor.IsSpirvNext())
        {
            throw new NotImplementedException();
            //return CreateShaderModuleSpirv(descriptor, descriptor.GetNextSpirv().Code);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private ShaderModuleHandle CreateShaderModuleWgsl(in ShaderModuleDescriptor descriptor, WGPURefText code)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* codePtr = ToRefCstrUtf8(code, allocator))
        {

            ShaderModuleWGSLDescriptorFFI shaderModuleWGSLDescriptor = new(
                chain: new ChainedStruct(
                    next: null,
                    sType: SType.ShaderModuleWGSLDescriptor
                ),
                code: codePtr
            );

            ShaderModuleDescriptorFFI shaderModuleDescriptor = new(
                nextInChain: &shaderModuleWGSLDescriptor.Chain,
                label: labelPtr
            );

            return WebGPU_FFI.DeviceCreateShaderModule(this, &shaderModuleDescriptor);
        }
    }

    [SkipLocalsInit]
    public SupportedLimits GetLimits()
    {
        SupportedLimits supportedLimits;
        WebGPU_FFI.DeviceGetLimits(this, &supportedLimits);
        return supportedLimits;
    }

    public void GetLimits(ref SupportedLimits supportedLimits)
    {
        fixed (SupportedLimits* supportedLimitsPtr = &supportedLimits)
        {
            WebGPU_FFI.DeviceGetLimits(this, supportedLimitsPtr);
        }
    }

    public TextureHandle CreateTexture(ref TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        fixed (TextureDescriptorFFI* textureDescriptorPtr = &textureDescriptor._unmanagedDescriptor)
        {
            textureDescriptorPtr->Label = labelPtr;
            textureDescriptorPtr->ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptorPtr->ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, textureDescriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TextureHandle CreateTexture(TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        {
            textureDescriptor._unmanagedDescriptor.Label = labelPtr;
            textureDescriptor._unmanagedDescriptor.ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptor._unmanagedDescriptor.ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, &textureDescriptor._unmanagedDescriptor);
        }
    }

    public ShaderModuleHandle LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return LoadShaderModuleFromFileHandler.LoadShaderModuleFromFile(this, path, label);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.DeviceRelease(this);
        }
    }

    public static ref nuint AsPointer(ref DeviceHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static DeviceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(DeviceHandle handle)
    {
        return handle == Null;
    }

    public static DeviceHandle UnsafeFromPointer(nuint pointer)
    {
        return new DeviceHandle(pointer);
    }

    public Device? ToSafeHandle(bool incrementReferenceCount)
    {
        return Device.FromHandle(this, incrementReferenceCount);
    }

    public static void Reference(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceReference(handle);
    }

    public static void Release(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceRelease(handle);
    }
}