using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Vertex Format for a VertexAttribute
/// </summary>
public enum VertexFormat
{
    /// <summary>
    /// One unsigned byte (byte). u32 in shaders.
    /// </summary>
    Uint8 = 1,
    /// <summary>
    /// Two unsigned bytes (byte). vec2&lt;u32&gt; in shaders.
    /// </summary>
    Uint8x2 = 2,
    /// <summary>
    /// Four unsigned bytes (byte). vec4&lt;u32&gt; in shaders.
    /// </summary>
    Uint8x4 = 3,
    /// <summary>
    /// One signed byte (sbyte). i32 in shaders.
    /// </summary>
    Sint8 = 4,
    /// <summary>
    /// Two signed bytes (sbyte). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Sint8x2 = 5,
    /// <summary>
    /// Four signed bytes (sbyte). vec4&lt;i32&gt; in shaders.
    /// </summary>
    Sint8x4 = 6,
    /// <summary>
    /// One unsigned byte (byte). [0, 255] converted to float [0, 1] f32 in shaders.
    /// </summary>
    Unorm8 = 7,
    /// <summary>
    /// Two unsigned bytes (byte). [0, 255] converted to float [0, 1] vec2&lt;32&gt; in shaders.
    /// </summary>
    Unorm8x2 = 8,
    /// <summary>
    /// Four unsigned bytes (byte). [0, 255] converted to float [0, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Unorm8x4 = 9,
    /// <summary>
    /// One signed byte (sbyte). [−127, 127] converted to float [−1, 1] f32 in shaders.
    /// </summary>
    Snorm8 = 10,
    /// <summary>
    /// Two signed bytes (sbyte). [−127, 127] converted to float [−1, 1] vec2&lt;f32&gt; in shaders.
    /// </summary>
    Snorm8x2 = 11,
    /// <summary>
    /// Four signed bytes (sbyte). [−127, 127] converted to float [−1, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Snorm8x4 = 12,
    /// <summary>
    /// One unsigned short (ushort). u32 in shaders.
    /// </summary>
    Uint16 = 13,
    /// <summary>
    /// Two unsigned shorts (ushort). vec2&lt;u32&gt; in shaders.
    /// </summary>
    Uint16x2 = 14,
    /// <summary>
    /// Four signed shorts (short). vec4&lt;i32&gt; in shaders.
    /// </summary>
    Uint16x4 = 15,
    /// <summary>
    /// One signed short (ushort). i32 in shaders.
    /// </summary>
    Sint16 = 16,
    /// <summary>
    /// Two signed shorts (short). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Sint16x2 = 17,
    /// <summary>
    /// Four signed shorts (short). vec4&lt;i32&gt; in shaders.
    /// </summary>
    Sint16x4 = 18,
    /// <summary>
    /// One unsigned short (ushort). [0, 65535] converted to float [0, 1] f32 in shaders.
    /// </summary>
    Unorm16 = 19,
    /// <summary>
    /// Two unsigned shorts (ushort). [0, 65535] converted to float [0, 1] vec2&lt;i32&gt; in shaders.
    /// </summary>
    Unorm16x2 = 20,
    /// <summary>
    /// Four unsigned shorts (ushort). [0, 65535] converted to float [0, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Unorm16x4 = 21,
    /// <summary>
    /// One signed short (short). [−32767, 32767] converted to float [−1, 1] f32 in shaders.
    /// </summary>
    Snorm16 = 22,
    /// <summary>
    /// Two signed shorts (short). [−32767, 32767] converted to float [−1, 1] vec2&lt;i32&gt; in shaders.
    /// </summary>
    Snorm16x2 = 23,
    /// <summary>
    /// Four signed shorts (short). [−32767, 32767] converted to float [−1, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Snorm16x4 = 24,
    /// <summary>
    /// One half-precision float (Half). f32 in shaders.
    /// </summary>
    Float16 = 25,
    /// <summary>
    /// Two half-precision floats (Half). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Float16x2 = 26,
    /// <summary>
    /// Four half-precision floats (Half). vec4&lt;f32&gt; in shaders.
    /// </summary>
    Float16x4 = 27,
    /// <summary>
    /// One single-precision float (float). f32 in shaders.
    /// </summary>
    Float32 = 28,
    /// <summary>
    /// Two single-precision floats (float). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Float32x2 = 29,
    /// <summary>
    /// Three single-precision floats (float). vec3&lt;f32&gt; in shaders.
    /// </summary>
    Float32x3 = 30,
    /// <summary>
    /// Four single-precision floats (float). vec4&lt;f32&gt; in shaders.
    /// </summary>
    Float32x4 = 31,
    /// <summary>
    /// One unsigned int (uint). u32 in shaders.
    /// </summary>
    Uint32 = 32,
    /// <summary>
    /// Two unsigned ints (uint). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Uint32x2 = 33,
    /// <summary>
    /// Three unsigned ints (uint). vec3&lt;u32&gt; in shaders.
    /// </summary>
    Uint32x3 = 34,
    /// <summary>
    /// Four unsigned ints (uint). vec4&lt;u32&gt; in shaders.
    /// </summary>
    Uint32x4 = 35,
    /// <summary>
    /// One signed int (int). i32 in shaders.
    /// </summary>
    Sint32 = 36,
    /// <summary>
    /// Two signed ints (int). vec2&lt;i32&gt; in shaders.
    /// </summary>
    Sint32x2 = 37,
    /// <summary>
    /// Three signed ints (int). vec3&lt;i32&gt; in shaders.
    /// </summary>
    Sint32x3 = 38,
    /// <summary>
    /// Four signed ints (int). vec4&lt;i32&gt; in shaders.
    /// </summary>
    Sint32x4 = 39,
    /// <summary>
    /// Three unsigned 10-bit integers and one 2-bit integer, packed into a 32-bit integer (uint). [0, 1024] converted to float [0, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Unorm10_10_10_2 = 40,
    /// <summary>
    /// Four unsigned 8-bit integers, packed into a 32-bit integer (uint). [0, 255] converted to float [0, 1] vec4&lt;f32&gt; in shaders.
    /// </summary>
    Unorm8x4BGRA = 41,
}
