public class KthLargest
{
    private int _k;
    private int[] _nodes;
    private int _size;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _nodes = new int[k];
        _size = 0;
        foreach (int num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        if (_size < _k)
        {
            _nodes[_size] = val;
            SiftUp();
            _size++;
        }
        else if (_nodes[0] < val)
        {
            _nodes[0] = val;
            SiftDown();
        }
        return _nodes[0];
    }

    private void SiftUp()
    {
        int nodeIndex = _size;
        while (nodeIndex > 0)
        {
            int parentIndex = (nodeIndex - 1) / 2;
            if (_nodes[parentIndex] <= _nodes[nodeIndex])
            {
                return;
            }
            (_nodes[parentIndex], _nodes[nodeIndex]) = (_nodes[nodeIndex], _nodes[parentIndex]);
            nodeIndex = parentIndex;
        }
    }

    private void SiftDown()
    {
        int nodeIndex = 0;
        while (nodeIndex < _size)
        {
            int leftIndex = nodeIndex * 2 + 1;
            int rightIndex = nodeIndex * 2 + 2;

            int minIndex = nodeIndex;
            if (leftIndex < _size && _nodes[leftIndex] < _nodes[minIndex])
            {
                minIndex = leftIndex;
            }
            if (rightIndex < _size && _nodes[rightIndex] < _nodes[minIndex])
            {
                minIndex = rightIndex;
            }
            if (minIndex == nodeIndex)
            {
                return;
            }

            (_nodes[minIndex], _nodes[nodeIndex]) = (_nodes[nodeIndex], _nodes[minIndex]);
            nodeIndex = minIndex;
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
