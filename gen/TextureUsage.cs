using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Different ways that you can use a texture.
/// 
/// The usages determine what kind of memory the texture is allocated from and what actions the texture can partake in.
/// </summary>
[Flags]
public enum TextureUsage : ulong
{
    /// <summary>
    /// No flags set.
    /// </summary>
    None = 0,
    /// <summary>
    /// Allows a texture to be the source in a <see cref="FFI.CommandEncoderHandle.CopyTextureToBuffer" /> or <see cref="FFI.CommandEncoderHandle.CopyTextureToTexture" /> operation.
    /// </summary>
    CopySrc = 1,
    /// <summary>
    /// Allows a texture to be the destination in a <see cref="FFI.CommandEncoderHandle.CopyBufferToTexture" />, <see cref="FFI.CommandEncoderHandle.CopyTextureToTexture" />, or <see cref="FFI.QueueHandle.WriteTexture" /> operation.
    /// </summary>
    CopyDst = 2,
    /// <summary>
    /// Allows a texture to be a <see cref="WebGpuSharp.BindingType.Texture" /> in a bind group.
    /// </summary>
    TextureBinding = 4,
    /// <summary>
    /// Allows a texture to be a <see cref="WebGpuSharp.BindingType.StorageTexture" /> in a bind group.
    /// </summary>
    StorageBinding = 8,
    /// <summary>
    /// Allows a texture to be an output attachment of a render pass.
    /// </summary>
    RenderAttachment = 16,
    TransientAttachment = 32,
}
