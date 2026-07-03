public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new();

        bool PopMatchesOpen(char expectedOpen)
        {
            return stack.TryPop(out var top) && top == expectedOpen;
        }

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    stack.Push(c);
                    break;
                case ')':
                    if (!PopMatchesOpen('(')) return false;
                    break;
                case '}':
                    if (!PopMatchesOpen('{')) return false;
                    break;
                case ']':
                    if (!PopMatchesOpen('[')) return false;
                    break;
            }
        }

        return stack.Count == 0;
    }
}
