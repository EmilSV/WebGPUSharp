using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes when and in which order frames are presented on the screen when <see cref="Surface.Present" /> is called.
/// </summary>
public enum PresentMode
{
    /// <summary>
    /// The presentation mode is not defined.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// The presentation of the image to the user waits for the next vertical blanking period to update in a first-in, first-out manner.
    /// Tearing cannot be observed and frame-loop will be limited to the display's refresh rate.
    /// This is the only mode that's always available.
    /// </summary>
    Fifo = 1,
    /// <summary>
    /// The presentation of the image to the user tries to wait for the next vertical blanking period but may decide to not wait if a frame is presented late.
    /// Tearing can sometimes be observed but late-frame don't produce a full-frame stutter in the presentation.
    /// This is still a first-in, first-out mechanism so a frame-loop will be limited to the display's refresh rate.
    /// </summary>
    FifoRelaxed = 2,
    /// <summary>
    /// The presentation of the image to the user is updated immediately without waiting for a vertical blank.
    /// Tearing can be observed but latency is minimized.
    /// </summary>
    Immediate = 3,
    /// <summary>
    /// The presentation of the image to the user waits for the next vertical blanking period to update to the latest provided image.
    /// Tearing cannot be observed and a frame-loop is not limited to the display's refresh rate.
    /// </summary>
    Mailbox = 4,
}
