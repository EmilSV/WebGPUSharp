using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationMessageFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Message;
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

}
