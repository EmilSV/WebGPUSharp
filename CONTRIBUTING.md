# Contributing to WebGPUSharp
Thank you for your interest in contributing to WebGPUSharp! We welcome contributions from the community to help improve the library. This document outlines the things you should know before contributing

## Philosophy of WebGPUSharp
WebGPUSharp aims to be a low-level and safe C# binding for the WebGPU API. WebGPUSharp aim is to be as close to the javascript WebGPU API as possible as long as the code is performant and idiomatic C#.

This means that contributors should not try to add api that are not part of the WebGPU specification, unless there is a very good reason to do so.

## Where to contribute
WebGPUSharp is using multiple repositories to manage the codebase. The main repository is
- [WebGPUSharp](https://github.com/EmilSV/WebGPUSharp) - The main C# binding for WebGPU.

ther repositories include:
- [webgpu-dawn-build](https://github.com/EmilSV/webgpu-dawn-build) - A repository for building Dawn native binaries for WebGPUSharp and other projects.
- [Webgpusharp-examples](https://github.com/EmilSV/Webgpusharp-examples) - A repository for examples and sample code using WebGPUSharp.
- [Webgpu Bindgen](https://github.com/EmilSV/WebgpuBindgen) - A repository for generating low-level unsafe C# bindings for WebGPU from the C headers. Also holds the documentation comments for the unsafe low-level bindings.
- [bikeshed-to-json-webgpu](https://github.com/EmilSV/bikeshed-to-json-webgpu) - A repository for generating JSON files from the WebGPU specification. these JSON files are used to generate documentation by Webgpu Bindgen.

When contributing, please make sure to contribute to the correct repository.

## AOT support
WebGPUSharp aims to support AOT compilation for platforms like iOS and WebAssembly. When contributing, please make sure that your changes do not break AOT support. Avoid using dynamic code generation or reflection.