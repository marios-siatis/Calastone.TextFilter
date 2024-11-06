using System.Text.RegularExpressions;

namespace Calastone.TextFilter.Filters;

public class VowelFilter : WordFilter
{
    private readonly string _vowels = "AEIOUaeiou";

    public override string Apply(string word)
    {
        if (string.IsNullOrEmpty(word) || word.Length < 3)
        {
            base.Apply(word);
        }
        
        var sanitizedWord = Regex.Replace(word, "[^a-zA-Z]", "");
        var result = IsMiddleIndexVowel(sanitizedWord) ? string.Empty : word;
        return base.Apply(result);
    }

    public override bool IsEnabled() => true;

    private bool IsMiddleIndexVowel(string word)
    {
        bool result;
        var length = word.Length;
        if (length % 2 == 0)
        {
            var middleIndex1 = (length / 2) - 1;
            var middleIndex2 = middleIndex1 + 1;
            result = _vowels.Contains(word[middleIndex1]) || _vowels.Contains(word[middleIndex2]);
        }
        else
        {
            var middleIndex = length / 2;
            result = _vowels.Contains(word[middleIndex]);
        }

        return result;
    }
}