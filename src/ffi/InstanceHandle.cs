#pragma warning disable CS0162 // Unreachable code detected  

using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;
namespace WebGpuSharp.FFI;


public readonly unsafe partial struct InstanceHandle :
    IDisposable, IWebGpuHandle<InstanceHandle, Instance>
{
    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public Task<AdapterHandle> RequestAdapterAsync(in RequestAdapterOptionsFFI options, CallbackMode mode, out Future future)
    {
        unsafe
        {
            TaskCompletionSource<AdapterHandle> taskCompletionSource;
            GCHandle handle = default;
            try
            {
                taskCompletionSource = new TaskCompletionSource<AdapterHandle>();
                fixed (RequestAdapterOptionsFFI* optionsPtr = &options)
                {
                    future = WebGPU_FFI.InstanceRequestAdapter(
                       instance: this,
                       options: optionsPtr,
                       callbackInfo: new()
                       {
                           Mode = mode,
                           Callback = &OnAdapterRequestEnded,
                           Userdata1 = AllocUserData(taskCompletionSource),
                           Userdata2 = null
                       }
                    );
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
                future = default;
                return Task.FromResult(AdapterHandle.Null);
            }

            return taskCompletionSource.Task;
        }
    }
    
    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public Task<AdapterHandle> RequestAdapterAsync(in RequestAdapterOptionsFFI options)
    {
        return RequestAdapterAsync(options, CallbackMode.AllowSpontaneous, out _);
    }

    /// <returns> A task that will complete when the adapter is ready.</returns>
    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public Task<AdapterHandle> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        ToFFI(options, out RequestAdapterOptionsFFI optionFFI);
        return RequestAdapterAsync(optionFFI);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.InstanceRelease(this);
        }
    }

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(in SurfaceDescriptorFFI descriptor)
    {
        fixed (SurfaceDescriptorFFI* surfaceDescriptorPtr = &descriptor)
        {
            return WebGPU_FFI.InstanceCreateSurface(this, surfaceDescriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(SurfaceDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        ref var next = ref descriptor._next;

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (ChainedStruct* nextPtr = &next)
        {
            SurfaceDescriptorFFI surfaceDescriptor = new()
            {
                NextInChain = nextPtr,
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            };
            return WebGPU_FFI.InstanceCreateSurface(this, &surfaceDescriptor);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void OnAdapterRequestEnded(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata, void* _)
    {
        GCHandle handle = Unsafe.BitCast<nuint, GCHandle>((nuint)userdata);
        TaskCompletionSource<AdapterHandle>? taskCompletionSource = null;
        try
        {
            taskCompletionSource = (TaskCompletionSource<AdapterHandle>)handle.Target!;

            if (status == RequestAdapterStatus.Success)
            {
                taskCompletionSource.SetResult(adapter);
            }
            else
            {
                string? messageStr = Encoding.UTF8.GetString(message.AsSpan());
                Console.Error.WriteLine($"Failed to request adapter: {messageStr ?? "Failed to get error message"}");
                taskCompletionSource.SetResult(AdapterHandle.Null);
            }
        }
        catch (Exception)
        {
            taskCompletionSource?.SetResult(AdapterHandle.Null);
            WebGPU_FFI.AdapterRelease(adapter);
        }
        finally
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }

    public static ref nuint AsPointer(ref InstanceHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static InstanceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(InstanceHandle handle)
    {
        return handle == Null;
    }

    public static InstanceHandle UnsafeFromPointer(nuint pointer)
    {
        return new InstanceHandle(pointer);
    }

    public static void Reference(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceAddRef(handle);
    }

    public static void Release(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceRelease(handle);
    }

    public Instance? ToSafeHandle() => ToSafeHandle<Instance, InstanceHandle>(this);
}