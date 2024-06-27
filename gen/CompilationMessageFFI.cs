using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationMessageFFI
{
    public ChainedStruct* NextInChain;
    public byte* Message;
    public CompilationMessageType Type;
    public ulong LineNum;
    public ulong LinePos;
    public ulong Offset;
    public ulong Length;
    public ulong Utf16LinePos;
    public ulong Utf16Offset;
    public ulong Utf16Length;

    public CompilationMessageFFI()
    {
    }


    public CompilationMessageFFI(ChainedStruct* nextInChain = default, byte* message = default, CompilationMessageType type = default, ulong lineNum = default, ulong linePos = default, ulong offset = default, ulong length = default, ulong utf16LinePos = default, ulong utf16Offset = default, ulong utf16Length = default)
    {
        this.NextInChain = nextInChain;
        this.Message = message;
        this.Type = type;
        this.LineNum = lineNum;
        this.LinePos = linePos;
        this.Offset = offset;
        this.Length = length;
        this.Utf16LinePos = utf16LinePos;
        this.Utf16Offset = utf16Offset;
        this.Utf16Length = utf16Length;
    }


    public CompilationMessageFFI(byte* message = default, CompilationMessageType type = default, ulong lineNum = default, ulong linePos = default, ulong offset = default, ulong length = default, ulong utf16LinePos = default, ulong utf16Offset = default, ulong utf16Length = default)
    {
        this.Message = message;
        this.Type = type;
        this.LineNum = lineNum;
        this.LinePos = linePos;
        this.Offset = offset;
        this.Length = length;
        this.Utf16LinePos = utf16LinePos;
        this.Utf16Offset = utf16Offset;
        this.Utf16Length = utf16Length;
    }

}
