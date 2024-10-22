using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum WGSLFeatureName
{
    ReadonlyAndReadwriteStorageTextures = 1,
    Packed4x8IntegerDotProduct = 2,
    UnrestrictedPointerParameters = 3,
    PointerCompositeAccess = 4,
    ChromiumTestingUnimplemented = 327680,
    ChromiumTestingUnsafeExperimental = 327681,
    ChromiumTestingExperimental = 327682,
    ChromiumTestingShippedWithKillswitch = 327683,
    ChromiumTestingShipped = 327684,
}
