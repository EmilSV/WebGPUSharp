using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum PowerPreference
{
    Undefined = 0,
    /// <summary>
    /// Indicates a request to prioritize power savings over performance.
    /// Note:
    /// Generally, content should use this if it is unlikely to be constrained by drawing
    /// performance; for example, if it renders only one frame per second, draws only relatively
    /// simple geometry with simple shaders, or uses a small HTML canvas element.
    /// Developers are encouraged to use this value if their content allows, since it may
    /// significantly improve battery life on portable devices.
    /// </summary>
    LowPower = 1,
    /// <summary>
    /// Indicates a request to prioritize performance over power consumption.
    /// Note:
    /// By choosing this value, developers should be aware that, for devices created on the
    /// resulting adapter, user agents are more likely to force device loss, in order to save
    /// power by switching to a lower-power adapter.
    /// Developers are encouraged to only specify this value if they believe it is absolutely
    /// necessary, since it may significantly decrease battery life on portable devices.
    /// </summary>
    HighPerformance = 2,
}
