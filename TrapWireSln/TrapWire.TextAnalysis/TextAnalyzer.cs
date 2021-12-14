namespace TrapWire.TextAnalysis
{
    public class TextAnalyzer : ITextAnalyzer
    {
        /// <inheritdoc />
        public HashSet<CharacterResult> Analyze(string text)
        {
            if (text == null)
                return new HashSet<CharacterResult>();

            // Requirements did not include case sensitivity
            text = text.Replace(" ", "").ToLower();
            char[] chars = text.ToCharArray();
            int charTotal = chars.Length;
            int charIndex = 0;
            HashSet<char> processed = new HashSet<char>();
            HashSet<CharacterResult> results = new HashSet<CharacterResult>();

            while (charIndex < text.Length)
            {
                // Get the char
                char c = chars[charIndex];

                if (!IsLetter(c))
                {
                    charIndex++;
                    continue;
                }

                // Skip if already counted
                if (processed.Contains(c))
                {
                    charIndex++;
                    continue;
                }

                // Count char occurances
                //int charCount = 0;
                //for(int i = 0; i < chars.Length; i++)
                //{
                //    char findChar = chars[i];
                    
                //    if (findChar == c)
                //        charCount++;
                //}

                if (!processed.Contains(c))
                {
                    int charCount = GetCharOccurances(chars, c);
                    CharacterResult characterResult = new CharacterResult
                    {
                        Character = c,
                        Count = charCount,
                        Percentage = (decimal)charCount / charTotal * 100
                    };

                    results.Add(characterResult);
                    processed.Add(c);
                }

                charIndex++;
            }
            
            return results.OrderBy(c => c.Character).ToHashSet();
        }

        public int GetCharOccurances(char[] chars, char charToCount)
        {
            int charCount = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                char findChar = chars[i];

                if (findChar == charToCount)
                    charCount++;
            }

            return charCount;
        }

        /// <inheritdoc />
        public bool IsLetter(char character)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            if (alphabet.Contains(character))
                return true;
            return false;
        }
    }
}