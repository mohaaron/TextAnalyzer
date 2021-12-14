using System.Collections.Generic;
using Xunit;

namespace TrapWire.TextAnalysis.Tests
{
    public class TestTextAnalyzer
    {
        [Fact]
        public void Text_Contains_4_Chars()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            HashSet<CharacterResult> results = textAnalyzer.Analyze("AAaaBBbbCCccDDdd");

            Assert.Equal(4, results.Count);
        }

        [Fact]
        public void Text_Not_Contains_4_Chars()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            HashSet<CharacterResult> results = textAnalyzer.Analyze("bbCCccDDdd");

            Assert.NotEqual(4, results.Count);
        }

        [Fact]
        public void Text_Is_Letter()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            bool isLetter = textAnalyzer.IsLetter('a');

            Assert.True(isLetter);
        }

        [Fact]
        public void Text_Is_Not_Letter()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            bool isLetter = textAnalyzer.IsLetter('1');

            Assert.False(isLetter);
        }

        [Fact]
        public void Text_Count_Is_2_Letter()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            int count = textAnalyzer.GetCharOccurances(new char[] { 'a', 'a' }, 'a');

            Assert.Equal(2, count);
        }

        [Fact]
        public void Text_Count_Not_2_Letter()
        {
            ITextAnalyzer textAnalyzer = new TextAnalyzer();
            int count = textAnalyzer.GetCharOccurances(new char[] { 'a', 'b' }, 'a');

            Assert.NotEqual(2, count);
        }
    }
}