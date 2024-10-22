using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum LoadOp
{
    Undefined = 0,
    /// <summary>
    /// Loads the existing value for this attachment into the render pass.
    /// </summary>
    Load = 1,
    /// <summary>
    /// Loads a clear value for this attachment into the render pass.
    /// Note:
    /// On some GPU hardware (primarily mobile),  <see cref="Clear"/> is significantly cheaper
    /// because it avoids loading data from main memory into tile-local memory.
    /// On other GPU hardware, there isn't a significant difference. As a result, it is
    /// recommended to use  <see cref="Clear"/> rather than  <see cref="Load"/> in cases where the
    /// initial value doesn't matter (e.g. the render target will be cleared using a skybox).
    /// </summary>
    Clear = 2,
    ExpandResolveTexture = 327683,
}
