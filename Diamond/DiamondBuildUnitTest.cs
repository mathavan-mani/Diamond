using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Diamond
{
    public class Tests
    {
        
        [Test]
        [TestCase('A')]
        [TestCase('a')]
        public void Prints_Diamond_When_First_Char_Is_Given(Char ch)
        {
            var diamond = new Diamond();
            Assert.AreEqual(ch.ToString().ToUpper(), diamond.PrintDiamond(ch));
        }
        
        [Test]
        [TestCase('$')]
        [TestCase('1')]
        public void Throws_Exception_When_Invalid_Input_Is_Given(Char ch)
        {
            var diamond = new Diamond();
            Assert.Throws<ArgumentException>(() => diamond.PrintDiamond(ch));
        }
        
        [Test]
        public void Builds_Diamond_For_Input_B()
        {
            var diamond = new Diamond();
            var expected = " A" + Environment.NewLine + "B B" + Environment.NewLine + " A";
            Assert.AreEqual(expected, diamond.PrintDiamond('B'));
        }
        
        [Test]
        public void Builds_Diamond_For_Input_D()
        {
            var diamond = new Diamond();
            
            var expected = BuildStringsWithNewLine( "   A" ,
                                                                        "  B B", 
                                                                        " C   C", 
                                                                        "D     D",
                                                                        " C   C" ,
                                                                        "  B B", 
                                                                        "   A");
       
            Assert.AreEqual(expected, diamond.PrintDiamond('D'));
        }

        
         
        [Test]
        [TestCase('Z')]
        [TestCase('O')]
        public void No_Exception_Throw_For_ValidInput(Char ch)
        {
            var diamond = new Diamond();
            
            Assert.DoesNotThrow(() => diamond.PrintDiamond(ch));
        }

        [Test]
        [TestCase('A','D',"   A")]
        [TestCase('B','D',"  B B")]
        [TestCase('E','E',"E       E")]
        public void Test_Individual_Line(char ch, char midChar, string expected)
        {
            var diamond = new Diamond();
            
            var resultLine = diamond.GetLine(ch, midChar);
            
            Assert.AreEqual(expected,resultLine);
        }
       
        private string BuildStringsWithNewLine(params string[] inputArray)
        {
            var combinedString = new StringBuilder();
            for (var index = 0; index < inputArray.Length - 1; index++)
            {
                combinedString.Append($"{inputArray[index]}{Environment.NewLine}");
            }
            combinedString.Append(inputArray[^1]);
            return combinedString.ToString();
        }
    }
}