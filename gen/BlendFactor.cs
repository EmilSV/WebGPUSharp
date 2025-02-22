using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Defines how either a source or destination blend factors is calculated
/// </summary>
public enum BlendFactor
{
    Undefined = 0,
    /// <summary>
    /// 0
    /// </summary>
    Zero = 1,
    /// <summary>
    /// 1.0
    /// </summary>
    One = 2,
    /// <summary>
    /// S.component
    /// </summary>
    Src = 3,
    /// <summary>
    /// 1.0 - S.component
    /// </summary>
    OneMinusSrc = 4,
    /// <summary>
    /// S.alpha
    /// </summary>
    SrcAlpha = 5,
    /// <summary>
    /// 1.0 - S.alpha
    /// </summary>
    OneMinusSrcAlpha = 6,
    /// <summary>
    /// D.component
    /// </summary>
    Dst = 7,
    /// <summary>
    /// 1.0 - D.component
    /// </summary>
    OneMinusDst = 8,
    /// <summary>
    /// D.alpha
    /// </summary>
    DstAlpha = 9,
    /// <summary>
    /// 1.0 - D.alpha
    /// </summary>
    OneMinusDstAlpha = 10,
    /// <summary>
    /// min(S.alpha, 1.0 - D.alpha)
    /// </summary>
    SrcAlphaSaturated = 11,
    /// <summary>
    /// Constant
    /// </summary>
    Constant = 12,
    /// <summary>
    /// 1.0 - Constant
    /// </summary>
    OneMinusConstant = 13,
    /// <summary>
    /// S1.component
    /// </summary>
    Src1 = 14,
    /// <summary>
    /// 1.0 - S1.component
    /// </summary>
    OneMinusSrc1 = 15,
    /// <summary>
    /// S1.alpha
    /// </summary>
    Src1Alpha = 16,
    /// <summary>
    /// 1.0 - S1.alpha
    /// </summary>
    OneMinusSrc1Alpha = 17,
}
