public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> keyToIndex = new();
        for (int index = 0; index < nums.Length; ++index)
        {
            if (!keyToIndex.TryGetValue(target - nums[index], out var pairIndex))
            {
                keyToIndex[nums[index]] = index;
                continue;
            }
            return new int[] { index, pairIndex };
        }

        throw new ArgumentException("The Answer not found");
    }
}
