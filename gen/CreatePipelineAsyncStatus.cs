using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CreatePipelineAsyncStatus
{
    Success = 1,
    CallbackCancelled = 2,
    ValidationError = 3,
    InternalError = 4,
}
