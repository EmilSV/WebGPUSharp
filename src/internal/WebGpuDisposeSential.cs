using System.Collections.Concurrent;

namespace WebGpuSharp.Internal;

internal class WebGpuDisposeSentinel
{
    private static ConcurrentStack<WebGpuDisposeSentinel> _stack = new();

    private int _callerLineNumber;
    private string? _callerFilePath;

    private WebGpuDisposeSentinel()
    {

    }

    public static WebGpuDisposeSentinel Get(string callerFilePath = "", int callerLineNumber = 0)
    {
        if (_stack.TryPop(out var existingSentinel))
        {
            existingSentinel._callerLineNumber = callerLineNumber;
            existingSentinel._callerFilePath = callerFilePath;
            return existingSentinel;
        }
        else
        {
            return new WebGpuDisposeSentinel
            {
                _callerLineNumber = callerLineNumber,
                _callerFilePath = callerFilePath
            };
        }
    }

    public void Return()
    {
        _callerLineNumber = 0;
        _callerFilePath = null;
        _stack.Push(this);
    }

    ~WebGpuDisposeSentinel()
    {
        Console.WriteLine($"WebGpuDisposeSentinel was not disposed at: {_callerFilePath}:{_callerLineNumber}");
    }
}
