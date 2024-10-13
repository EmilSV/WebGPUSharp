using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe class TextureViewProxy : ITextureViewSource
{
    private bool _viewDirty = true;
    private ITextureSource? _textureSource;
    private TextureViewDescriptorFFI _descriptor;
    private TextureViewHandle _textureView;

    public required string Label { get; init; }

    public void ForceViewRefresh()
    {
        _viewDirty = true;
    }

    public ITextureSource? textureSource
    {
        get => _textureSource;
        set
        {
            _viewDirty = _textureSource != value;
            _textureSource = value;
        }
    }

    public TextureViewDimension Dimension
    {
        get => _descriptor.Dimension;
        set
        {
            _viewDirty = _descriptor.Dimension != value;
            _descriptor.Dimension = value;
        }
    }

    public uint BaseMipLevel
    {
        get => _descriptor.BaseMipLevel;
        set
        {
            _viewDirty = _descriptor.BaseMipLevel != value;
            _descriptor.BaseMipLevel = value;
        }
    }
    public uint MipLevelCount
    {
        get => _descriptor.MipLevelCount;
        set
        {
            _viewDirty = _descriptor.MipLevelCount != value;
            _descriptor.MipLevelCount = value;
        }
    }
    public uint BaseArrayLayer
    {
        get => _descriptor.BaseArrayLayer;
        set
        {
            _viewDirty = _descriptor.BaseArrayLayer != value;
            _descriptor.BaseArrayLayer = value;
        }
    }
    public uint ArrayLayerCount
    {
        get => _descriptor.ArrayLayerCount;
        set
        {
            _viewDirty = _descriptor.ArrayLayerCount != value;
            _descriptor.ArrayLayerCount = value;
        }
    }
    public TextureAspect Aspect
    {
        get => _descriptor.Aspect;
        set
        {
            _viewDirty = _descriptor.Aspect != value;
            _descriptor.Aspect = value;
        }
    }


    TextureView? ITextureViewSource.GetCurrentTextureView()
    {
        return ((ITextureViewSource)this).UnsafeGetCurrentTextureViewOwnedHandle().ToSafeHandle(true);
    }

    TextureViewHandle ITextureViewSource.UnsafeGetCurrentTextureViewOwnedHandle()
    {
        if (_textureSource == null)
        {
            return TextureViewHandle.Null;
        }

        if (!_viewDirty)
        {
            TextureViewHandle.Reference(_textureView);
            return _textureView;
        }

        _viewDirty = false;

        _textureView.Dispose();
        _textureView = default;

        using var texture = _textureSource.UnsafeGetCurrentOwnedTextureHandle();
        _descriptor.Format = texture.GetFormat();

        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelSpan = WebGPUMarshal.ToUtf8Span(Label, allocator);
        fixed (byte* labelPtr = labelSpan)
        {
            _descriptor.Label = new(labelPtr, (uint)labelSpan.Length);
            _textureView = texture.CreateView(_descriptor);
        }

        TextureViewHandle.Reference(_textureView);
        return _textureView;
    }

    ~TextureViewProxy()
    {
        _textureView.Dispose();
    }
}