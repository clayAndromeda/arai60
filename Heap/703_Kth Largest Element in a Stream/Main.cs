public class KthLargest
{
    private int _k;
    private int[] _heap;
    private int _size;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _heap = new int[_k];
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
            SiftUp();
            _size++;
        }
        else if (_size > 0 && val > _heap[0])
        {
            _heap[0] = val;
            SiftDown();
        }
    }

    private void SiftUp()
    {
        int current = _size;
        while (current > 0)
        {
            int parent = (current - 1) / 2;
            if (_heap[current] >= _heap[parent])
            {
                return;
            }
            (_heap[current], _heap[parent]) = (_heap[parent], _heap[current]);
            current = parent;
        }
    }

    private void SiftDown()
    {
        int current = 0;
        while (true)
        {
            int left = 2 * current + 1;
            int right = 2 * current + 2;
            int smallest = current;
            if (left < _size && _heap[left] < _heap[smallest]) smallest = left;
            if (right < _size && _heap[right] < _heap[smallest]) smallest = right;

            if (smallest == current) break;
            (_heap[current], _heap[smallest]) = (_heap[smallest], _heap[current]);
            current = smallest;
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
