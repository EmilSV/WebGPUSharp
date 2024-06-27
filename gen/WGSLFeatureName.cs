using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum WGSLFeatureName
{
    ReadonlyAndReadwriteStorageTextures = 1,
    Packed4x8IntegerDotProduct = 2,
    UnrestrictedPointerParameters = 3,
    PointerCompositeAccess = 4,
    ChromiumTestingUnimplemented = 1000,
    ChromiumTestingUnsafeExperimental = 1001,
    ChromiumTestingExperimental = 1002,
    ChromiumTestingShippedWithKillswitch = 1003,
    ChromiumTestingShipped = 1004,
}
