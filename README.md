# WebGPUSharp
WebGPU native bindings with a safe C# wrapper API on top mirroring the JavaScript API in the browser.

## Overview
WebGPUSharp provides low-level bindings to the native WebGPU API through P/Invoke [without runtime marshalling](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/disabled-marshalling). Along with a high-level C# wrapper that closely follows the WebGPU JavaScript API. This allows developers to write GPU-accelerated applications in C# with a familiar API surface and to translate WebGPU JavaScript code to C# easily.

## Installation
WebGPUSharp requires .NET 9 or later. You can install the package via NuGet:

```bash
dotnet add package WebGPUSharp
```

## Getting Started
Here is a simple hello world triangle example using WebGPUSharp and SDL2(via ppy.SDL2-CS) for window creation and surface handling:

```csharp
using static SDL2.SDL;
using WebGpuSharp;

const string TriangleVertShaderSource =
"""
    @vertex
    fn main(
    @builtin(vertex_index) VertexIndex : u32
    ) -> @builtin(position) vec4f {
    var pos = array<vec2f, 3>(
        vec2(0.0, 0.5),
        vec2(-0.5, -0.5),
        vec2(0.5, -0.5)
    );

    return vec4f(pos[VertexIndex], 0.0, 1.0);
    }
""";

const string RedFragShaderSource =
"""
    @fragment
    fn main() -> @location(0) vec4f {
    return vec4(1.0, 0.0, 0.0, 1.0);
    }
""";

const int WIDTH = 800;
const int HEIGHT = 600;

SDL_SetMainReady();
if (SDL_Init(SDL_INIT_EVERYTHING) < 0)
{
    Console.Error.WriteLine($"Could not initialize SDL! Error: {SDL_GetError()}");
    return 1;
}

var instance = WebGPU.CreateInstance()!;
var window = SDL_CreateWindow("Hello world!", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, WIDTH, HEIGHT, (SDL_WindowFlags)0);
var surface = SDL_GetWGPUSurface(instance, window)!;

// SDL2 do not like async/await as it can switch threads, so we block here
var adapter = instance.RequestAdapterAsync(new()
{
    CompatibleSurface = surface
}).Result!;

var device = adapter.RequestDeviceAsync().Result!;
var queue = device.GetQueue()!;
var surfaceFormat = TextureFormat.BGRA8Unorm;

surface.Configure(new()
{
    Width = WIDTH,
    Height = HEIGHT,
    Usage = TextureUsage.RenderAttachment,
    Format = surfaceFormat,
    Device = device,
    PresentMode = PresentMode.Fifo,
    AlphaMode = CompositeAlphaMode.Auto,
});


var pipeline = device.CreateRenderPipeline(new()
{
    Layout = null, // Auto-layout
    Vertex = new()
    {
        Module = device.CreateShaderModuleWGSL(new()
        {
            Code = TriangleVertShaderSource
        }),
    },
    Fragment = new()
    {
        Module = device.CreateShaderModuleWGSL(new()
        {
            Code = RedFragShaderSource
        }),
        Targets = [
            new()
            {
                Format = surfaceFormat
            }
      ]
    },
    Primitive = new()
    {
        Topology = PrimitiveTopology.TriangleList,
    },
})!;

while (true)
{
    while (SDL_PollEvent(out var @event) != 0)
    {
        switch (@event.type)
        {
            case SDL_EventType.SDL_QUIT:
                return 0;
            default:
                break;
        }
    }
    var commandEncoder = device.CreateCommandEncoder(new());
    var texture = surface.GetCurrentTexture().Texture!;
    var textureView = texture.CreateView()!;

    var passEncoder = commandEncoder.BeginRenderPass(new()
    {
        ColorAttachments = [
            new()
                {
                    View = textureView,
                    LoadOp = LoadOp.Clear,
                    StoreOp = StoreOp.Store,
                    ClearValue = new(0, 0, 0, 0),
                }
        ],
    });

    passEncoder.SetPipeline(pipeline);
    passEncoder.Draw(3);
    passEncoder.End();

    queue.Submit([commandEncoder.Finish()]);
    surface.Present();
}

static unsafe Surface? SDL_GetWGPUSurface(Instance instance, nint window)
{
    SDL_SysWMinfo windowWMInfo = new();
    SDL_VERSION(out windowWMInfo.version);
    SDL_GetWindowWMInfo(window, ref windowWMInfo);

    if (windowWMInfo.subsystem == SDL_SYSWM_TYPE.SDL_SYSWM_WINDOWS)
    {
        var wsDescriptor = new WebGpuSharp.FFI.SurfaceSourceWindowsHWNDFFI()
        {
            Hinstance = (void*)windowWMInfo.info.win.hinstance,
            Hwnd = (void*)windowWMInfo.info.win.window,
            Chain = new()
            {
                SType = SType.SurfaceSourceWindowsHWND
            }
        };

        SurfaceDescriptor descriptor_surface = new(ref wsDescriptor);
        return instance.CreateSurface(descriptor_surface);
    }
    else if (windowWMInfo.info.wl.surface != 0 && windowWMInfo.subsystem == SDL_SYSWM_TYPE.SDL_SYSWM_WAYLAND)
    {
        var wlDescriptor = new WebGpuSharp.FFI.SurfaceSourceWaylandSurfaceFFI
        {
            Chain = new ChainedStruct
            {
                Next = null,
                SType = SType.SurfaceSourceWaylandSurface
            },
            Display = (void*)windowWMInfo.info.wl.display,
            Surface = (void*)windowWMInfo.info.wl.surface
        };
        SurfaceDescriptor descriptor_surface = new(ref wlDescriptor);
        return instance.CreateSurface(descriptor_surface);
    }
    else if (windowWMInfo.info.x11.window != 0 && windowWMInfo.subsystem == SDL_SYSWM_TYPE.SDL_SYSWM_X11)
    {
        var xlibDescriptor = new WebGpuSharp.FFI.SurfaceSourceXlibWindowFFI
        {
            Chain = new ChainedStruct
            {
                Next = null,
                SType = SType.SurfaceSourceXlibWindow
            },
            Display = (void*)windowWMInfo.info.x11.display,
            Window = (uint)windowWMInfo.info.x11.window
        };
        SurfaceDescriptor descriptor_surface = new(ref xlibDescriptor);
        return instance.CreateSurface(descriptor_surface);
    } 
    else if (windowWMInfo.subsystem == SDL_SYSWM_TYPE.SDL_SYSWM_COCOA)
    {
        //Sadly macos is to long to show in this snippet see:
        // https://github.com/EmilSV/Webgpusharp-examples/blob/main/Setup/SDLWebgpu.cs
    }

    throw new Exception("Platform not supported");
}
```

