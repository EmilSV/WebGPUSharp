using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Backends supported by WebGPU
/// </summary>
public enum BackendType
{
    /// <summary>
    /// No backend is specified. (uses default backend)
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Null backend.
    /// </summary>
    Null = 1,
    /// <summary>
    /// WebGPU backend.
    /// </summary>
    WebGPU = 2,
    /// <summary>
    /// Direct3D 11 backend.
    /// </summary>
    D3D11 = 3,
    /// <summary>
    /// Direct3D 12 backend.
    /// </summary>
    D3D12 = 4,
    /// <summary>
    /// Metal backend.
    /// </summary>
    Metal = 5,
    /// <summary>
    /// Vulkan backend.
    /// </summary>
    Vulkan = 6,
    /// <summary>
    /// OpenGL backend.
    /// </summary>
    OpenGL = 7,
    /// <summary>
    /// OpenGLES backend.
    /// </summary>
    OpenGLES = 8,
}
