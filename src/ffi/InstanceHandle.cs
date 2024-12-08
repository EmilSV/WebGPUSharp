#pragma warning disable CS0162 // Unreachable code detected  

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;
namespace WebGpuSharp.FFI;


public readonly unsafe partial struct InstanceHandle :
    IDisposable, IWebGpuHandle<InstanceHandle, Instance>
{
    public Task<AdapterHandle> RequestAdapterAsync(in RequestAdapterOptionsFFI options)
    {
        unsafe
        {
            TaskCompletionSource<AdapterHandle> taskCompletionSource;
            CallbackUserDataHandle handle = default;
            try
            {
                taskCompletionSource = new TaskCompletionSource<AdapterHandle>();
                handle = CallbackUserDataHandle.Alloc(taskCompletionSource);

                fixed (RequestAdapterOptionsFFI* optionsPtr = &options)
                {
                    WebGPU_FFI.InstanceRequestAdapter(
                       instance: this,
                       options: optionsPtr,
                       callback: &OnAdapterRequestEnded,
                       userdata: (void*)handle
                    );
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                if (handle.IsValid())
                {
                    handle.Dispose();
                }
                return Task.FromResult(AdapterHandle.Null);
            }

            return taskCompletionSource.Task;
        }
    }

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

    public SurfaceHandle CreateSurface(in SurfaceDescriptorFFI descriptor)
    {
        fixed (SurfaceDescriptorFFI* surfaceDescriptorPtr = &descriptor)
        {
            return WebGPU_FFI.InstanceCreateSurface(this, surfaceDescriptorPtr);
        }
    }

    public SurfaceHandle CreateSurface(SurfaceDescriptor descriptor)
    {
        unsafe
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            ref var next = ref descriptor._next;

            var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

            fixed (byte* labelPtr = labelUtf8Span)
            fixed (ChainedStruct* nextPtr = &next)
            {
                SurfaceDescriptorFFI surfaceDescriptor = new()
                {
                    NextInChain = nextPtr,
                    Label = new(labelPtr, labelUtf8Span.Length)
                };
                return WebGPU_FFI.InstanceCreateSurface(this, &surfaceDescriptor);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void OnAdapterRequestEnded(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<AdapterHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<AdapterHandle>)handle.GetObject()!;

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
            if (handle.IsValid())
            {
                handle.Dispose();
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

    public Instance? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Instance, InstanceHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Instance, InstanceHandle>(this);
        }
    }
}