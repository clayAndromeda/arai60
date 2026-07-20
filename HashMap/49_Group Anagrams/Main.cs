public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> groups = new();
        foreach (var str in strs)
        {
            string sortedStr = new string(str.OrderBy(c => c).ToArray());
            if (!groups.ContainsKey(sortedStr))
            {
                groups.Add(sortedStr, new List<string>() { str });
            }
            else
            {
                groups[sortedStr].Add(str);
            }
        }

        return groups.Values.ToList();
    }
}
