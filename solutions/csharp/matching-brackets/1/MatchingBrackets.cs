public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char c in input)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false; 
                }
            }
        }

        return stack.Count == 0; 
    }
}