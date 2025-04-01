using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

public unsafe class PinnedList<T> : IList<T>, IReadOnlyList<T>
    where T : unmanaged
{
    private const int DefaultCapacity = 4;
    private T[] _items;
    private int _size;
    private int _version = 0;

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _size;
    }

    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _items.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "ArgumentOutOfRange_SmallCapacity");
            }

            if (value != _items.Length)
            {
                if (value > 0)
                {
                    T[] newUnmanagedItems = GC.AllocateUninitializedArray<T>(value, pinned: true);
                    if (_size > 0)
                    {
                        Array.Copy(_items, newUnmanagedItems, _size);
                    }
                    _items = newUnmanagedItems;
                }
                else
                {
                    _items = [];
                }
            }
        }
    }

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            // Following trick can reduce the range check by one
            if ((uint)index >= (uint)Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            return _items[index];
        }
        set
        {
            // Following trick can reduce the range check by one
            if ((uint)index >= (uint)Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            _items[index] = value;
            _version++;
        }
    }

    protected PinnedList()
    {
        _items = GC.AllocateUninitializedArray<T>(DefaultCapacity, pinned: true);
    }

    protected PinnedList(int capacity)
    {
        _items = GC.AllocateUninitializedArray<T>(capacity, pinned: true);
    }

    protected PinnedList(ReadOnlySpan<T> items)
    {
        _items = GC.AllocateUninitializedArray<T>(items.Length, pinned: true);
        _size = items.Length;
        items.CopyTo(_items);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(T value)
    {
        _version++;
        T[] unmanagedArray = _items;

        int size = _size;
        if ((uint)size < (uint)unmanagedArray.Length)
        {
            _size = size + 1;
            unmanagedArray[size] = value;
        }
        else
        {
            AddWithResize(value);
        }
    }

    // Non-inline from List.Add to improve its code quality as uncommon path
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResize(in T value)
    {
        Debug.Assert(_size == _items.Length);

        int size = _size;
        Grow(size + 1);
        _size = size + 1;
        _items[_size] = value;
    }

    private void Grow(int capacity)
    {
        Debug.Assert(_size < _items.Length);

        int length = _items.Length;
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
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        _version++;
    }

    // Removes a range of elements from this list.
    public void RemoveRange(int index, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (_size - index < count)
        {
            throw new ArgumentException();
        }

        if (count > 0)
        {
            _size -= count;
            if (index < _size)
            {
                Array.Copy(_items, index + count, _items, index, _size - index);
            }

            _version++;
        }
    }

    public void Insert(int index, in T item)
    {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int length = _items.Length;
        if (_size == length) Grow(_size + 1);
        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }
        _items[index] = item;

        _size++;
        _version++;
    }

    // Clears the contents of List.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        _version++;
        _size = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected int GetVersion() => _version;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void IncrementVersion()
    {
        _version++;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item, 0, _size);
    }

    public void Insert(int index, T item)
    {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (_size == _items.Length) Grow(_size + 1);
        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }
        _items[index] = item;
        _size++;
        _version++;
    }

    public bool Contains(T item)
    {
        return _size != 0 && IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        // Delegate rest of error checking to Array.Copy.
        Array.Copy(_items, 0, array, arrayIndex, _size);
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T* GetPointerToPinedArray()
    {
        return _size > 0 ? (T*)Unsafe.AsPointer(ref _items[0]) : null;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new Enumerator(this);
    }

    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        private readonly PinnedList<T> _list;
        private int _index;
        private readonly int _version;
        private T _current;

        internal Enumerator(PinnedList<T> list)
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
            PinnedList<T> localList = _list;

            if (_version == localList._version && (uint)_index < (uint)localList._size)
            {
                _current = localList._items[_index];
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

        public T Current => _current!;

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
            if (_version != _list.GetVersion())
            {
                throw new InvalidOperationException();
            }

            _index = 0;
            _current = default;
        }
    }
}