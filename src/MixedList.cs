using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

public abstract class MixedList<TUnmanaged, TManaged>
    where TUnmanaged : unmanaged
{
    private const int DefaultCapacity = 4;
    private TUnmanaged[] _unmanagedItems;
    private TManaged[] _managedItems;
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
        get => _unmanagedItems.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "ArgumentOutOfRange_SmallCapacity");
            }

            if (value != _unmanagedItems.Length)
            {
                if (value > 0)
                {
                    TUnmanaged[] newUnmanagedItems = GC.AllocateUninitializedArray<TUnmanaged>(value, pinned: true);
                    TManaged[] newManagedItems = new TManaged[value];
                    if (_size > 0)
                    {
                        Array.Copy(_unmanagedItems, newUnmanagedItems, _size);
                        Array.Copy(_managedItems, newManagedItems, _size);
                    }
                    _unmanagedItems = newUnmanagedItems;
                    _managedItems = newManagedItems;
                }
                else
                {
                    _unmanagedItems = Array.Empty<TUnmanaged>();
                    _managedItems = Array.Empty<TManaged>();
                }
            }
        }
    }

    protected MixedList(int capacity = DefaultCapacity)
    {
        _unmanagedItems = GC.AllocateUninitializedArray<TUnmanaged>(capacity, pinned: true);
        _managedItems = new TManaged[capacity];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void Add(in TUnmanaged unmanagedValue, in TManaged managedValue)
    {
        _version++;
        TUnmanaged[] unmanagedArray = _unmanagedItems;
        TManaged[] managedArray = _managedItems;

        int size = _size;
        if ((uint)size < (uint)unmanagedArray.Length)
        {
            _size = size + 1;
            unmanagedArray[size] = unmanagedValue;
            managedArray[size] = managedValue;
        }
        else
        {
            AddWithResize(unmanagedValue, managedValue);
        }
    }

    // Non-inline from List.Add to improve its code quality as uncommon path
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResize(in TUnmanaged unmanagedValue, in TManaged managedValue)
    {
        Debug.Assert(_size == _unmanagedItems.Length);
        Debug.Assert(_size == _managedItems.Length);

        int size = _size;
        Grow(size + 1);
        _size = size + 1;
        _unmanagedItems[_size] = unmanagedValue;
        _managedItems[_size] = managedValue;
    }

    private void Grow(int capacity)
    {
        Debug.Assert(_size < _unmanagedItems.Length);
        Debug.Assert(_size < _managedItems.Length);

        int length = _unmanagedItems.Length;
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
            Array.Copy(_unmanagedItems, index + 1, _unmanagedItems, index, _size - index);
            Array.Copy(_managedItems, index + 1, _managedItems, index, _size - index);
        }

        if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
        {
            _managedItems[_size] = default!;
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
                Array.Copy(_unmanagedItems, index + count, _unmanagedItems, index, _size - index);
                Array.Copy(_managedItems, index + count, _managedItems, index, _size - index);
            }

            _version++;
            if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
            {
                Array.Clear(_managedItems, _size, count);
            }
        }
    }

    protected void Insert(int index, in TUnmanaged unmanagedItem, in TManaged managedItem)
    {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int length = _unmanagedItems.Length;
        if (_size == length) Grow(_size + 1);
        if (index < _size)
        {
            Array.Copy(_unmanagedItems, index, _unmanagedItems, index + 1, _size - index);
            Array.Copy(_managedItems, index, _managedItems, index + 1, _size - index);
        }
        _unmanagedItems[index] = unmanagedItem;
        _managedItems[index] = managedItem;

        _size++;
        _version++;
    }

    // Clears the contents of List.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        _version++;
        if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
        {
            int size = _size;
            _size = 0;
            if (size > 0)
            {
                Array.Clear(_managedItems, 0, size); // Clear the elements so that the gc can reclaim the references.
            }
        }
        else
        {
            _size = 0;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected int GetVersion() => _version;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected void IncrementVersion()
    {
        _version++;
    }

    protected Span<TUnmanaged> UnmanagedItems
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _unmanagedItems;
    }

    protected Span<TManaged> ManagedItems
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _managedItems;
    }
}