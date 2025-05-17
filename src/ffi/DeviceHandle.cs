using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct DeviceHandle : IDisposable, IWebGpuHandle<DeviceHandle, Device>
{
    /// <inheritdoc cref="CreateBindGroup(BindGroupDescriptorFFI*)"/>
    public BindGroupHandle CreateBindGroup(in BindGroupDescriptorFFI descriptor)
    {
        fixed (BindGroupDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroup(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateBindGroup(BindGroupDescriptorFFI*)"/>
    public BindGroupHandle CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        ToFFI(
            input: descriptor.Entries,
            allocator: allocator,
            dest: out BindGroupEntryFFI* entriesPtr,
            outCount: out nuint entriesCount
        );
        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            BindGroupDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
            descriptorFFI.EntryCount = entriesCount;
            descriptorFFI.Entries = entriesPtr;
            return WebGPU_FFI.DeviceCreateBindGroup(this, &descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreateBindGroupLayout(BindGroupLayoutDescriptorFFI*)"/> />
    public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptorFFI descriptor)
    {
        fixed (BindGroupLayoutDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroupLayout(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateBindGroupLayout(BindGroupLayoutDescriptorFFI*)"/>
    public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (BindGroupLayoutEntry* entriesPtr = descriptor.Entries)
        fixed (byte* labelPtr = labelUtf8Span)
        {
            return CreateBindGroupLayout(new BindGroupLayoutDescriptorFFI()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                Entries = entriesPtr,
                EntryCount = (nuint)descriptor.Entries.Length
            });
        }
    }

    /// <inheritdoc cref="CreateBuffer(BufferDescriptorFFI*)"/>
    public BufferHandle CreateBuffer(ref BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            descriptorPtr->Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            return WebGPU_FFI.DeviceCreateBuffer(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateBuffer(BufferDescriptorFFI*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BufferHandle CreateBuffer(BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* LabelPtr = labelUtf8Span)
        {
            descriptor._unmanagedDescriptor.Label = StringViewFFI.CreateExplicitlySized(LabelPtr, labelUtf8Span.Length);
            return WebGPU_FFI.DeviceCreateBuffer(this, &descriptor._unmanagedDescriptor);
        }
    }

    /// <inheritdoc cref="CreateCommandEncoder(CommandEncoderDescriptorFFI*)"/>
    public CommandEncoderHandle CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* LabelPtr = labelUtf8Span)
        {
            CommandEncoderDescriptorFFI commandEncoderDescriptor = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(LabelPtr, labelUtf8Span.Length)
            };
            return WebGPU_FFI.DeviceCreateCommandEncoder(this, &commandEncoderDescriptor);
        }
    }

    /// <inheritdoc cref="CreateComputePipeline(ComputePipelineDescriptorFFI*)"/>
    public ComputePipelineHandle CreateComputePipeline(in ComputePipelineDescriptorFFI descriptor)
    {
        fixed (ComputePipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateComputePipeline(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateComputePipeline(ComputePipelineDescriptorFFI*)"/>
    public ComputePipelineHandle CreateComputePipeline(in ComputePipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: false);

        fixed (byte* LabelPtr = labelUtf8Span)
        fixed (byte* EntryPointPtr = entryPointUtf8Span)
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(LabelPtr, labelUtf8Span.Length),
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = StringViewFFI.CreateExplicitlySized(EntryPointPtr, entryPointUtf8Span.Length),
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

            return WebGPU_FFI.DeviceCreateComputePipeline(this, &descriptorFFI);
        }
    }
    /// <returns/>
    /// <inheritdoc cref="CreateComputePipelineAsync(ComputePipelineDescriptorFFI*, CreateComputePipelineAsyncCallbackInfoFFI)"/>
    public void CreateComputePipelineAsync(
        in ComputePipelineDescriptorFFI descriptor,
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle> callback)
    {
        DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptor, callback);
    }

    /// <returns/>
    /// <inheritdoc cref="CreateComputePipelineAsync(ComputePipelineDescriptorFFI*, CreateComputePipelineAsyncCallbackInfoFFI)"/>
    public void CreateComputePipelineAsync(
        in ComputePipelineDescriptor descriptor,
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle> callback)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (byte* entryPointPtr = entryPointUtf8Span)
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = StringViewFFI.CreateExplicitlySized(entryPointPtr, entryPointUtf8Span.Length),
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

            DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptorFFI, callback);
        }

    }

    /// <returns>The <see cref="ComputePipelineHandle"/></returns>
    /// <inheritdoc cref="CreateComputePipelineAsync(ComputePipelineDescriptorFFI*, CreateComputePipelineAsyncCallbackInfoFFI)"/>
    public Task<ComputePipelineHandle> CreateComputePipelineAsync(
        in ComputePipelineDescriptorFFI descriptor)
    {
        return DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptor);
    }

    /// <returns>The <see cref="ComputePipelineHandle"/></returns>
    /// <inheritdoc cref="CreateComputePipelineAsync(ComputePipelineDescriptorFFI*, CreateComputePipelineAsyncCallbackInfoFFI)"/>
    public Task<ComputePipelineHandle> CreateComputePipelineAsync(
        in ComputePipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (byte* entryPointPtr = entryPointUtf8Span)
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            ComputePipelineDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = StringViewFFI.CreateExplicitlySized(entryPointPtr, entryPointUtf8Span.Length),
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

            return DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreatePipelineLayout(PipelineLayoutDescriptorFFI*)"/>
    public PipelineLayoutHandle CreatePipelineLayout(in PipelineLayoutDescriptorFFI descriptor)
    {
        fixed (PipelineLayoutDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreatePipelineLayout(PipelineLayoutDescriptorFFI*)"/>
    public PipelineLayoutHandle CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            var (ptr, length) = GetBorrowHandlesAsPtrAndLength<BindGroupLayoutHandle, BindGroupLayout>(
                descriptor.BindGroupLayouts,
                allocator
            );
            PipelineLayoutDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.BindGroupLayouts = ptr;
            descriptorFFI.BindGroupLayoutCount = length;

            return CreatePipelineLayout(descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreateQuerySet(QuerySetDescriptorFFI*)"/>
    public QuerySetHandle CreateQuerySet(in QuerySetDescriptorFFI descriptor)
    {
        fixed (QuerySetDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateQuerySet(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateQuerySet(QuerySetDescriptorFFI*)"/>
    public QuerySetHandle CreateQuerySet(in QuerySetDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            QuerySetDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                Type = descriptor.Type,
                Count = descriptor.Count
            };
            return WebGPU_FFI.DeviceCreateQuerySet(this, &descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreateRenderBundleEncoder(RenderBundleEncoderDescriptorFFI*)"/>
    public RenderBundleEncoderHandle CreateRenderBundleEncoder(in RenderBundleEncoderDescriptorFFI descriptor)
    {
        fixed (RenderBundleEncoderDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateRenderBundleEncoder(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateRenderBundleEncoder(RenderBundleEncoderDescriptorFFI*)"/>
    public RenderBundleEncoderHandle CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (TextureFormat* colorFormatsPtr = descriptor.ColorFormats)
        {
            RenderBundleEncoderDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                ColorFormatCount = (nuint)descriptor.ColorFormats.Length,
                ColorFormats = colorFormatsPtr,
                DepthStencilFormat = descriptor.DepthStencilFormat,
                SampleCount = descriptor.SampleCount,
                DepthReadOnly = descriptor.DepthReadOnly,
                StencilReadOnly = descriptor.StencilReadOnly
            };

            return CreateRenderBundleEncoder(descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreateRenderPipeline(RenderPipelineDescriptorFFI*)"/>
    public RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptorFFI descriptor)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateRenderPipeline(RenderPipelineDescriptorFFI*)"/>
    public RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
            ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
            descriptorFFI.Primitive = descriptor.Primitive;
            descriptorFFI.DepthStencil = depthStencilPtr;
            descriptorFFI.Multisample = descriptor.Multisample;
            ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

            return CreateRenderPipeline(descriptorFFI);
        }
    }

    /// <returns></returns>
    /// <inheritdoc cref="CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    public void CreateRenderPipelineAsync(
        in RenderPipelineDescriptorFFI descriptor,
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle> callback)
    {
        DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptor, callback);
    }

    /// <returns></returns>
    /// <inheritdoc cref="CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    public void CreateRenderPipelineAsync(
        in RenderPipelineDescriptor descriptor,
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle> callback)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
            ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
            descriptorFFI.Primitive = descriptor.Primitive;
            descriptorFFI.DepthStencil = depthStencilPtr;
            descriptorFFI.Multisample = descriptor.Multisample;
            ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

            DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptorFFI, callback);
        }
    }


    /// <returns>The <see cref="RenderPipelineHandle"/></returns>
    /// <inheritdoc cref="CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    public Task<RenderPipelineHandle> CreateRenderPipelineAsync(in RenderPipelineDescriptorFFI descriptor)
    {
        return DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptor);
    }

    /// <returns>The <see cref="RenderPipelineHandle"/></returns>
    /// <inheritdoc cref="CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    public Task<RenderPipelineHandle> CreateRenderPipelineAsync(in RenderPipelineDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
            ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
            descriptorFFI.Primitive = descriptor.Primitive;
            descriptorFFI.DepthStencil = depthStencilPtr;
            descriptorFFI.Multisample = descriptor.Multisample;
            ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

            return DeviceCreateRenderPipelineAsyncHandler.DeviceCreateRenderPipelineAsync(this, descriptorFFI);
        }
    }

    /// <inheritdoc cref="CreateSampler(SamplerDescriptorFFI*)"/>
    public SamplerHandle CreateSampler(ref SamplerDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        SamplerDescriptorFFI descriptorFFI = descriptor._unsafeDescriptor;

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            return WebGPU_FFI.DeviceCreateSampler(this, &descriptorFFI);
        }
    }

    //// <inheritdoc cref="CreateSampler(SamplerDescriptorFFI*)"/>
    public SamplerHandle CreateSampler(SamplerDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            descriptor._unsafeDescriptor.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            return WebGPU_FFI.DeviceCreateSampler(this, &descriptor._unsafeDescriptor);
        }
    }

    /// <inheritdoc cref="CreateShaderModule(ShaderModuleDescriptorFFI*)"/>
    public ShaderModuleHandle CreateShaderModule(in ShaderModuleDescriptorFFI descriptor)
    {
        fixed (ShaderModuleDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceCreateShaderModule(this, descriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateShaderModule(ShaderModuleDescriptorFFI*)"/>
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

    /// <inheritdoc cref="CreateTexture(TextureDescriptorFFI*)"/>
    public TextureHandle CreateTexture(ref TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(textureDescriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        fixed (TextureDescriptorFFI* textureDescriptorPtr = &textureDescriptor._unmanagedDescriptor)
        {
            textureDescriptorPtr->Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            textureDescriptorPtr->ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptorPtr->ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, textureDescriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateTexture(TextureDescriptorFFI*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TextureHandle CreateTexture(TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(textureDescriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        {
            textureDescriptor._unmanagedDescriptor.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            textureDescriptor._unmanagedDescriptor.ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptor._unmanagedDescriptor.ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, &textureDescriptor._unmanagedDescriptor);
        }
    }
    /// <inheritdoc cref="GetAdapterInfo(AdapterInfoFFI*)"/>
    [SkipLocalsInit]
    public unsafe Status GetAdapterInfo(out AdapterInfo adapterInfo)
    {
        bool gotAdapterInfo = false;
        var adapterInfoFFI = new AdapterInfoFFI();
        try
        {
            var status = GetAdapterInfo(&adapterInfoFFI);
            gotAdapterInfo = true;
            adapterInfo = new AdapterInfo(adapterInfoFFI);
            return status;
        }
        finally
        {
            if (gotAdapterInfo)
            {
                WebGPU_FFI.AdapterInfoFreeMembers(adapterInfoFFI);
            }
        }
    }
    /// <inheritdoc cref="GetFeatures(SupportedFeaturesFFI*)"/>
    [SkipLocalsInit]
    public FeatureName[] GetFeatures()
    {
        bool gotFeatures = false;
        SupportedFeaturesFFI supportedFeaturesFFI;
        Unsafe.SkipInit(out supportedFeaturesFFI);
        try
        {
            WebGPU_FFI.DeviceGetFeatures(this, &supportedFeaturesFFI);
            gotFeatures = true;
            FeatureName[] features = new FeatureName[supportedFeaturesFFI.FeatureCount];
            features.CopyTo(new Span<FeatureName>(supportedFeaturesFFI.Features, (int)supportedFeaturesFFI.FeatureCount));
            return features;
        }
        finally
        {
            if (gotFeatures)
            {
                WebGPU_FFI.SupportedFeaturesFreeMembers(supportedFeaturesFFI);
            }
        }
    }
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    [SkipLocalsInit]
    public Limits GetLimits()
    {
        Limits supportedLimits;
        WebGPU_FFI.DeviceGetLimits(this, &supportedLimits);
        return supportedLimits;
    }
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    public void GetLimits(ref Limits limits)
    {
        fixed (Limits* limitsPtr = &limits)
        {
            WebGPU_FFI.DeviceGetLimits(this, limitsPtr);
        }
    }

    /// <inheritdoc cref="PopErrorScope(PopErrorScopeCallbackInfoFFI)"/>
    public void PopErrorScope(DevicePopErrorScopeDelegate callbackInfo)
    {
        DevicePopErrorScopeHandler.DevicePopErrorScope(this, callbackInfo);
    }

    /// <returns>The <see cref="ErrorType"/> and the error message</returns>
    /// /// <inheritdoc cref="PopErrorScope(PopErrorScopeCallbackInfoFFI)"/>
    public Task<(ErrorType errorType, string message)> PopErrorScopeAsync()
    {
        return DevicePopErrorScopeHandler.DevicePopErrorScope(this);
    }
    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.DeviceSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }
    /// <inheritdoc cref="CreateShaderModule(ShaderModuleDescriptorFFI*)"/>
    private ShaderModuleHandle CreateShaderModuleWgsl(in ShaderModuleDescriptor descriptor, WGPURefText code)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var codeUtf8Span = ToUtf8Span(code, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (byte* codePtr = codeUtf8Span)
        {

            ShaderSourceWGSLFFI shaderSourceWGSL = new()
            {
                Chain = new()
                {
                    Next = null,
                    SType = SType.ShaderSourceWGSL
                },
                Code = StringViewFFI.CreateExplicitlySized(codePtr, codeUtf8Span.Length)
            };


            ShaderModuleDescriptorFFI shaderModuleDescriptor = new()
            {
                NextInChain = &shaderSourceWGSL.Chain,
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            };

            return WebGPU_FFI.DeviceCreateShaderModule(this, &shaderModuleDescriptor);
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

    public Device? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Device, DeviceHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Device, DeviceHandle>(this);
        }
    }

    public static void Reference(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceAddRef(handle);
    }

    public static void Release(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceRelease(handle);
    }
}