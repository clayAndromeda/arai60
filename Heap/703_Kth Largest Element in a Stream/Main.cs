public class KthLargest
{
    private readonly int _k;
    private readonly int[] _heap;
    private int _size;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _heap = new int[k];
        _size = 0;
        foreach (var num in nums)
        {
            Push(num);
        }
    }

    public int Add(int val)
    {
        Push(val);
        return _heap[0];
    }

    private void Push(int val)
    {
        if (_size < _k)
        {
            _heap[_size] = val;
            SiftUp(_size);
            _size++;
        }
        else if (_size > 0 && val > _heap[0])
        {
            // 最小値 (root) より大きいので、rootを置き換える
            _heap[0] = val;
            SiftDown(0);
        }
    }

    private void SiftUp(int i)
    {
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (_heap[i] >= _heap[parent]) break;
            (_heap[i], _heap[parent]) = (_heap[parent], _heap[i]);
            i = parent;
        }
    }

    private void SiftDown(int i)
    {
        while (true)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;
            if (left < _size && _heap[left] < _heap[smallest]) smallest = left;
            if (right < _size && _heap[right] < _heap[smallest]) smallest = right;

            if (smallest == i) break;

            (_heap[i], _heap[smallest]) = (_heap[smallest], _heap[i]);
            i = smallest;
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
