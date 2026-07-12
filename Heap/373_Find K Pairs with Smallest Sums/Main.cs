public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        PriorityQueue<(int i, int j), int> queue = new();
        for (int i = 0; i < Math.Min(nums1.Length, k); i++)
        {
            queue.Enqueue((i, 0), nums1[i] + nums2[0]);
        }

        List<IList<int>> result = new();

        while (result.Count < k && queue.Count > 0)
        {
            var (i, j) = queue.Dequeue();
            result.Add(new List<int> { nums1[i], nums2[j] });

            if (j + 1 < nums2.Length)
            {
                queue.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
            }
        }

        return result;
    }
}
