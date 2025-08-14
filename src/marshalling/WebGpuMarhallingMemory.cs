namespace WebGpuSharp.Marshalling;

public static unsafe class WebGpuMarshallingMemory
{
    private struct WebGpuAllocatorPtr
    {
        public WebGpuAllocator* Allocator;
    }

    private static WebGpuAllocator* _defaultAllocator;
    private static readonly AsyncLocal<WebGpuAllocatorPtr> _asyncLocalAllocator = new AsyncLocal<WebGpuAllocatorPtr>();

    internal static void SetDefaultAllocator(WebGpuAllocator* allocator)
    {
        _defaultAllocator = allocator;
    }

    internal static void SetAsyncContextAllocator(WebGpuAllocator* allocator)
    {
        _asyncLocalAllocator.Value = new WebGpuAllocatorPtr { Allocator = allocator };
    }


    public const int DefaultStartStackSize = 32;

    public static WebGpuAllocatorHandle GetAllocatorHandle(void* stackMemory, nuint size)
    {
        WebGpuAllocator* allocator = _defaultAllocator;
        if (allocator == null)
        {
            allocator = _asyncLocalAllocator.Value.Allocator;
        }

        return new WebGpuAllocatorHandle(allocator, stackMemory, size);
    }

}