public static class RotationalCipher
{
    public static string Rotate(string input, int key)
    {
        key %= 26;

        var result = new System.Text.StringBuilder(input.Length);

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsUpper(ch) ? 'A' : 'a';
                char rotated = (char)(offset + (ch - offset + key + 26) % 26);
                result.Append(rotated);
            }
            else
            {
                result.Append(ch);
            }
        }

        return result.ToString();
    }
}
