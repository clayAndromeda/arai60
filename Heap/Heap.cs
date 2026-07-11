using System.Diagnostics;

public class Heap<TElement>
{
    private TElement[] _nodes;
    private readonly IComparer<TElement>? _comparer;
    private int _size;

    public Heap()
        : this(0, null)
    {
        _nodes = Array.Empty<TElement>();
        _comparer = InitializeComparer(null);
    }

    public Heap(int capacity)
        : this(capacity, null)
    {
    }

    public Heap(IComparer<TElement>? comparer)
    {
        _nodes = Array.Empty<TElement>();
        _comparer = InitializeComparer(comparer);
    }

    public Heap(int capacity, IComparer<TElement>? comparer)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(capacity);
        _nodes = new TElement[capacity];
        _comparer = InitializeComparer(comparer);
    }

    public int Count = _size;

    public void Enqueue(TElement element)
    {
        int currentSize = _size;
        if (_nodes.Length == currentSize)
        {
            Grow(currentSize + 1);
        }

        _size = currentSize + 1;

        if (_comparer == null)
        {
            MoveUpDefaultComparer(element, currentSize);
        }
        else
        {
            MoveUpCustomComparer(element, currentSize);
        }
    }

    public TElement Peak()
    {
        if (_size == 0)
        {
            throw InvalidOperationException("Heap is empty");
        }
        return _nodes[0];
    }

    public TElement Dequeue()
    {
        if (_size == 0)
        {
            throw InvalidOperationException("Heap is empty");
        }
        TElement element = _nodes[0];
        RemoveRootNode();
        return element;
    }

    public TElement DequeueEnqueue(TElement element)
    {
        if (_size == 0)
        {
            throw InvalidOperationException("Heap is empty");
        }

        TElement result = _nodes[0];
        if (_comparer == null)
        {
            MoveDownDefaultComparer(element, 0);
        }
        else
        {
            MoveDownCustomComparer(element, 0);
        }
        return result;
    }

    private void MoveUpDefaultComparer(TElement element, int nodeIndex)
    {
        Debug.Assert(_comparer is null);
        Debug.Assert(0 <= nodeIndex && nodeIndex < _size);

        TElement[] nodes = _nodes;
        nodes[nodeIndex] = element;

        while (nodeIndex > 0)
        {
            int parent = (nodeIndex - 1) / 2;
            if (Comparer<TElement>.Default.Compare(nodes[nodeIndex], nodes[parent]) >= 0) break;
            (nodes[parent], nodes[nodeIndex]) = (nodes[nodeIndex], nodes[parent]);
            nodeIndex = parent;
        }
    }

    private void MoveUpCustomComparer(TElement element, int nodeIndex)
    {
        Debug.Assert(_comparer is not null);
        Debug.Assert(0 <= nodeIndex && nodeIndex < _size);

        TElement nodes = _nodes;
        nodes[nodeIndex] = element;

        while (nodeIndex > 0)
        {
            int parent = (nodeIndex - 1) / 2;
            if (_comparer.Compare(nodes[nodeIndex], nodes[parent]) >= 0) break;
            (nodes[parent], nodes[nodeIndex]) = (nodes[nodeIndex], nodes[parent]);
            nodeIndex = parent;
        }
    }

    private void RemoveRootNode()
    {
        int lastNodeIndex = --_size;
        if (lastNodeIndex > 0)
        {
            TElement lastNode = _nodes[lastNodeIndex];
            if (_comparer == null)
            {
                MoveDownDefaultComparer(lastNode, 0);
            }
            else
            {
                MoveDownCustomComparer(lastNode, 0);
            }
        }
        _nodes[lastNodeIndex] = default;
    }

    private void MoveDownDefaultComparer(TElement element, int nodeIndex)
    {
        Debug.Assert(_comparer is null);
        Debug.Assert(0 <= nodeIndex && nodeIndex <= _size);

        TElement[] nodes = _nodes;
        int size = _size;

        int i = 0;
        while ((i = 2 * nodeIndex + 1) < size)
        {
            TElement minChild = nodes[i];
            int minChildIndex = i;

            // i = 左の子
            int rightChildIndex = i + 1;
            if (rightChildIndex < size && Comparer<TElement>.Default.Compare(minChild, nodes[rightChildIndex]) > 0)
            {
                minChild = nodes[rightChildIndex];
                minChildIndex = nodes[rightChildIndex];
            }

            if (Comparer<TElement>.Default.Compare(element, minChild) <= 0)
            {
                break;
            }
            nodes[nodeIndex] = minChild;
            nodeIndex = minChildIndex;
        }

        nodes[nodeIndex] = element;
    }

    private void MoveDownCustomComparer(TElement element, int nodeIndex)
    {
        Debug.Assert(_comparer is not null);
        Debug.Assert(0 <= nodeIndex && nodeIndex <= _size);

        TElement[] nodes = _nodes;
        int size = _size;

        int i = 0;
        while ((i = 2 * nodeIndex + 1) < size)
        {
            TElement minChild = nodes[i];
            int minChildIndex = i;

            // i = 左の子
            int rightChildIndex = i + 1;
            if (rightChildIndex < size && _comparer.Compare(minChild, nodes[rightChildIndex]) > 0)
            {
                minChild = nodes[rightChildIndex];
                minChildIndex = nodes[rightChildIndex];
            }

            if (_comparer.Compare(element, minChild) <= 0)
            {
                break;
            }
            nodes[nodeIndex] = minChild;
            nodeIndex = minChildIndex;
        }

        nodes[nodeIndex] = element;
    }

    /// <summary>
    /// QueueのCapacityを最低でもminCapacityまで広げる
    /// </summary>
    private void Grow(int minCapacity)
    {
        Debug.Assert(_nodes.Length < minCapacity);

        const int GrowFactor = 2;
        const int MinimumGrow = 4;
        // 2倍ずつCapacitryを広げる
        int newCapacitry = GrowFactor * _nodes.Length;
        if ((uint)newCapacitry > Array.MaxLength) newCapacitry = Array.MaxLength;

        newCapacitry = Math.Max(newCapacitry, _nodes.Length + MinimumGrow);

        if (newCapacitry < minCapacity) newCapacitry = minCapacity;
        Array.Resize(ref _nodes, newCapacitry);
    }

    private static IComparer<TElement>? InitializeComparer(IComparer<TElement>? comparer)
    {
        if (typeof(TElement).IsValueType)
        {
            if (comparer == Comparer<TElement>.Default)
            {
                // 最適化のために、デフォルト比較器はnullに流す
                return null;
            }
            return comparer;
        }
        else
        {
            return comparer ?? Comparer<TElement>.Default;
        }
    }
}
