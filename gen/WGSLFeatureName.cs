using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum WGSLFeatureName
{
    ReadonlyAndReadwriteStorageTextures = 1,
    Packed4x8IntegerDotProduct = 2,
    UnrestrictedPointerParameters = 3,
    PointerCompositeAccess = 4,
}
