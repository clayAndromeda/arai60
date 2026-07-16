public class Solution
{
    // numsをDictionaryでアクセスできるようにする
    // nums[i]と足し合わせてtargetになる値がnumsにあるかを調べる
    // -> これだと、numsに同じ値があるときに困る。Dictionary<int, int[]> だとまあ対応できるが。。。
    // いや、Dictionaryを構築しながら見ていけばいいのか。

    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numToIndex = new(nums.Length);
        for (int i = 0; i < nums.Length; ++i)
        {
            if (numToIndex.TryGetValue(target - nums[i], out var pairIndex))
            {
                return new int[] { pairIndex, i };
            }

            numToIndex[nums[i]] = i;
        }

        throw new ArgumentException("No two numbers add up to the target.");
    }
}
