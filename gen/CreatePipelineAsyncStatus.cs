using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// CreatePipelineAsyncStatus is used to indicate the status of a CreateRenderPipelineAsync or CreateComputePipelineAsync request.
/// </summary>
public enum CreatePipelineAsyncStatus
{
    /// <summary>
    /// Pipeline creation succeeded.
    /// </summary>
    Success = 1,
    /// <summary>
    /// Pipeline creation was cancelled
    /// </summary>
    CallbackCancelled = 2,
    /// <summary>
    /// Pipeline creation failed due to validation error.
    /// </summary>
    ValidationError = 3,
    /// <summary>
    /// Pipeline creation failed due to internal error.
    /// </summary>
    InternalError = 4,
}
