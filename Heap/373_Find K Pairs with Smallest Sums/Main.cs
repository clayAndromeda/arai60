public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        PriorityQueue<(int U, int V), int> pQueue = new(k + 1);
        for (int u = 0; u < nums1.Length; ++u)
        {
            pQueue.Enqueue((U: u, V: 0), nums1[u] + nums2[0]);
        }

        List<IList<int>> result = new();
        while (result.Count < k && pQueue.Count > 0)
        {
            (int u, int v) = pQueue.Dequeue();
            result.Add(new List<int>() { nums1[u], nums2[v] });
            if (v + 1 < nums2.Length)
            {
                pQueue.Enqueue((U: u, V: v + 1), nums1[u] + nums2[v + 1]);
            }
        }
        return result;
    }
}
