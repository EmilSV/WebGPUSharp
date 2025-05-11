using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// CompilationInfoRequestStatus is used to indicate the status of a GetCompilationInfo	 request.
/// </summary>
public enum CompilationInfoRequestStatus
{
    /// <summary>
    /// Compilation succeeded.
    /// </summary>
    Success = 1,
    /// <summary>
    /// Compilation was cancelled
    /// </summary>
    CallbackCancelled = 2,
}
