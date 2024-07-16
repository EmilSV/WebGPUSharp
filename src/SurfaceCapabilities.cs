using WebGpuSharp.FFI;

namespace WebGpuSharp;

public class SurfaceCapabilities
{
    private TextureFormat[] _formatsArray = [];
    private int _formatsArrayCount = 0;
    private PresentMode[] _presentModesArray = [];
    private int _presentModesArrayCount = 0;
    private AlphaMode[] _alphaModesArray = [];
    private int _alphaModesArrayCount = 0;

    public TextureUsage Usages { get; private set; }
    public ReadOnlySpan<TextureFormat> Formats => _formatsArray.AsSpan(0, _formatsArrayCount);
    public ReadOnlySpan<PresentMode> PresentModes => _presentModesArray.AsSpan(0, _presentModesArrayCount);
    public ReadOnlySpan<AlphaMode> AlphaModes => _alphaModesArray.AsSpan(0, _alphaModesArrayCount);

    internal unsafe Status SetInternalSurfaceCapabilities(SurfaceHandle surface, AdapterHandle adapter)
    {
        SurfaceCapabilitiesFFI surfaceCapabilitiesFFI = default;
        var status = surface.GetCapabilities(adapter, ref surfaceCapabilitiesFFI);

        if (status == Status.Success)
        {
            Usages = surfaceCapabilitiesFFI.Usages;

            _formatsArrayCount = (int)surfaceCapabilitiesFFI.FormatCount;
            if (_formatsArray.Length < _formatsArrayCount)
            {
                Array.Resize(ref _formatsArray, _formatsArrayCount);
            }
            new ReadOnlySpan<TextureFormat>(surfaceCapabilitiesFFI.Formats, _formatsArrayCount).CopyTo(_formatsArray);

            _presentModesArrayCount = (int)surfaceCapabilitiesFFI.PresentModeCount;
            if (_presentModesArray.Length < _presentModesArrayCount)
            {
                Array.Resize(ref _presentModesArray, _presentModesArrayCount);
            }
            new ReadOnlySpan<PresentMode>(surfaceCapabilitiesFFI.PresentModes, _presentModesArrayCount).CopyTo(_presentModesArray);

            _alphaModesArrayCount = (int)surfaceCapabilitiesFFI.AlphaModeCount;
            if (_alphaModesArray.Length < _alphaModesArrayCount)
            {
                Array.Resize(ref _alphaModesArray, _alphaModesArrayCount);
            }
            new ReadOnlySpan<AlphaMode>(surfaceCapabilitiesFFI.AlphaModes, _alphaModesArrayCount).CopyTo(_alphaModesArray);
        }

        WebGPU_FFI.SurfaceCapabilitiesFreeMembers(surfaceCapabilitiesFFI);
        return status;
    }
}