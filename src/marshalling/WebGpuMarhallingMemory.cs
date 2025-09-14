using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Marshalling;

public static unsafe class WebGpuMarshallingMemory
{
    private struct WebGpuAllocatorPtr
    {
        public WebGpuAllocator* Allocator;
    }

    private readonly static Lazy<WebGpuAllocatorPtr> _builtinAllocator = new(() =>
    {
        var allocator = (WebGpuAllocator*)NativeMemory.AllocZeroed(1, (nuint)sizeof(WebGpuAllocator));
        ref var allocatorRef = ref *allocator;
        allocatorRef = BuiltInWebGPUAllocator.GetWebGpuAllocator();
        return new WebGpuAllocatorPtr { Allocator = allocator };

    }, isThreadSafe: true);
    private static WebGpuAllocator* _defaultAllocator = null;
    private static readonly AsyncLocal<WebGpuAllocatorPtr> _asyncLocalAllocator = new AsyncLocal<WebGpuAllocatorPtr>();

    public static void SetDefaultAllocator(WebGpuAllocator* allocator)
    {
        _defaultAllocator = allocator;
    }

    internal static void SetAsyncContextAllocator(WebGpuAllocator* allocator)
    {
        if (_asyncLocalAllocator.Value.Allocator != null)
        {
            throw new InvalidOperationException("Async context allocator is already set.");
        }

        _asyncLocalAllocator.Value = new WebGpuAllocatorPtr { Allocator = allocator };
    }

    internal static void RemoveAsyncContextAllocator(WebGpuAllocator* allocator)
    {
        if (_asyncLocalAllocator.Value.Allocator == allocator)
        {
            _asyncLocalAllocator.Value = new WebGpuAllocatorPtr { Allocator = null };
        }
        else
        {
            throw new InvalidOperationException("The provided allocator does not match the current async context allocator.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WebGpuAllocatorHandle GetAllocatorHandle(
        ref WebGpuAllocatorLogicBlock logicBlock, byte* stackMemory, uint size)
    {
        WebGpuAllocator* allocator = _asyncLocalAllocator.Value.Allocator;
        if (allocator == null)
        {
            allocator = _defaultAllocator;
        }
        if (allocator == null)
        {
            _defaultAllocator = allocator = _builtinAllocator.Value.Allocator;
        }

        return new WebGpuAllocatorHandle(ref logicBlock, allocator, stackMemory, size);
    }
}