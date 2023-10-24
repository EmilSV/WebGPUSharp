using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

[DebuggerDisplay("Count = {Count}")]
public abstract class BaseFFIList<TMarshal, TManaged, TFFI, TCache> :
    IList<TManaged>,
    IReadOnlyList<TManaged>,
    IUnsafeMarshalCollectionAlloc<TFFI>
    where TMarshal : IWebGPUMarshal<TManaged, TFFI, TCache>
    where TFFI : unmanaged
    where TCache : struct
{
    private const int DefaultCapacity = 4;
    private TFFI[]? _ffiCacheItems;
    private TCache[]? _cacheItems;
    private TManaged[] _managedItems;
    private int _size;
    private int? _lastMarshalVersion = 0;
    private int _version = 0;
    public readonly FFIMemoryType FFIMemory = FFIMemoryType.Unknown;

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _size;
    }

    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _managedItems.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "ArgumentOutOfRange_SmallCapacity");
            }

            if (value != _managedItems.Length)
            {
                if (value > 0)
                {
                    TManaged[] newManagedItems = new TManaged[value];
                    TCache[]? newCacheItems = TMarshal.NeedsCache() ? new TCache[value] : null;
                    TFFI[]? newFFI_Items = _ffiCacheItems != null ? GC.AllocateUninitializedArray<TFFI>(value, pinned: true) : null;

                    if (_size > 0)
                    {
                        Array.Copy(_managedItems, newManagedItems, _size);
                        if (_ffiCacheItems != null)
                        {
                            Array.Copy(_ffiCacheItems, newFFI_Items!, _size);
                        }
                        if (TMarshal.NeedsCache())
                        {
                            Array.Copy(_cacheItems!, newCacheItems!, _size);
                        }
                    }

                    _managedItems = newManagedItems;
                    _cacheItems = newCacheItems;
                    _ffiCacheItems = newFFI_Items;
                }
                else
                {
                    if (_ffiCacheItems != null)
                    {
                        _ffiCacheItems = Array.Empty<TFFI>();
                    }
                    if (_cacheItems != null)
                    {
                        _cacheItems = Array.Empty<TCache>();
                    }

                    _managedItems = Array.Empty<TManaged>();
                }
            }
        }
    }

    private bool HasCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => TMarshal.NeedsCache() && _cacheItems != null;
    }

    private bool HasFFICacheItems
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _ffiCacheItems != null;
    }


    internal BaseFFIList() : this(FFIMemoryType.Default)
    {
    }

    internal BaseFFIList(FFIMemoryType ffiMemory) : this(0, ffiMemory)
    {
    }

    internal BaseFFIList(int capacity, FFIMemoryType ffiMemory)
    {
        if (capacity < 0)
        {
            throw new ArgumentException(null, nameof(capacity));
        }

        switch (ffiMemory)
        {
            case FFIMemoryType.Unknown:
            case FFIMemoryType.Default:
            case FFIMemoryType.Cached:
                FFIMemory = FFIMemoryType.Cached;
                _ffiCacheItems = capacity != 0 ?
                    GC.AllocateUninitializedArray<TFFI>(capacity, pinned: true) :
                    Array.Empty<TFFI>();
                break;
            case FFIMemoryType.Temporary:
                FFIMemory = FFIMemoryType.Temporary;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(ffiMemory), ffiMemory, "ArgumentOutOfRangeException");
        }

        if (TMarshal.NeedsCache() && _ffiCacheItems != null)
        {
            _cacheItems = capacity != 0 ? new TCache[capacity] : Array.Empty<TCache>();
        }

        _managedItems = capacity != 0 ? new TManaged[capacity] : Array.Empty<TManaged>();
    }

    internal BaseFFIList(IEnumerable<TManaged> collection, FFIMemoryType ffiMemory = FFIMemoryType.Default)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        bool useFFI_Items;
        switch (ffiMemory)
        {
            case FFIMemoryType.Unknown:
            case FFIMemoryType.Default:
            case FFIMemoryType.Cached:
                FFIMemory = FFIMemoryType.Cached;
                useFFI_Items = true;
                break;
            case FFIMemoryType.Temporary:
                FFIMemory = FFIMemoryType.Temporary;
                useFFI_Items = false;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(ffiMemory), ffiMemory, "ArgumentOutOfRangeException");
        }

        if (collection is ICollection<TManaged> c)
        {
            int count = c.Count;
            if (count == 0)
            {
                _managedItems = Array.Empty<TManaged>();
                _cacheItems = TMarshal.NeedsCache() && useFFI_Items ? Array.Empty<TCache>() : null;
                _ffiCacheItems = useFFI_Items ? Array.Empty<TFFI>() : null;
            }
            else
            {
                if (useFFI_Items)
                {
                    _ffiCacheItems = GC.AllocateUninitializedArray<TFFI>(count, pinned: true);
                }
                _cacheItems = TMarshal.NeedsCache() && useFFI_Items ? new TCache[count] : null;

                _managedItems = new TManaged[count];
                c.CopyTo(_managedItems, 0);
                _size = count;
            }
        }
        else
        {
            if (useFFI_Items)
            {
                _ffiCacheItems = Array.Empty<TFFI>();
            }
            _cacheItems = TMarshal.NeedsCache() && useFFI_Items ? Array.Empty<TCache>() : null;
            _managedItems = Array.Empty<TManaged>();
            using IEnumerator<TManaged> en = collection!.GetEnumerator();
            while (en.MoveNext())
            {
                Add(en.Current);
            }
        }
    }

    private void Grow(int capacity)
    {
        Debug.Assert(_ffiCacheItems == null || _size < _ffiCacheItems.Length);
        Debug.Assert(_size < _managedItems.Length);

        int length = _managedItems.Length;
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
            if (_ffiCacheItems != null)
            {
                Array.Copy(_ffiCacheItems, index + 1, _ffiCacheItems, index, _size - index);
            }
            if (TMarshal.NeedsCache())
            {
                Array.Copy(_cacheItems!, index + 1, _cacheItems!, index, _size - index);
            }
            Array.Copy(_managedItems, index + 1, _managedItems, index, _size - index);
        }

        if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
        {
            _managedItems[_size] = default!;
        }
        if (RuntimeHelpers.IsReferenceOrContainsReferences<TCache>() && HasCache)
        {
            _cacheItems![_size] = default!;
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
                if (HasFFICacheItems)
                {
                    Array.Copy(_ffiCacheItems!, index + count, _ffiCacheItems!, index, _size - index);
                }
                if (HasCache)
                {
                    Array.Copy(_cacheItems!, index + count, _cacheItems!, index, _size - index);
                }
                Array.Copy(_managedItems, index + count, _managedItems, index, _size - index);
            }

            _version++;
            if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
            {
                Array.Clear(_managedItems, _size, count);
            }
        }
    }

    // Clears the contents of List.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        _version++;
        int originalSize = _size;

        if (RuntimeHelpers.IsReferenceOrContainsReferences<TManaged>())
        {
            if (originalSize > 0)
            {
                Array.Clear(_managedItems, 0, originalSize); // Clear the elements so that the gc can reclaim the references.
            }
        }
        if (RuntimeHelpers.IsReferenceOrContainsReferences<TCache>() && HasCache)
        {
            Array.Clear(_cacheItems!, 0, originalSize); // Clear the elements so that the gc can reclaim the references.
        }

        _size = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetVersion() => _version;

    public int IndexOf(TManaged item, int index)
    {
        if (index > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return Array.IndexOf(_managedItems, item, index, _size - index);
    }

    public void Insert(int index, TManaged item)
    {
        // Note that insertions at the end are legal.
        if ((uint)index > (uint)_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int length = _managedItems.Length;
        if (_size == length) Grow(_size + 1);
        if (index < _size)
        {
            if (_ffiCacheItems != null)
            {
                Array.Copy(_ffiCacheItems, index, _ffiCacheItems, index + 1, _size - index);
            }

            if (TMarshal.NeedsCache())
            {
                Array.Copy(_cacheItems!, index, _cacheItems!, index + 1, _size - index);
            }

            Array.Copy(_managedItems, index, _managedItems, index + 1, _size - index);
        }
        _managedItems[index] = item;
        if (HasCache)
        {
            _ffiCacheItems![index] = default;
        }

        _size++;
        _version++;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(TManaged item)
    {
        _version++;
        TManaged[] managedArray = _managedItems;

        int size = _size;
        if ((uint)size < (uint)managedArray.Length)
        {
            _size = size + 1;
            managedArray[size] = item;
            if (HasCache)
            {
                _ffiCacheItems![size] = default;
            }
        }
        else
        {
            AddWithResize(item);
        }
    }

    // Non-inline from List.Add to improve its code quality as uncommon path
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResize(TManaged item)
    {
        Debug.Assert(_ffiCacheItems == null || _size < _ffiCacheItems.Length);
        Debug.Assert(_size == _managedItems.Length);

        int size = _size;
        Grow(size + 1);
        _size = size + 1;
        _managedItems[_size] = item;
        if (HasCache)
        {
            _ffiCacheItems![size] = default;
        }
    }


    public bool Contains(TManaged item)
    {
        return _size != 0 && IndexOf(item) >= 0;
    }

    public void CopyTo(TManaged[] array) => CopyTo(array, 0);
    public void CopyTo(TManaged[] array, int arrayIndex)
    {
        Array.Copy(_managedItems, 0, array, arrayIndex, _size);
    }

    public bool Remove(TManaged item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<TManaged> IEnumerable<TManaged>.GetEnumerator()
    {
        return new Enumerator(this);
    }

    public int IndexOf(TManaged item) => Array.IndexOf(_managedItems, item, 0, _size);

    protected Span<TFFI> FFI_Items
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _ffiCacheItems;
    }

    protected Span<TManaged> ManagedItems
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _managedItems;
    }

    public bool IsReadOnly => false;

    public TManaged this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _managedItems[index];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (HasFFICacheItems)
            {
                if (TMarshal.NeedsCache())
                {
                    TMarshal.MarkDirty(ref value, _managedItems[index], ref _cacheItems![index]);
                }
                else
                {
                    TMarshal.MarkDirty(ref value, _managedItems[index]);
                }
            }

            _managedItems[index] = value;
            _version++;
        }
    }

    internal unsafe TFFI* GetPointerToFFIItems(WebGpuAllocatorHandle allocator)
    {
        if (_ffiCacheItems != null && _lastMarshalVersion.HasValue && _lastMarshalVersion.Value == _version)
        {
            return (TFFI*)Unsafe.AsPointer(ref _ffiCacheItems[0]);
        }

        switch (FFIMemory)
        {
            case FFIMemoryType.Cached:
                UpdateFFICache();
                return (TFFI*)Unsafe.AsPointer(ref _ffiCacheItems![0]);
            case FFIMemoryType.Temporary:
                return GetPointerToFFIItemsTemporary(allocator);
            default:
                throw new InvalidOperationException();
        }
    }

    private void UpdateFFICache()
    {
        Debug.Assert(_ffiCacheItems != null);
        if (_lastMarshalVersion.HasValue && _lastMarshalVersion.Value == _version)
        {
            return;
        }

        if (HasCache)
        {
            TMarshal.MarshalTo(_managedItems.AsSpan(0, _size), _ffiCacheItems.AsSpan(0, _size), _cacheItems!.AsSpan(0, _size));
        }
        else
        {
            TMarshal.MarshalTo(_managedItems.AsSpan(0, _size), _ffiCacheItems.AsSpan(0, _size));
        }

        _lastMarshalVersion = _version;
    }

    private unsafe TFFI* GetPointerToFFIItemsTemporary(WebGpuAllocatorHandle allocator)
    {
        int size = _size;
        TFFI* outPointer = allocator.Alloc<TFFI>((nuint)size);
        TMarshal.MarshalTemporaryTo(_managedItems.AsSpan(0, size), new Span<TFFI>(outPointer, size), allocator);
        return outPointer;
    }

    unsafe void IUnsafeMarshalCollectionAlloc<TFFI>.GetPointerToFFIItems(
        WebGpuAllocatorHandle allocator, out TFFI* dest, out nuint outCount)
    {
        dest = GetPointerToFFIItems(allocator);
        outCount = (nuint)_size;
    }

    unsafe void IUnsafeMarshalCollectionAlloc<TFFI>.GetPointerToFFIItems(
        WebGpuAllocatorHandle allocator, out TFFI* dest, out uint outCount)
    {
        dest = GetPointerToFFIItems(allocator);
        outCount = (uint)_size;
    }

    public struct Enumerator : IEnumerator<TManaged>, IEnumerator
    {
        private readonly BaseFFIList<TMarshal, TManaged, TFFI, TCache> _list;
        private int _index;
        private readonly int _version;
        private TManaged? _current;

        internal Enumerator(BaseFFIList<TMarshal, TManaged, TFFI, TCache> list)
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
            BaseFFIList<TMarshal, TManaged, TFFI, TCache> localList = _list;

            if (_version == localList._version && ((uint)_index < (uint)localList._size))
            {
                _current = localList._managedItems[_index];
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

        public readonly TManaged Current => _current!;

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