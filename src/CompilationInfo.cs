using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe readonly ref partial struct CompilationInfo
{
    private readonly ref readonly CompilationInfoFFI _compilationInfoFFI;

    internal CompilationInfo(ref readonly CompilationInfoFFI compilationInfoFFI)
    {
        _compilationInfoFFI = ref compilationInfoFFI;
    }


    public nuint MessageCount => _compilationInfoFFI.MessageCount;
    public CompilationMessage this[nuint index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, MessageCount);
            return new(in _compilationInfoFFI.Messages[index]);
        }
    }

    public CompilationMessage this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, (int)MessageCount);
            return new(in _compilationInfoFFI.Messages[index]);
        }
    }

    public unsafe ref struct Enumerator
    {
        private readonly ref readonly CompilationInfoFFI _compilationInfoFFI;
        private readonly int _length;
        private int _index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(ref readonly CompilationInfoFFI compilationInfoFFI)
        {
            _compilationInfoFFI = ref compilationInfoFFI;
            _length = (int)compilationInfoFFI.MessageCount;
            _index = -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            int index = _index + 1;
            if (index < _length)
            {
                _index = index;
                return true;
            }

            return false;
        }

        public CompilationMessage Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(in _compilationInfoFFI.Messages[_index]);
        }
    }

    public Enumerator GetEnumerator() => new(in this._compilationInfoFFI);
}