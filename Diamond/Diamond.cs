using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        private const Char CHAR_A = 'A';
        private const Char CHAR_a = 'a';

        public string PrintDiamond(Char midCharacter)
        {
            if (!IsValidChar(midCharacter))
            {
                throw new ArgumentException($" Given character {midCharacter} is not valid Alphabet");
            }

            if (midCharacter == CHAR_A || midCharacter == CHAR_a)
                return CHAR_A.ToString();

            var topHalf = BuildTopHalf(Char.IsUpper(midCharacter) ? midCharacter : Char.ToUpper(midCharacter));
            var bottomHalf = topHalf.SkipLast(1).Reverse();
            return string.Join(Environment.NewLine, topHalf) + Environment.NewLine +
                   string.Join(Environment.NewLine, bottomHalf);
        }
        
        private List<string> BuildTopHalf(char midCharacter)
        {
            var topHalf = new List<string>();
            for (var ch = CHAR_A;ch <= midCharacter; ch++)
            {
                topHalf.Add(GetLine(ch, midCharacter));
            }

            return topHalf;
        }
        

        public int GetLengthOfMidLine(char midCharacter)
        {
            var distinctChars = midCharacter - CHAR_A + 1;
            return (2 * distinctChars) - 1;
        }
        
        public string GetLine(char ch, char midCharacter)
        {
            var length = GetLengthOfMidLine(midCharacter);
            var initialGap = midCharacter - ch;
            if (ch == CHAR_A)
            {
                var s = new string(Enumerable.Repeat(' ', initialGap).Append(ch).ToArray());
                return s;
            }

            var charPosition1 = initialGap + 1;
            var charPosition2 = length - (midCharacter - ch);
            var middleGap = charPosition2 - charPosition1 - 1;
            return new string(Enumerable.Repeat(' ', initialGap).Append(ch).ToArray()) +
                   new string(Enumerable.Repeat(' ', middleGap).Append(ch).ToArray());

        }

        private bool IsValidChar(char ch)
        {
            return Char.IsLetter(ch);
        }
    }
}