using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Color
{
    public double R;
    public double G;
    public double B;
    public double A;

    public Color()
    {
    }


    public Color(double r = default, double g = default, double b = default, double a = default)
    {
        this.R = r;
        this.G = g;
        this.B = b;
        this.A = a;
    }

}
