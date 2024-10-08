using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum CompareFunction
{
    Undefined = 0,
    /// <summary>
    /// Comparison tests never pass.
    /// </summary>
    Never = 1,
    /// <summary>
    /// A provided value passes the comparison test if it is less than the sampled value.
    /// </summary>
    Less = 2,
    /// <summary>
    /// A provided value passes the comparison test if it is equal to the sampled value.
    /// </summary>
    Equal = 3,
    /// <summary>
    /// A provided value passes the comparison test if it is less than or equal to the sampled value.
    /// </summary>
    LessEqual = 4,
    /// <summary>
    /// A provided value passes the comparison test if it is greater than the sampled value.
    /// </summary>
    Greater = 5,
    /// <summary>
    /// A provided value passes the comparison test if it is not equal to the sampled value.
    /// </summary>
    NotEqual = 6,
    /// <summary>
    /// A provided value passes the comparison test if it is greater than or equal to the sampled value.
    /// </summary>
    GreaterEqual = 7,
    /// <summary>
    /// Comparison tests always pass.
    /// </summary>
    Always = 8,
}
