using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationInfoFFI
{
    public ChainedStruct* NextInChain;
    public nuint MessageCount;
    public CompilationMessageFFI* Messages;

    public CompilationInfoFFI()
    {
    }


    public CompilationInfoFFI(ChainedStruct* nextInChain = default, nuint messageCount = default, CompilationMessageFFI* messages = default)
    {
        this.NextInChain = nextInChain;
        this.MessageCount = messageCount;
        this.Messages = messages;
    }


    public CompilationInfoFFI(nuint messageCount = default, CompilationMessageFFI* messages = default)
    {
        this.MessageCount = messageCount;
        this.Messages = messages;
    }

}
