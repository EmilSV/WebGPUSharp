# Building debug dawn

## System requirements
 * Git


Create a folder somewhere
```sh
mkdir dawn_build
``` 
Download the [setup_dawn.ps1] script and run it

[setup_dawn.ps1]: https://github.com/EmilSV/WebGPUSharp/script/setup_dawn.ps1

```sh
./setup_dawn.ps1
``` 

The script can take some time when it is done run
```sh
gn args out/Debug ide=vs2022
```
a notepad window wil popup paste this into the window and close it

```ini
# Build with VS
is_clang=false
visual_studio_version="2022"

# Debug build
is_debug=true
enable_iterator_debugging=true
symbol_level=2

# Don't need these features
dawn_use_angle=false
dawn_use_swiftshader=false

use_custom_libcxx = false
dawn_use_built_dxc = false

#only one output library
dawn_complete_static_libs = true
```

Now run 
```sh
ninja -C out\Debug src/dawn/native:shared webgpu_dawn
```
inside dawn/out/debug should be the dll platform.dll and webgpu_dawn.dll 

# Use debug Dawn in project

At the start of your main write
```cs
//Need to load platform.dll first
NativeLibrary.Load("whereYouPutDawn\\dawn\\out\\Debug\\dawn_platform.dll");

//Makes dawn break on error
Environment.SetEnvironmentVariable("DAWN_DEBUG_BREAK_ON_ERROR", "1");

//intercept whenever WebGpuSharp request webgpu_dawn.dll
NativeLibrary.SetDllImportResolver(
    assembly: typeof(WebGpuSharp.WebGPU).Assembly,
    resolver: (libraryName, assembly, searchPath) =>
    {
        if (libraryName == "webgpu_dawn")
        {
            return NativeLibrary.Load("whereYouPutDawn\\dawn\\out\\Debug\\webgpu_dawn.dll");
        }
        return IntPtr.Zero;
    }
);
``` 