
public static class Bob
{
    public static string Response(string statement)
    {
        // Якщо statement дорівнює null, перетворимо його на порожній рядок
        statement = statement ?? "";

        // Відрізняємо пробіли
        string trimmedStatement = statement.Trim();

        // Перевірка на тишу
        if (string.IsNullOrEmpty(trimmedStatement))
        {
            return "Fine. Be that way!";
        }

        // Перевірка, чи все сказане великими буквами
        bool isYelling = trimmedStatement.ToUpper() == trimmedStatement && 
                          trimmedStatement.ToLower() != trimmedStatement;

        // Перевірка, чи питання
        bool isQuestion = trimmedStatement.EndsWith("?");

        // Відповіді за умовами
        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (isYelling)
        {
            return "Whoa, chill out!";
        }
        else if (isQuestion)
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }
    }
}