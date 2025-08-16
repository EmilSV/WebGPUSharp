using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Marshalling;

public static unsafe class WebGpuMarshallingMemory
{
    private struct WebGpuAllocatorPtr
    {
        public WebGpuAllocator* Allocator;
    }

    private static int _isBuiltInAllocatorInitialized = 0;
    private readonly static Lazy<WebGpuAllocatorPtr> _builtinAllocator = new(() =>
    {
        var allocator = (WebGpuAllocator*)NativeMemory.AllocZeroed(1, (nuint)sizeof(WebGpuAllocator));
        ref var allocatorRef = ref *allocator;
        allocatorRef = BuiltInWebGPUAllocator.GetWebGpuAllocator();
        return new WebGpuAllocatorPtr { Allocator = allocator };

    }, isThreadSafe: true);
    private static WebGpuAllocator* _defaultAllocator;
    private static readonly AsyncLocal<WebGpuAllocatorPtr> _asyncLocalAllocator = new AsyncLocal<WebGpuAllocatorPtr>();

    public static void SetDefaultAllocator(WebGpuAllocator* allocator)
    {
        _defaultAllocator = allocator;
    }

    internal static void SetAsyncContextAllocator(WebGpuAllocator* allocator)
    {
        _asyncLocalAllocator.Value = new WebGpuAllocatorPtr { Allocator = allocator };
    }

    public const int DefaultStartStackSize = 32;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WebGpuAllocatorHandle GetAllocatorHandle(void* stackMemory, nuint size)
    {
        WebGpuAllocator* allocator = _asyncLocalAllocator.Value.Allocator;
        if (allocator == null)
        {
            allocator = _defaultAllocator;
        }
        if (allocator == null)
        {
            _defaultAllocator = allocator = _asyncLocalAllocator.Value.Allocator;
        }

        return new WebGpuAllocatorHandle(allocator, stackMemory, size);
    }
}