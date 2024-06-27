using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
public enum HeapProperty
{
    DeviceLocal = 1,
    HostVisible = 2,
    HostCoherent = 4,
    HostUncached = 8,
    HostCached = 16,
}
