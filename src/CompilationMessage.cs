using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="CompilationMessageFFI" />
public unsafe readonly ref struct CompilationMessage
{
    private readonly ref readonly CompilationMessageFFI _compilationMessageFFI;

    internal CompilationMessage(ref readonly CompilationMessageFFI compilationMessageFFI)
    {
        _compilationMessageFFI = ref compilationMessageFFI;
    }

    /// <inheritdoc cref="CompilationMessageFFI.Message" />
    public ReadOnlySpan<byte> Message => _compilationMessageFFI.Message.AsSpan();
    /// <inheritdoc cref="CompilationMessageFFI.Type" />
    public CompilationMessageType Type => _compilationMessageFFI.Type;
    /// <inheritdoc cref="CompilationMessageFFI.LineNum" />
    public ulong LineNum => _compilationMessageFFI.LineNum;
    /// <inheritdoc cref="CompilationMessageFFI.LinePos" />
    public ulong LinePos => _compilationMessageFFI.LinePos;
    /// <inheritdoc cref="CompilationMessageFFI.Offset" />
    public ulong Offset => _compilationMessageFFI.Offset;
    /// <inheritdoc cref="CompilationMessageFFI.Length" />
    public ulong Length => _compilationMessageFFI.Length;
}