## Examples
You can find more examples in the [WebGPUSharp-Examples](https://github.com/EmilSV/Webgpusharp-examples) repository they are all ports of the official [WebGPU samples](https://webgpu.github.io/webgpu-samples) to C# using WebGPUSharp.


## Buffers
WebGPUSharps Buffers are different from their javascript two ways

* When you get the mapped data you get it thought a callback via a span this is for safety reasons as if you just got a span you cloud unmap the buffer while still holding a reference to the span causing undefined behavior.
```csharp

var buffer = device.CreateBuffer(new()
{
    Size = 1024,
    Usage = BufferUsage.Vertex | BufferUsage.CopyDst,
    MappedAtCreation = true // Create the buffer in a mapped state
});

// If it was not using callbacks it would look like this unsafe code:

var span = buffer.GetMappedRange<float>()

buffer.Unmap();

span[0] = 1.0f; // This would be undefined behavior as the buffer is unmapped

// instead we have to do it like this:
buffer.GetMappedRange<float>(data =>
{
    data[0] = 1.0f; // Safe to use data here

    //if we unmap here it would would just throw as the buffer is begging used
    // this would not be possible without callbacks as the callback is the way we know the buffer is being used
    // buffer.Unmap(); // This would throw

});
buffer.Unmap();

```


* C# has struct so when your read and write to buffers you can use structs to represent the data layout in the buffer instead of manually calculating offsets here an example of writing an array of structs to a buffer:


```csharp

// a vertex struct with padding to ensure 16 byte alignment
// you can use https://eliemichel.github.io/WebGPU-AutoLayout/ to help with calculating padding
[StructLayout(LayoutKind.Sequential)]
public struct Vertex
{
    public Vector3 Position;
    private float _pad1; // Padding to align to 16 bytes
    public Vector3 Normal;
    private float _pad2; // Padding to align to 16 bytes
    public Vector2 Uv;
    private float _pad3; 
    private float _pad4; // Padding to align to 16 bytes
}

Vertex[] vertices =
[
    new Vertex { Position = new(0, 1, 0), Normal = new(0, 0, 1), Uv = new(0.5f, 1) },
    new Vertex { Position = new(-1, -1, 0), Normal = new(0, 0, 1), Uv = new(0, 0) },
    new Vertex { Position = new(1, -1, 0), Normal = new(0, 0, 1), Uv = new(1, 0) },
];

var vertexBuffer = device.CreateBuffer(new()
{
    Size = (ulong)(Unsafe.SizeOf<Vertex>() * vertices.Length),
    Usage = BufferUsage.Vertex | BufferUsage.CopyDst,
    MappedAtCreation = true
});

vertexBuffer.GetMappedRange<Vertex>(data => ((ReadOnlySpan<Vertex>)vertices).CopyTo(data));
vertexBuffer.Unmap();
```
## Read/Writing from multiple Buffers
When read/writing from multiple buffers `GetMappedRange` can be rader cumbersome as you have to nest the callbacks which do not work well with spans.
To solve this WebGpuSharp provides the `Buffer.DoReadWriteOperation` methods which allows you to read/write from multiple buffers in a single callback:
```csharp

var bufferA = device.CreateBuffer(new()
{
    Size = 1024,
    Usage = BufferUsage.MapRead | BufferUsage.CopyDst,
    MappedAtCreation = true
});

var bufferB = device.CreateBuffer(new()
{
    Size = 1024,
    Usage = BufferUsage.MapWrite | BufferUsage.CopyDst,
    MappedAtCreation = true
});

Buffer.DoReadWriteOperation([bufferA, bufferB]/*The buffers to operate on*/, context =>
{
    var spanA = context.GetConstMappedRange<float>(bufferA);
    var spanB = context.GetMappedRange<float>(bufferB);

    // Read from bufferA and write to bufferB
    for (int i = 0; i < spanA.Length; i++)
    {
        spanB[i] = spanA[i] * 2.0f;
    }
});
```

## Managed vs Unmanaged/unsafe API
There is two API levels in WebGPUSharp the unmanaged unsafe API and a managed safe API build on top of the unmanaged one. You can tell them apart as the unmanaged API lives in the `WebGpuSharp.FFI` namespace and uses raw handles for resource while the managed API lives in the `WebGpuSharp` namespace and uses classes for resource. For example here is how to create a buffer using the unmanaged API:

```csharp
using WebGpuSharp.FFI;

BufferDescriptorFFI bufferDescriptor = new()
{
    Size = 1024,
    Usage = BufferUsageFFI.Vertex | BufferUsageFFI.CopyDst,
    MappedAtCreation = true
};

using BufferHandle buffer = device.CreateBuffer(&bufferDescriptor);
float* data = (float*)buffer.GetMappedRange(0, 1024);
for (int i = 0; i < 256; i++)
{
    data[i] = i * 1.0f;
}
buffer.Unmap();

```
You can convert a Managed object to an unmanaged handle using the `WebGPUMarshal.GetBorrowHandle` or the `WebGPUMarshal.GetOwnedHandle` methods. And you can convert an unmanaged handle to a managed object using the `WebGPUMarshal.ToSafeHandle` and `WebGPUMarshal.ToSafeHandleNoRefIncrement` method. The difference between Borrow and Owned is that an owned handle will increment the reference count of the unmanaged resource while a borrowed handle will not. So an owned handle should be used when you want to keep a reference to the resource while a borrowed handle should be used when you just need to use the resource temporarily.

```csharp
using WebGpuSharp;
Buffer buffer = device.CreateBuffer(new()
{
    Size = 1024,
    Usage = BufferUsage.Vertex | BufferUsage.CopyDst,
    MappedAtCreation = true
});

// Convert to unmanaged owned handle
BufferHandle ownedHandle = WebGPUMarshal.GetOwnedHandle(buffer);
// Convert back to managed object
Buffer managedBuffer = WebGPUMarshal.ToSafeHandle<Buffer, BufferHandle>(ownedHandle);
```

## License
WebGPUSharp is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
WebGPUSharp is using dawn as the native WebGPU implementation which is licensed under BSD 3-Clause License. See the [dawn LICENSE](https://dawn.googlesource.com/dawn/+/HEAD/LICENSE) for more information.