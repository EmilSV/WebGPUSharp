using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum PresentMode
{
    Fifo = 1,
    FifoRelaxed = 2,
    Immediate = 3,
    Mailbox = 4,
}
