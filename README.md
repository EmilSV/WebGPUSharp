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
You can find more examples in the [WebGPUSharp-Examples](https://github.com/EmilSV/Webgpusharp-examples) repository they are all ports of the official [WebGPU samples](https://webgpu.github.io/webgpu-samples) to C# and WebGPUSharp.


## Buffers
WebGPUSharps Buffers are different from multiple ways first C# has struct so when your read and write to buffers you can use structs to represent the data layout in the buffer instead of manually calculating offsets here an example of writing a struct to a buffer:

```csharp
public struct Vertex
{
    public Vector3 Position;
    public Vector3 Normal;
    public Vector2 Uv;
}

var vertices = new Vertex[]
{
    new Vertex { Position = new Vector3(0, 1, 0), Normal = new Vector3(0, 0, 1), Uv = new Vector2(0.5f, 1) },
    new Vertex { Position = new Vector3(-1, -1, 0), Normal = new Vector3(0, 0, 1), Uv = new Vector2(0, 0) },
    new Vertex { Position = new Vector3(1, -1, 0), Normal = new Vector3(0, 0, 1), Uv = new Vector2(1, 0) },
};

var vertexBuffer = device.CreateBuffer(new BufferDescriptor
{
    Size = (ulong)(Unsafe.SizeOf<Vertex>() * vertices.Length),
    Usage = BufferUsage.Vertex | BufferUsage.CopyDst,
    MappedAtCreation = true
});

vertexBuffer.GetMappedRange<Vertex>(data => ((ReadOnlySpan<Vertex>)vertices).CopyTo(data));
vertexBuffer.Unmap();
```
