using System.Runtime.InteropServices;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = new();
        foreach (int num in nums)
        {
            ref int freq = ref CollectionsMarshal.GetValueRefOrAddDefault(dict, num, out _);
            freq++;
        }

        PriorityQueue<int, int> priorityQueue = new(k + 1);
        foreach (var (num, freq) in dict)
        {
            priorityQueue.Enqueue(num, freq);
            if (priorityQueue.Count > k)
            {
                priorityQueue.Dequeue();
            }
        }

        return priorityQueue.UnorderedItems.Select(x => x.Element).ToArray();
    }
}
