
using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.Marshalling;


public unsafe struct WebGpuAllocatorScope : IDisposable
{
    private WebGpuAllocator* _allocator;
    private WebGpuDisposeSentinel _disposeSentinel;

    public static WebGpuAllocatorScope Create(WebGpuAllocator* allocator, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
    {
        var scope = new WebGpuAllocatorScope
        {
            _allocator = allocator,
            _disposeSentinel = WebGpuDisposeSentinel.Get(callerFilePath, callerLineNumber)
        };

        WebGpuMarshallingMemory.SetAsyncContextAllocator(allocator);
        return scope;
    }

    public void Dispose()
    {
        _disposeSentinel.Return();
        WebGpuMarshallingMemory.RemoveAsyncContextAllocator(_allocator);
    }
}