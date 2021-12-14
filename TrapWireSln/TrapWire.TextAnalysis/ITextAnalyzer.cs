using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapWire.TextAnalysis
{
    public interface ITextAnalyzer
    {
        /// <summary>
        /// Analyzes text and returns a set of character results.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        HashSet<CharacterResult> Analyze(string text);

        /// <summary>
        /// Get the number of occurances of the char in the char array.
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="charToCount"></param>
        /// <returns></returns>
        int GetCharOccurances(char[] chars, char charToCount);

        /// <summary>
        /// Checks if a character is a letter in the alphabet.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool IsLetter(char character);
    }
}
