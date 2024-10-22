using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum SharedFenceType
{
    VkSemaphoreOpaqueFD = 1,
    VkSemaphoreSyncFD = 2,
    VkSemaphoreZirconHandle = 3,
    DXGISharedHandle = 4,
    MTLSharedEvent = 5,
}
