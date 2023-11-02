using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe sealed class ColorTargetStateList :
    IList<ColorTargetState>,
    IReadOnlyList<ColorTargetState>,
    IWebGpuFFIConvertibleCollection<ColorTargetStateFFI>
{
    private const int DefaultCapacity = 4;
    private ColorTargetStateFFI[] _itemsColorTargetState;
    private BlendState[] _itemsBlendState;

    private int _size;
    private int _version = 0;
    private int? _lastMarshalVersion = 0;

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _size;
    }

    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _itemsColorTargetState.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "ArgumentOutOfRange_SmallCapacity");
            }

            if (value != _itemsColorTargetState.Length)
            {
                if (value > 0)
                {
                    var newItemsColorTargetState = GC.AllocateUninitializedArray<ColorTargetStateFFI>(value, pinned: true);
                    var newItemsBlendState = GC.AllocateUninitializedArray<BlendState>(value, pinned: true);

                    if (_size > 0)
                    {
                        Array.Copy(_itemsColorTargetState, newItemsColorTargetState, _size);
                        Array.Copy(_itemsBlendState, newItemsBlendState, _size);
                    }
                    _itemsColorTargetState = newItemsColorTargetState;
                    _itemsBlendState = newItemsBlendState;
                }
                else
                {
                    _itemsColorTargetState = Array.Empty<ColorTargetStateFFI>();
                    _itemsBlendState = Array.Empty<BlendState>();
                }
            }
        }
    }

    public bool IsReadOnly => false;


    public ColorTargetState this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            // Following trick can reduce the range check by one
            if ((uint)index >= (uint)Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            ref var colorTargetState = ref _itemsColorTargetState[index];

            return new ColorTargetState(
                format: colorTargetState.Format,
                blend: colorTargetState.Blend != null ? _itemsBlendState[index] : default,
                writeMask: colorTargetState.WriteMask
            );
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            // Following trick can reduce the range check by one
            if ((uint)index >= (uint)Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            _itemsColorTargetState[index] = new ColorTargetStateFFI(
                format: value.Format,
                blend: value.Blend.HasValue ? (BlendState*)1 : null,
                writeMask: value.WriteMask
            );

            if (value.Blend.HasValue)
            {
                _itemsBlendState[index] = Nullable.GetValueRefOrDefaultRef(value.Blend);
            }
            _version++;
        }
    }

    public ColorTargetStateList()
    {
        _itemsColorTargetState = GC.AllocateUninitializedArray<ColorTargetStateFFI>(DefaultCapacity, pinned: true);
        _itemsBlendState = GC.AllocateUninitializedArray<BlendState>(DefaultCapacity, pinned: true);
    }

    public ColorTargetStateList(int capacity)
    {
        _itemsColorTargetState = GC.AllocateUninitializedArray<ColorTargetStateFFI>(capacity, pinned: true);
        _itemsBlendState = GC.AllocateUninitializedArray<BlendState>(DefaultCapacity, pinned: true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(ColorTargetState value)
    {
        ColorTargetStateFFI colorTargetState = new ColorTargetStateFFI(
            format: value.Format,
            blend: null,
            writeMask: value.WriteMask
        );

        ref BlendState blendState = ref (value.Blend.HasValue ?
            ref Unsafe.AsRef(Nullable.GetValueRefOrDefaultRef(value.Blend)) :
            ref Unsafe.NullRef<BlendState>()
        );

        Add(ref colorTargetState, ref blendState);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Add(
        ref ColorTargetStateFFI colorTargetState,
        ref BlendState blendState)
    {
        _version++;
        ColorTargetStateFFI[] colorTargetStateArray = _itemsColorTargetState;
        BlendState[] blendStateArray = _itemsBlendState;

        int size = _size;
        if ((uint)size < (uint)colorTargetStateArray.Length)
        {
            _size = size + 1;
            if (Unsafe.IsNullRef(ref Unsafe.AsRef(blendState)))
            {
                blendStateArray[size] = default;
                colorTargetStateArray[size] = colorTargetState;
            }
            else
            {
                blendStateArray[size] = blendState;
                colorTargetState.Blend = (BlendState*)1;
                colorTargetStateArray[size] = colorTargetState;
            }

        }
        else
        {
            AddWithResize(ref colorTargetState, ref blendState);
        }
    }

    // Non-inline from List.Add to improve its code quality as uncommon path
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResize(
        ref ColorTargetStateFFI colorTargetState,
        ref BlendState blendState)
    {
        Debug.Assert(_size == _itemsColorTargetState.Length);

        int size = _size;
        Grow(size + 1);
        _size = size + 1;

        if (Unsafe.IsNullRef(ref Unsafe.AsRef(blendState)))
        {
            _itemsBlendState[size] = default;
            _itemsColorTargetState[size] = colorTargetState;
        }
        else
        {
            _itemsBlendState[size] = blendState;
            colorTargetState.Blend = (BlendState*)1;
            _itemsColorTargetState[size] = colorTargetState;
        }

    }

    private void Grow(int capacity)
    {
        Debug.Assert(_size < _itemsColorTargetState.Length);

        int length = _itemsColorTargetState.Length;
        int newCapacity = length == 0 ? DefaultCapacity : 2 * length;

        // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
        // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
        if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;

        // If the computed capacity is still less than specified, set to the original argument.
        // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
        if (newCapacity < capacity) newCapacity = capacity;

        Capacity = newCapacity;
    }

    // Removes the element at the given index. The size of the list is
    // decreased by one.
    public void RemoveAt(int index)
    {
        if ((uint)index >= (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        _size--;
        if (index < _size)
        {
            Array.Copy(_itemsColorTargetState, index + 1, _itemsColorTargetState, index, _size - index);
        }

        _version++;
    }

    // Removes a range of elements from this list.
    public void RemoveRange(int index, int count)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (_size - index < count)
        {
            throw new ArgumentException();
        }

        if (count > 0)
        {
            _size -= count;
            if (index < _size)
            {
                Array.Copy(_itemsColorTargetState, index + count, _itemsColorTargetState, index, _size - index);
            }

            _version++;
        }
    }

    // Clears the contents of List.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        _version++;
        _size = 0;
    }

    public int IndexOf(ColorTargetState item)
    {
        var item1 = item;
        var item2 = item;

        var length = _size;
        for (var i = 0; i < length; i++)
        {
            ref var colorTargetState = ref _itemsColorTargetState[i];
            if (colorTargetState.Format == item.Format &&
                colorTargetState.WriteMask == item.WriteMask)
            {
                if (item.Blend.HasValue && colorTargetState.Blend != null)
                {
                    if (EqualityComparer<BlendState>.Default.Equals(_itemsBlendState[i], item.Blend.Value))
                    {
                        return i;
                    }
                }
                else
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public void Insert(int index, ColorTargetState item)
    {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (_size == _itemsColorTargetState.Length) Grow(_size + 1);
        if (index < _size)
        {
            Array.Copy(_itemsColorTargetState, index, _itemsColorTargetState, index + 1, _size - index);
        }

        _itemsColorTargetState[index] = new ColorTargetStateFFI(
            format: item.Format,
            blend: item.Blend.HasValue ? (BlendState*)1 : null,
            writeMask: item.WriteMask
        );

        if (item.Blend.HasValue)
        {
            _itemsBlendState[index] = Nullable.GetValueRefOrDefaultRef(item.Blend);
        }

        _size++;
        _version++;
    }

    public bool Contains(ColorTargetState item)
    {
        return _size != 0 && IndexOf(item) >= 0;
    }

    public void CopyTo(ColorTargetState[] array, int arrayIndex)
    {
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        // Delegate rest of error checking to Array.Copy.
        Array.Copy(_itemsColorTargetState, 0, array, arrayIndex, _size);
    }

    public bool Remove(ColorTargetState item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    internal ColorTargetStateFFI* GetPointerToPinedArray()
    {
        if (_lastMarshalVersion.HasValue && _lastMarshalVersion.Value == _version)
        {
            return (ColorTargetStateFFI*)Unsafe.AsPointer(ref _itemsColorTargetState[0]);
        }

        var length = _size;
        for (int i = 0; i < length; i++)
        {
            ref var colorTargetState = ref _itemsColorTargetState[i];
            if (colorTargetState.Blend != null)
            {
                colorTargetState.Blend = (BlendState*)Unsafe.AsPointer(ref _itemsBlendState[i]);
            }
        }

        _lastMarshalVersion = _version;

        return (ColorTargetStateFFI*)Unsafe.AsPointer(ref _itemsColorTargetState[0]);
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<ColorTargetState> IEnumerable<ColorTargetState>.GetEnumerator()
    {
        return new Enumerator(this);
    }

    void IWebGpuFFIConvertibleCollection<ColorTargetStateFFI>.UnsafeConvertToFFI(
        out ColorTargetStateFFI* dest, out nuint outCount)
    {
        dest = GetPointerToPinedArray();
        outCount = (nuint)_size;
    }


    void IWebGpuFFIConvertibleCollectionAlloc<ColorTargetStateFFI>.UnsafeConvertToFFI(
        WebGpuAllocatorHandle allocator, out ColorTargetStateFFI* dest, out nuint outCount)
    {
        dest = GetPointerToPinedArray();
        outCount = (nuint)_size;
    }

    public struct Enumerator : IEnumerator<ColorTargetState>, IEnumerator
    {
        private readonly ColorTargetStateList _list;
        private int _index;
        private readonly int _version;
        private ColorTargetState _current;

        internal Enumerator(ColorTargetStateList list)
        {
            _list = list;
            _index = 0;
            _version = list._version;
            _current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ColorTargetStateList localList = _list;

            if (_version == localList._version && ((uint)_index < (uint)localList._size))
            {
                _current = localList[_index];
                _index++;
                return true;
            }
            return MoveNextRare();
        }

        private bool MoveNextRare()
        {
            if (_version != _list._version)
            {
                throw new InvalidOperationException();
            }

            _index = _list._size + 1;
            _current = default;
            return false;
        }

        public ColorTargetState Current => _current!;

        object? IEnumerator.Current
        {
            get
            {
                if (_index == 0 || _index == _list._size + 1)
                {
                    throw new InvalidOperationException();
                }
                return Current;
            }
        }

        void IEnumerator.Reset()
        {
            if (_version != _list._version)
            {
                throw new InvalidOperationException();
            }

            _index = 0;
            _current = default;
        }
    }
}