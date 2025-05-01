using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes when and in which order frames are presented on the screen when <see cref="Surface.Present" /> is called.
/// </summary>
public enum PresentMode
{
    Undefined = 0,
    Fifo = 1,
    FifoRelaxed = 2,
    Immediate = 3,
    Mailbox = 4,
}
