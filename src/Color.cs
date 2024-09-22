using System.Diagnostics.CodeAnalysis;

namespace WebGpuSharp;

public partial struct Color
{
    [SetsRequiredMembers]
    public Color(double r, double g, double b, double a = 1)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }
}
