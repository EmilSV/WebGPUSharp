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
        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            BindGroupDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (BindGroupLayoutEntry* entriesPtr = descriptor.Entries)
        fixed (byte* labelPtr = labelUtf8Span)
        {
            return CreateBindGroupLayout(new BindGroupLayoutDescriptorFFI()
            {
                Label = labelPtr,
                Entries = entriesPtr,
                EntryCount = (nuint)descriptor.Entries.Length
            });
        }
    }

    public BufferHandle CreateBuffer(ref BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            descriptorPtr->Label = labelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, descriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BufferHandle CreateBuffer(BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* LabelPtr = labelUtf8Span)
        {
            descriptor._unmanagedDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, &descriptor._unmanagedDescriptor);
        }
    }

    public CommandEncoderHandle CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* LabelPtr = labelUtf8Span)
        {
            CommandEncoderDescriptorFFI commandEncoderDescriptor = new()
            {
                Label = LabelPtr
            };
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
        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: true);

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
                Label = LabelPtr,
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = EntryPointPtr,
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: true);

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
                Label = labelPtr,
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = entryPointPtr,
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: true);

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
                Label = labelPtr,
                Layout = GetBorrowHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = GetBorrowHandle(descriptor.Compute.Module),
                    EntryPoint = entryPointPtr,
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

            return DeviceCreateComputePipelineAsyncHandler.DeviceCreateComputePipelineAsync(this, descriptorFFI);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            var (ptr, length) = GetBorrowHandlesAsPtrAndLength<BindGroupLayoutHandle, BindGroupLayout>(
                descriptor.BindGroupLayouts,
                allocator
            );
            PipelineLayoutDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            descriptorFFI.BindGroupLayouts = ptr;
            descriptorFFI.BindGroupLayoutCount = length;

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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            QuerySetDescriptorFFI descriptorFFI = new()
            {
                Label = labelPtr,
                Type = descriptor.Type,
                Count = descriptor.Count
            };
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (TextureFormat* colorFormatsPtr = descriptor.ColorFormats)
        {
            RenderBundleEncoderDescriptorFFI descriptorFFI = new()
            {
                Label = labelPtr,
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = labelPtr;
            descriptorFFI.Layout = GetBorrowHandle(descriptor.Layout);
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

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            descriptorFFI.Label = labelPtr;
            return WebGPU_FFI.DeviceCreateSampler(this, &descriptorFFI);
        }
    }

    public SamplerHandle CreateSampler(SamplerDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
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

    public TextureHandle CreateTexture(ref TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(textureDescriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
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

        var labelUtf8Span = ToUtf8Span(textureDescriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        {
            textureDescriptor._unmanagedDescriptor.Label = labelPtr;
            textureDescriptor._unmanagedDescriptor.ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptor._unmanagedDescriptor.ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, &textureDescriptor._unmanagedDescriptor);
        }
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

    public void PopErrorScope(DevicePopErrorScopeDelegate callback)
    {
        DevicePopErrorScopeHandler.DevicePopErrorScope(this, callback);
    }


    public Task<(ErrorType errorType, string message)> PopErrorScopeAsync()
    {
        return DevicePopErrorScopeHandler.DevicePopErrorScope(this);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.DeviceSetLabel2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    [Obsolete("AddUncapturedErrorCallback is deprecated. Pass the callback in the device descriptor instead.")]
    public void AddUncapturedErrorCallback(UncapturedErrorDelegate callback)
    {
        UncapturedErrorCallbackHandler.AddUncapturedErrorCallback(this, callback);
    }

    [Obsolete("RemoveUncapturedErrorCallback  is deprecated. Pass the callback in the device descriptor instead.")]
    public void RemoveUncapturedErrorCallback(UncapturedErrorDelegate callback)
    {
        UncapturedErrorCallbackHandler.RemoveUncapturedErrorCallback(this, callback);
    }

    private ShaderModuleHandle CreateShaderModuleWgsl(in ShaderModuleDescriptor descriptor, WGPURefText code)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);
        var codeUtf8Span = ToUtf8Span(code, allocator, addNullTerminator: true);

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
                Code = codePtr
            };


            ShaderModuleDescriptorFFI shaderModuleDescriptor = new()
            {
                NextInChain = &shaderSourceWGSL.Chain,
                Label = labelPtr
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