using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[Flags]
/// <summary>
/// Different ways that you can use a texture.
/// 
/// The usages determine what kind of memory the texture is allocated from and what actions the texture can partake in.
/// </summary>
public enum TextureUsage : ulong
{
    /// <summary>
    /// No flags set.
    /// </summary>
    None = 0,
    /// <summary>
    /// Allows a texture to be the source in a [CommandEncoder::copy_texture_to_buffer] or [CommandEncoder::copy_texture_to_texture] operation.
    /// </summary>
    CopySrc = 1,
    /// <summary>
    /// Allows a texture to be the destination in a [CommandEncoder::copy_buffer_to_texture], [CommandEncoder::copy_texture_to_texture], or [Queue::write_texture] operation.
    /// </summary>
    CopyDst = 2,
    /// <summary>
    /// Allows a texture to be a BindingType::Texture in a bind group.
    /// </summary>
    TextureBinding = 4,
    /// <summary>
    /// Allows a texture to be a BindingType::StorageTexture in a bind group.
    /// </summary>
    StorageBinding = 8,
    /// <summary>
    /// Allows a texture to be an output attachment of a render pass.
    /// </summary>
    RenderAttachment = 16,
    TransientAttachment = 32,
    StorageAttachment = 64,
}
