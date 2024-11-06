using System.Text;

namespace Calastone.TextFilter.Extensions;

public static class StringExtensions
{
    public static string RemoveNonAlphabetic(this string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return string.Empty;
        }

        var stringBuilder = new StringBuilder();
        foreach (char c in word)
        {
            if (char.IsLetter(c))
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }
}