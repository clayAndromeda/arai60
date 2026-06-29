public class Solution
{
    public bool IsValid(string s)
    {
        Span<char> stack = stackalloc char[s.Length];
        int top = 0;

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    stack[top++] = c;
                    continue;

                case ')':
                    if (top == 0 || stack[--top] != '(') return false;
                    continue;
                case '}':
                    if (top == 0 || stack[--top] != '{') return false;
                    continue;
                case ']':
                    if (top == 0 || stack[--top] != '[') return false;
                    continue;
            }
        }

        return top == 0;
    }
}
