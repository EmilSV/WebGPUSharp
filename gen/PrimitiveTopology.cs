using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Primitive type the input mesh is composed of.
/// </summary>
public enum PrimitiveTopology
{
    /// <summary>
    /// Primitive topology is not defined.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Each vertex defines a point primitive.
    /// </summary>
    PointList = 1,
    /// <summary>
    /// Each consecutive pair of two vertices defines a line primitive.
    /// </summary>
    LineList = 2,
    /// <summary>
    /// Each vertex after the first defines a line primitive between it and the previous vertex.
    /// </summary>
    LineStrip = 3,
    /// <summary>
    /// Each consecutive triplet of three vertices defines a triangle primitive.
    /// </summary>
    TriangleList = 4,
    /// <summary>
    /// Each vertex after the first two defines a triangle primitive between it and the previous
    /// two vertices.
    /// </summary>
    TriangleStrip = 5,
}
