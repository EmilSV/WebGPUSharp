using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Operation to perform to the output attachment at the end of a render pass.
/// </summary>
public enum StoreOp
{
    /// <summary>
    /// Indicates no value is passed for this argument
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Stores the resulting value of the render pass for this attachment.
    /// </summary>
    Store = 1,
    /// <summary>
    /// Discards the resulting value of the render pass for this attachment.
    /// Note: Discarded attachments
    /// behave as if they are cleared to zero, but implementations are not required to perform a
    /// clear at the end of the render pass. Implementations which do not explicitly clear discarded
    /// attachments at the end of a pass must lazily clear them prior to the reading the attachment
    /// contents, which occurs via sampling, copies, attaching to a later render pass with
    ///  <see cref="LoadOp.Load"/>, displaying or reading back the canvas
    /// (get a copy of the image contents of a context), etc.
    /// </summary>
    Discard = 2,
}
