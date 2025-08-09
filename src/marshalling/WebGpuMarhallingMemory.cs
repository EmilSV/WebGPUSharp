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

}