#pragma warning disable CS0162 // Unreachable code detected  

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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


    public void ProcessEvents()
    {
        WebGPU_FFI.InstanceProcessEvents(this);
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
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            fixed (ChainedStruct* nextPtr = &next)
            {
                var surfaceDescriptor = new SurfaceDescriptorFFI(
                    nextInChain: nextPtr,
                    label: labelPtr
                );
                return WebGPU_FFI.InstanceCreateSurface(this, &surfaceDescriptor);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnAdapterRequestEnded(
        RequestAdapterStatus status, AdapterHandle adapter,
        byte* message, void* userdata)
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
                string? messageStr = Marshal.PtrToStringAnsi((IntPtr)message);
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
        WebGPU_FFI.InstanceReference(handle);
    }

    public static void Release(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceRelease(handle);
    }

    public Instance? ToSafeHandle(bool isOwnedHandle)
    {
        return Instance.FromHandle(this, isOwnedHandle);
    }
}