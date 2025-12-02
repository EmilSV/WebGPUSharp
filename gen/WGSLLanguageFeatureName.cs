using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// A language extension is an extension which is automatically available if the implementation supports it.
/// The program does not have to explicitly request it.
/// Language extensions embody functionality which could reasonably be supported on any WebGPU implementation.
/// If the feature is not universally available, that it is because some WebGPU implementation has not yet implemented it.
/// </summary>
public enum WGSLLanguageFeatureName
{
    /// <summary>
    /// Allows the use of read and read_write access modes with storage textures. Additionally, adds the textureBarrier built-in function
    /// </summary>
    ReadonlyAndReadwriteStorageTextures = 1,
    /// <summary>
    /// Supports using 32-bit integer scalars packing 4-component vectors of 8-bit integers
    /// as inputs to the dot product instructions with dot4U8Packed and dot4I8Packed built-in functions.
    /// Additionally, adds packing and unpacking instructions with packed 4-component vectors of 8-bit integers with
    /// pack4xI8, pack4xU8, pack4xI8Clamp, pack4xU8Clamp, unpack4xI8, and unpack4xU8 built-in functions.
    /// </summary>
    Packed4x8IntegerDotProduct = 2,
    /// <summary>
    /// Removes the following restrictions from user-defined functions:
    /// For user-defined functions, a parameter of pointer type must be in one of the following address spaces:
    /// <list type="bullet"><item><description>function</description></item><item><description>private</description></item></list>
    /// Each argument of pointer type to a user-defined function must have the same memory view as its root identifier.
    /// </summary>
    /// <remarks>
    /// This means no vector, matrix, array,
    /// or struct access expressions can be applied to produce a memory view into
    /// the root identifier when traced from the argument back through all the let-declarations.
    /// </remarks>
    UnrestrictedPointerParameters = 3,
    /// <summary>
    /// Supports composite-value decomposition expressions where the root expression is a pointer, yielding a reference.
    /// 
    /// For example, if p is a pointer to a structure with member m, then p.m is a reference to the memory locations for m inside the structure p points to.
    /// 
    /// Similarly, if pa is a pointer to an array, then pa[i] is a reference to the memory locations for the i’th element of the array pa points to.
    /// </summary>
    PointerCompositeAccess = 4,
    UniformBufferStandardLayout = 327688,
    SubgroupId = 327689,
}
