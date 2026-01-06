using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;


namespace WebGpuSharp;


/// <inheritdoc cref="DeviceHandle" />
public sealed class Device :
    WebGPUManagedHandleBase<DeviceHandle>,
    IFromHandleWithInstance<Device, DeviceHandle>
{

    private readonly Instance _instance;

    private Device(DeviceHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    private Queue? _queueCache;

    /// <inheritdoc cref="DeviceHandle.CreateBindGroup(in BindGroupDescriptor)" />
    public BindGroup CreateBindGroup(in BindGroupDescriptor descriptor) =>
        Handle.CreateBindGroup(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateBindGroupLayout(in BindGroupLayoutDescriptor)" />
    public BindGroupLayout CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor) =>
        Handle.CreateBindGroupLayout(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateBuffer(ref BufferDescriptor)" />
    public Buffer CreateBuffer(ref BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateBuffer(BufferDescriptor)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer CreateBuffer(BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateCommandEncoder" />
    public CommandEncoder CreateCommandEncoder() =>
        Handle.CreateCommandEncoder(new CommandEncoderDescriptor()).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateCommandEncoder(in CommandEncoderDescriptor)" />
    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        Handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateComputePipeline(in ComputePipelineDescriptor)" />
    public ComputePipeline CreateComputePipelineSync(in ComputePipelineDescriptor descriptor) =>
        Handle.CreateComputePipeline(descriptor).ToSafeHandle()!;

    /// <returns></returns>
    /// <param name="callback">The callback called when the ComputePipeline is ready</param>
    /// <inheritdoc cref="DeviceHandle.CreateComputePipelineAsync(ComputePipelineDescriptorFFI*, CreateComputePipelineAsyncCallbackInfoFFI)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CreateComputePipeline(in ComputePipelineDescriptor descriptor, Action<CreatePipelineAsyncStatus, ComputePipeline?, ReadOnlySpan<byte>> callback)
    {
        var future = CreateComputePipelineAsync(
            descriptor: descriptor,
            mode: CallbackMode.WaitAnyOnly,
            callback: callback,
            tcs: null
        );

        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    [SkipLocalsInit]
    private unsafe Future CreateComputePipelineAsync(
        in ComputePipelineDescriptor descriptor,
        CallbackMode mode,
        Action<CreatePipelineAsyncStatus, ComputePipeline?, ReadOnlySpan<byte>>? callback,
        TaskCompletionSource<ComputePipeline>? tcs)
    {
        Debug.Assert(callback != null || tcs != null, "Either callback or tsc must be provided.");
        Debug.Assert(!(callback != null && tcs != null), "Only one of callback or tsc should be provided.");

        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * 2 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var entryPointUtf8Span = ToUtf8Span(descriptor.Compute.EntryPoint, allocator, addNullTerminator: false);
        var tsc = new TaskCompletionSource<ComputePipeline>();

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (byte* entryPointPtr = entryPointUtf8Span)
        {
            ToFFI(
                descriptor.Compute.Constants, allocator,
                out ConstantEntryFFI* constantEntryPtr,
                out nuint constantEntryCount
            );

            void* userdata1;
            delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, StringViewFFI, void*, void*, void> callbackFunction;
            if (callback != null)
            {
                userdata1 = AllocUserData(callback);
                callbackFunction = &CreateComputePipelineAsyncCallbackFunctions.DelegateCallback;
            }
            else
            {
                userdata1 = AllocUserData(tcs!);
                callbackFunction = &CreateComputePipelineAsyncCallbackFunctions.TaskCallback;
            }


            ComputePipelineDescriptorFFI descriptorFFI = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length),
                Layout = WebGPUMarshal.GetHandle(descriptor.Layout),
                Compute = new()
                {
                    Module = WebGPUMarshal.GetHandle(descriptor.Compute.Module),
                    EntryPoint = StringViewFFI.CreateExplicitlySized(entryPointPtr, entryPointUtf8Span.Length),
                    Constants = constantEntryPtr,
                    ConstantCount = constantEntryCount
                }
            };

            return WebGPU_FFI.DeviceCreateComputePipelineAsync(
                  device: Handle,
                  descriptor: &descriptorFFI,
                  callbackInfo: new()
                  {
                      Mode = mode,
                      Callback = callbackFunction,
                      Userdata1 = userdata1,
                      Userdata2 = null
                  }
              );
        }
    }

    /// <inheritdoc cref="DeviceHandle.CreateComputePipelineAsync(in ComputePipelineDescriptor)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<ComputePipeline> CreateComputePipelineAsync(in ComputePipelineDescriptor descriptor)
    {
        var tsc = new TaskCompletionSource<ComputePipeline>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = CreateComputePipelineAsync(
            descriptor: descriptor,
            mode: CallbackMode.WaitAnyOnly,
            callback: null,
            tcs: tsc
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tsc.Task;
    }

    /// <inheritdoc cref="DeviceHandle.CreatePipelineLayout(in PipelineLayoutDescriptor)" />
    public PipelineLayout CreatePipelineLayout(in PipelineLayoutDescriptor descriptor) =>
        Handle.CreatePipelineLayout(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateQuerySet(in QuerySetDescriptor)" />
    public QuerySet CreateQuerySet(in QuerySetDescriptor descriptor) =>
        Handle.CreateQuerySet(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor)" />
    public RenderBundleEncoder CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor) =>
        Handle.CreateRenderBundleEncoder(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateRenderPipeline(in RenderPipelineDescriptor)" />
    public RenderPipeline CreateRenderPipelineSync(in RenderPipelineDescriptor descriptor) =>
        Handle.CreateRenderPipeline(descriptor).ToSafeHandle()!;

    [SkipLocalsInit]
    private unsafe Future CreateRenderPipelineAsync(
        in RenderPipelineDescriptor descriptor,
        CallbackMode mode,
        Action<CreatePipelineAsyncStatus, RenderPipeline?, ReadOnlySpan<byte>>? callback,
        TaskCompletionSource<RenderPipeline>? tcs)
    {
        Debug.Assert(callback != null || tcs != null, "Either callback or tsc must be provided.");
        Debug.Assert(!(callback != null && tcs != null), "Only one of callback or tsc should be provided.");

        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        void* userdata1;
        delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, StringViewFFI, void*, void*, void> callbackFunction;

        if (callback != null)
        {
            userdata1 = AllocUserData(callback);
            callbackFunction = &CreateRenderPipelineAsyncCallbackFunctions.DelegateCallback;
        }
        else
        {
            userdata1 = AllocUserData(tcs!);
            callbackFunction = &CreateRenderPipelineAsyncCallbackFunctions.TaskCallback;
        }

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (DepthStencilState* depthStencilPtr = &Nullable.GetValueRefOrDefaultRef(in descriptor.DepthStencil))
        {
            RenderPipelineDescriptorFFI descriptorFFI = default;
            descriptorFFI.Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            descriptorFFI.Layout = WebGPUMarshal.GetHandle(descriptor.Layout);
            ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
            descriptorFFI.Primitive = descriptor.Primitive;
            descriptorFFI.DepthStencil = descriptor.DepthStencil.HasValue ? depthStencilPtr : null;
            descriptorFFI.Multisample = descriptor.Multisample;
            ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

            return WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                  device: Handle,
                  descriptor: &descriptorFFI,
                  callbackInfo: new()
                  {
                      Mode = mode,
                      Callback = callbackFunction,
                      Userdata1 = userdata1,
                      Userdata2 = null
                  }
              );
        }
    }

    /// <returns></returns>
    /// <param name="callback">The callback called when the RenderPipeline is ready</param>
    /// <inheritdoc cref="DeviceHandle.CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CreateRenderPipeline(
        in RenderPipelineDescriptor descriptor,
        Action<CreatePipelineAsyncStatus, RenderPipeline?, ReadOnlySpan<byte>> callback)
    {
        var future = CreateRenderPipelineAsync(
            descriptor: descriptor,
            mode: CallbackMode.WaitAnyOnly,
            callback: callback,
            tcs: null
        );

        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <returns>A task that resolve into a RenderPipeline.</returns>
    /// <inheritdoc cref="DeviceHandle.CreateRenderPipelineAsync(RenderPipelineDescriptorFFI*, CreateRenderPipelineAsyncCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<RenderPipeline> CreateRenderPipelineAsync(in RenderPipelineDescriptor descriptor)
    {
        var tcs = new TaskCompletionSource<RenderPipeline>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = CreateRenderPipelineAsync(
            descriptor: descriptor,
            mode: CallbackMode.WaitAnyOnly,
            callback: null,
            tcs: tcs
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tcs.Task;
    }

    /// <inheritdoc cref="DeviceHandle.CreateSampler(ref SamplerDescriptor)" />
    public unsafe Sampler? CreateSampler() =>
     Handle.CreateSampler(null).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateSampler(ref SamplerDescriptor)" />
    public Sampler? CreateSampler(ref SamplerDescriptor descriptor) =>
     Handle.CreateSampler(ref descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateSampler(SamplerDescriptor)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor) =>
        Handle.CreateSampler(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(in ShaderModuleDescriptor)" />
    public ShaderModule CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        Handle.CreateShaderModule(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(ShaderModuleDescriptorFFI*)"/>
    public ShaderModule CreateShaderModuleWGSL(in ShaderModuleWGSLDescriptor descriptor) =>
        CreateShaderModule(new ShaderModuleDescriptor(in descriptor));

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(ShaderModuleDescriptorFFI*)" />
    public ShaderModule CreateShaderModuleWGSL(WGPURefText label, in ShaderModuleWGSLDescriptor descriptor) =>
    CreateShaderModule(new ShaderModuleDescriptor(in descriptor) { Label = label });

    /// <inheritdoc cref="DeviceHandle.CreateTexture(ref TextureDescriptor)" />
    public Texture CreateTexture(in TextureDescriptor textureDescriptor) =>
        Handle.CreateTexture(textureDescriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.GetAdapterInfo(out AdapterInfo)" />
    public unsafe Status GetAdapterInfo(out AdapterInfo adapterInfo) =>
        Handle.GetAdapterInfo(out adapterInfo);

    /// <inheritdoc cref="DeviceHandle.GetFeatures()" />
    public FeatureName[] GetFeatures() => Handle.GetFeatures();

    /// <inheritdoc cref="DeviceHandle.GetLimits()" />
    public Limits GetLimits() => Handle.GetLimits();
    /// <inheritdoc cref="DeviceHandle.GetLimits(ref Limits)" />
    public void GetLimits(ref Limits supportedLimits) => Handle.GetLimits(ref supportedLimits);

    /// <inheritdoc cref="DeviceHandle.GetQueue()" />
    public Queue GetQueue()
    {
        var queueHandel = Handle.GetQueue();
        if (_queueCache == null)
        {
            return _queueCache = queueHandel.ToSafeHandle(_instance)!;
        }
        else if (_queueCache.Equals(queueHandel))
        {
            queueHandel.Dispose();
            return _queueCache;
        }
        else
        {
            return _queueCache = queueHandel.ToSafeHandle(_instance)!;
        }
    }
    /// <inheritdoc cref="DeviceHandle.HasFeature(FeatureName)" />
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);


    /// <returns></returns>
    /// <inheritdoc cref="DeviceHandle.PopErrorScope(PopErrorScopeCallbackInfoFFI)"/>
    /// <param name="callback">The callback called when the error scope is popped</param>
    /// <param name="timeoutNS">The maximum time to wait for the error scope to be popped, in nanoseconds. Default is ulong.MaxValue (no timeout).</param>
    public unsafe (ErrorType errorType, string message) PopErrorScopeSync(ulong timeoutNS = ulong.MaxValue)
    {
        string resultMessage = string.Empty;
        ErrorType resultErrorType = ErrorType.NoError;
        Exception? exception = null;

        void Callback(
            PopErrorScopeStatus status,
            ErrorType errorType,
            ReadOnlySpan<byte> messageSpan)
        {
            switch (status)
            {
                case PopErrorScopeStatus.Success:
                    resultErrorType = errorType;
                    resultMessage = Encoding.UTF8.GetString(messageSpan);
                    break;
                default:
                    exception = new WebGPUException(Encoding.UTF8.GetString(messageSpan));
                    break;
            }
        }

        var future = WebGPU_FFI.DevicePopErrorScope(
           device: Handle,
           callbackInfo: new()
           {
               Mode = CallbackMode.WaitAnyOnly,
               Callback = &PopErrorScopeCallbackFunctions.DelegateCallback,
               Userdata1 = AllocUserData((Action<PopErrorScopeStatus, ErrorType, ReadOnlySpan<byte>>)Callback),
               Userdata2 = null
           }
        );

        _instance.WaitAny(future, timeoutNS);

        if (exception != null)
        {
            throw exception;
        }

        return (resultErrorType, resultMessage);
    }

    /// <returns></returns>
    /// <inheritdoc cref="DeviceHandle.PopErrorScope(PopErrorScopeCallbackInfoFFI)"/>
    /// <param name="callback">The callback called when the error scope is popped</param>
    public unsafe void PopErrorScope(Action<PopErrorScopeStatus, ErrorType, ReadOnlySpan<byte>> callback)
    {
        var future = WebGPU_FFI.DevicePopErrorScope(
           device: Handle,
           callbackInfo: new()
           {
               Mode = CallbackMode.WaitAnyOnly,
               Callback = &PopErrorScopeCallbackFunctions.DelegateCallback,
               Userdata1 = AllocUserData(callback),
               Userdata2 = null
           }
        );

        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <returns> A Task that resolves to a <see cref="ErrorType"/> and the error message</returns>
    /// <inheritdoc cref="DeviceHandle.PopErrorScope(PopErrorScopeCallbackInfoFFI)"/>
    public unsafe Task<(ErrorType errorType, string message)> PopErrorScopeAsync()
    {
        var tsc = new TaskCompletionSource<(ErrorType errorType, string message)>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = WebGPU_FFI.DevicePopErrorScope(
           device: Handle,
           callbackInfo: new()
           {
               Mode = CallbackMode.WaitAnyOnly,
               Callback = &PopErrorScopeCallbackFunctions.TaskCallback,
               Userdata1 = AllocUserData(tsc),
               Userdata2 = null
           }
        );

        _instance._eventHandler.EnqueueCpuFuture(future);
        return tsc.Task;
    }

    /// <inheritdoc cref="DeviceHandle.PushErrorScope(ErrorFilter)" />
    public void PushErrorScope(ErrorFilter filter) => Handle.PushErrorScope(filter);

    [Obsolete("This api will be removed in a future versions, as this method is not part of the official WebGPU specification")]
    /// <inheritdoc cref="DeviceHandle.LoadShaderModuleFromFile(string, WGPURefText)" />
    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return Handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(_instance);
    }

    static Device? IFromHandleWithInstance<Device, DeviceHandle>.FromHandle(DeviceHandle managedHandle, Instance instance)
    {
        if (DeviceHandle.IsNull(managedHandle))
        {
            return null;
        }
        return new(managedHandle, instance);
    }

    static Instance IFromHandleWithInstance<Device, DeviceHandle>.GetOwnerInstance(Device managedHandle)
    {
        return managedHandle._instance;
    }
}

file unsafe static class PopErrorScopeCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void DelegateCallback(
        PopErrorScopeStatus errorScopeStatus, ErrorType errorType, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var callback = (Action<PopErrorScopeStatus, ErrorType, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }

            callback(errorScopeStatus, errorType, message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void TaskCallback(
        PopErrorScopeStatus errorScopeStatus, ErrorType errorType, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var tsc = (TaskCompletionSource<(ErrorType errorType, string message)>?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }

            switch (errorScopeStatus)
            {
                case PopErrorScopeStatus.Success:
                    tsc.SetResult((errorType, Encoding.UTF8.GetString(message.AsSpan())));
                    break;
                default:
                    tsc.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }
}

file unsafe static class CreateRenderPipelineAsyncCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void DelegateCallback(
        CreatePipelineAsyncStatus status, RenderPipelineHandle pipeline, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var callback = (Action<CreatePipelineAsyncStatus, RenderPipeline?, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }

            callback(status, pipeline.ToSafeHandle(), message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void TaskCallback(
        CreatePipelineAsyncStatus status, RenderPipelineHandle pipeline, StringViewFFI message,
        void* userdata1, void* userdata2)
    {
        try
        {
            var tsc = (TaskCompletionSource<RenderPipeline>?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }

            switch (status)
            {
                case CreatePipelineAsyncStatus.Success:
                    tsc.SetResult(pipeline.ToSafeHandle()!);
                    break;
                case CreatePipelineAsyncStatus.InternalError:
                case CreatePipelineAsyncStatus.ValidationError:
                case CreatePipelineAsyncStatus.CallbackCancelled:
                    tsc.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }
}

file unsafe static class CreateComputePipelineAsyncCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void DelegateCallback(
        CreatePipelineAsyncStatus status, ComputePipelineHandle pipeline, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var callback = (Action<CreatePipelineAsyncStatus, ComputePipeline?, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }

            callback(status, pipeline.ToSafeHandle(), message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void TaskCallback(
        CreatePipelineAsyncStatus status, ComputePipelineHandle pipeline, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var tsc = (TaskCompletionSource<ComputePipeline>?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }
            switch (status)
            {
                case CreatePipelineAsyncStatus.Success:
                    tsc.SetResult(pipeline.ToSafeHandle()!);
                    break;
                case CreatePipelineAsyncStatus.InternalError:
                case CreatePipelineAsyncStatus.ValidationError:
                case CreatePipelineAsyncStatus.CallbackCancelled:
                    tsc.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }
}
