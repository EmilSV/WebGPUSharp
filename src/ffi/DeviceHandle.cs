using System.Diagnostics;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
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
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* EntryPointPtr = ToRefCstrUtf8(descriptor.Compute.EntryPoint, allocator))
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new(
                label: LabelPtr,
                layout: (PipelineLayoutHandle)descriptor.Layout,
                compute: new(
                    module: (ShaderModuleHandle)descriptor.Compute.Module,
                    entryPoint: EntryPointPtr,
                    constants: constantEntryPtr,
                    constantCount: constantEntryCount
                )
            );

            return WebGPU_FFI.DeviceCreateComputePipeline(this, &descriptorFFI);
        }
    }

    public void CreateComputePipelineAsync(
        in ComputePipelineDescriptorFFI descriptor,
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle> callback)
    {
        DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptor, callback);
    }

    public void CreateComputePipelineAsync(
        in ComputePipelineDescriptor descriptor,
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle> callback)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* EntryPointPtr = ToRefCstrUtf8(descriptor.Compute.EntryPoint, allocator))
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new(
                label: LabelPtr,
                layout: (PipelineLayoutHandle)descriptor.Layout,
                compute: new(
                    module: (ShaderModuleHandle)descriptor.Compute.Module,
                    entryPoint: EntryPointPtr,
                    constants: constantEntryPtr,
                    constantCount: constantEntryCount
                )
            );

            DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptorFFI, callback);
        }

    }


    public Task<ComputePipelineHandle> CreateComputePipelineAsync(
        in ComputePipelineDescriptorFFI descriptor)
    {
        return DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptor);
    }

    public Task<ComputePipelineHandle> CreateComputePipelineAsync(
        in ComputePipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* EntryPointPtr = ToRefCstrUtf8(descriptor.Compute.EntryPoint, allocator))
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new(
                label: LabelPtr,
                layout: (PipelineLayoutHandle)descriptor.Layout,
                compute: new(
                    module: (ShaderModuleHandle)descriptor.Compute.Module,
                    entryPoint: EntryPointPtr,
                    constants: constantEntryPtr,
                    constantCount: constantEntryCount
                )
            );

            return DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptorFFI);
        }
    }

    public BufferHandle CreateErrorBuffer(DeviceHandle device, in BufferDescriptorFFI descriptor)
    {
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateErrorBuffer(device, descriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BufferHandle CreateErrorBuffer(DeviceHandle device, BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unmanagedDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateErrorBuffer(this, &descriptor._unmanagedDescriptor);
        }
    }

    public BufferHandle CreateErrorBuffer(DeviceHandle device, ref BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            descriptorPtr->Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateErrorBuffer(this, descriptorPtr);
        }
    }

    public ExternalTextureHandle CreateErrorExternalTexture()
    {
        return WebGPU_FFI.DeviceCreateErrorExternalTexture(this);
    }

    public ShaderModuleHandle CreateErrorShaderModule(in ShaderModuleDescriptor descriptor, WGPURefText errorMessage)
    {
        if (descriptor.IsWgslNext())
        {
            return CreateErrorShaderModuleWgsl(descriptor, descriptor.GetNextWgsl().Code, errorMessage);
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

    public TextureHandle CreateErrorTexture(DeviceHandle device, in TextureDescriptorFFI descriptor)
    {
        fixed (TextureDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateErrorTexture(device, descriptorPtr);
        }
    }

    public TextureHandle CreateErrorTexture(ref TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        fixed (TextureDescriptorFFI* textureDescriptorPtr = &textureDescriptor._unmanagedDescriptor)
        {
            textureDescriptorPtr->Label = labelPtr;
            textureDescriptorPtr->ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptorPtr->ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateErrorTexture(this, textureDescriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TextureHandle CreateErrorTexture(TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        {
            textureDescriptor._unmanagedDescriptor.Label = labelPtr;
            textureDescriptor._unmanagedDescriptor.ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptor._unmanagedDescriptor.ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateErrorTexture(this, &textureDescriptor._unmanagedDescriptor);
        }
    }

    public ExternalTextureHandle CreateExternalTexture(in ExternalTextureDescriptorFFI descriptor)
    {
        fixed (ExternalTextureDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateExternalTexture(this, descriptorPtr);
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

    public QuerySetHandle CreateQuerySet(in QuerySetDescriptorFFI descriptor)
    {
        fixed (QuerySetDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateQuerySet(this, descriptorPtr);
        }
    }

    public QuerySetHandle CreateQuerySet(in QuerySetDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (PipelineStatisticName* pipelineStatisticsPtr = descriptor.PipelineStatistics)
        {
            QuerySetDescriptorFFI descriptorFFI = new(
                label: labelPtr,
                type: descriptor.Type,
                count: descriptor.Count,
                pipelineStatistics: pipelineStatisticsPtr,
                pipelineStatisticCount: (nuint)descriptor.PipelineStatistics.Length
            );
            return WebGPU_FFI.DeviceCreateQuerySet(this, &descriptorFFI);
        }
    }

    public RenderBundleEncoderHandle CreateRenderBundleEncoder(in RenderBundleEncoderDescriptorFFI descriptor)
    {
        fixed (RenderBundleEncoderDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateRenderBundleEncoder(this, descriptorPtr);
        }
    }


    public RenderBundleEncoderHandle CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (TextureFormat* colorFormatsPtr = descriptor.ColorFormats)
        {
            RenderBundleEncoderDescriptorFFI descriptorFFI = new(
                label: labelPtr,
                colorFormatCount: (nuint)descriptor.ColorFormats.Length,
                colorFormats: colorFormatsPtr,
                depthStencilFormat: descriptor.DepthStencilFormat,
                sampleCount: descriptor.SampleCount,
                depthReadOnly: descriptor.DepthReadOnly,
                stencilReadOnly: descriptor.StencilReadOnly
            );

            return CreateRenderBundleEncoder(descriptorFFI);
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

    public void CreateRenderPipelineAsync(
        in RenderPipelineDescriptorFFI descriptor,
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle> callback)
    {
        DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptor, callback);
    }

    public void CreateRenderPipelineAsync(
        in RenderPipelineDescriptor descriptor,
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle> callback)
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

            DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptorFFI, callback);
        }
    }


    public Task<RenderPipelineHandle> CreateRenderPipelineAsync(in RenderPipelineDescriptorFFI descriptor)
    {
        return DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptor);
    }

    public Task<RenderPipelineHandle> CreateRenderPipelineAsync(in RenderPipelineDescriptor descriptor)
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

            return DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptorFFI);
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

    public ShaderModuleHandle CreateShaderModule(in ShaderModuleDescriptorFFI descriptor)
    {
        fixed (ShaderModuleDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateShaderModule(this, descriptorPtr);
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

    public void Destroy()
    {
        WebGPU_FFI.DeviceDestroy(this);
    }

    public nuint GetEnumerateFeaturesCount()
    {
        return WebGPU_FFI.DeviceEnumerateFeatures(this, null);
    }


    public nuint EnumerateFeatures(Span<FeatureName> features)
    {
        Debug.Assert(features.Length >= (int)GetEnumerateFeaturesCount());
        fixed (FeatureName* featuresPtr = features)
        {
            return WebGPU_FFI.DeviceEnumerateFeatures(this, featuresPtr);
        }
    }

    public FeatureName[] GetFeatures()
    {
        nuint count = WebGPU_FFI.DeviceEnumerateFeatures(this, null);
        FeatureName[] features = new FeatureName[count];
        fixed (FeatureName* featuresPtr = features)
        {
            WebGPU_FFI.DeviceEnumerateFeatures(this, featuresPtr);
        }
        return features;
    }

    public void ForceLoss(DeviceLostReason type, WGPURefText message)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* messagePtr = ToRefCstrUtf8(message, allocator))
        {
            WebGPU_FFI.DeviceForceLoss(this, type, messagePtr);
        }
    }

    public AdapterHandle GetAdapter()
    {
        return WebGPU_FFI.DeviceGetAdapter(this);
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

    public QueueHandle GetQueue()
    {
        return WebGPU_FFI.DeviceGetQueue(this);
    }

    public TextureUsage GetSupportedSurfaceUsage(SurfaceHandle surface)
    {
        return WebGPU_FFI.DeviceGetSupportedSurfaceUsage(this, surface);
    }

    public TextureUsage GetSupportedSurfaceUsage(Surface surface)
    {
        return WebGPU_FFI.DeviceGetSupportedSurfaceUsage(this, (SurfaceHandle)surface);
    }

    public WGPUBool HasFeature(FeatureName feature)
    {
        return WebGPU_FFI.DeviceHasFeature(this, feature);
    }


    public void PopErrorScope(DevicePopErrorScopeDelegate callback)
    {
        DevicePopErrorScopeHandler.DevicePopErrorScope(this, callback);
    }


    public Task<(ErrorType errorType, string message)> PopErrorScopeAsync()
    {
        return DevicePopErrorScopeHandler.DevicePopErrorScope(this);
    }

    public void PushErrorScope(ErrorFilter errorFilter)
    {
        WebGPU_FFI.DevicePushErrorScope(this, errorFilter);
    }


    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.DeviceSetLabel(this, labelPtr);
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

    private ShaderModuleHandle CreateErrorShaderModuleWgsl(
        in ShaderModuleDescriptor descriptor, WGPURefText code, WGPURefText errorMessage)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* codePtr = ToRefCstrUtf8(code, allocator))
        fixed (byte* errorMessagePtr = ToRefCstrUtf8(errorMessage, allocator))
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

            return WebGPU_FFI.DeviceCreateErrorShaderModule(this, &shaderModuleDescriptor, errorMessagePtr);
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

    public Device? ToSafeHandle(bool isOwnedHandle)
    {
        return Device.FromHandle(this, isOwnedHandle);
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