using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe readonly ref struct CompilationMessage
{
    private readonly ref readonly CompilationMessageFFI _compilationMessageFFI;
    
    internal CompilationMessage(ref readonly CompilationMessageFFI compilationMessageFFI)
    {
        _compilationMessageFFI = ref compilationMessageFFI;
    }
    
    public ReadOnlySpan<byte> GetMessage()
    {
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(_compilationMessageFFI.Message);
    }

    public CompilationMessageType Type => _compilationMessageFFI.Type;
    public ulong LineNum => _compilationMessageFFI.LineNum;
    public ulong LinePos => _compilationMessageFFI.LinePos;
    public ulong Offset => _compilationMessageFFI.Offset;
    public ulong Length => _compilationMessageFFI.Length;
    public ulong Utf16LinePos => _compilationMessageFFI.Utf16LinePos;
    public ulong Utf16Offset => _compilationMessageFFI.Utf16Offset;
    public ulong Utf16Length => _compilationMessageFFI.Utf16Length;
}