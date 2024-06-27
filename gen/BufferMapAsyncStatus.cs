using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum BufferMapAsyncStatus
{
    Success = 1,
    InstanceDropped = 2,
    ValidationError = 3,
    Unknown = 4,
    DeviceLost = 5,
    DestroyedBeforeCallback = 6,
    UnmappedBeforeCallback = 7,
    MappingAlreadyPending = 8,
    OffsetOutOfRange = 9,
    SizeOutOfRange = 10,
}
