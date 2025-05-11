using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// CompareFunction specifies the behavior of a comparison sampler. If a comparison
/// sampler is used in a shader, the depth_ref is compared to the fetched texel value, and
/// the result of this comparison test is generated (1.0f for pass, or 0.0f for fail).
/// 
/// After comparison, if texture filtering is enabled, the filtering step occurs, so that
/// comparison results are mixed together resulting in values in the range [0, 1]. Filtering
/// should behave as usual, however it may be computed with lower precision or not mix
/// results at all.
/// </summary>
public enum CompareFunction
{
    /// <summary>
    /// No CompareFunction is provided.
    /// </summary>
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
