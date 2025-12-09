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
Here is a simple hello world triangle example using WebGPUSharp:

```csharp

```