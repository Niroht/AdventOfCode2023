using Implementation.Days;
using Xunit;

namespace Tests
{
    public class DayOneTest
    {
        [Theory]
        [InlineData("seight3ssdvsoneight", 88, true)] // Not included in AOC-provided samples: changes to different digit midway through
        [InlineData("1abc2", 12, false)]
        [InlineData("pqr3stu8vwx", 38, false)]
        [InlineData("a1b2c3d4e5f", 15, false)]
        [InlineData("treb7uchet", 77, false)]
        [InlineData("two1nine", 29, true)]
        [InlineData("eightwothree", 83, true)]
        [InlineData("abcone2threexyz", 13, true)]
        [InlineData("xtwone3four", 24, true)]
        [InlineData("4nineeightseven2", 42, true)]
        [InlineData("zoneight234", 14, true)] // "One" is the first digit, "Eight" is not
        [InlineData("7pqrstsixteen", 76, true)] // "Six" is a digit, "Sixteen" is not (two digits)*/
        public void CombineFirstAndLastDigit(string inputLine, int expectedResult, bool digitsWrittenOut)
        {
            Assert.Equal(expectedResult, DayOne.SumFirstAndLastDigits(new List<string>() { inputLine }, digitsWrittenOut));
        }

        [Theory]
        [InlineData("1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet", false, 142)]
        [InlineData("two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen", true, 281)]
        public void CalculateSumOfMultipleLinesWithNoWrittenDigits(string input, bool writtenDigits, int expectedResult)
        {
            Assert.Equal(expectedResult, DayOne.SumFirstAndLastDigits(input.Split("\r\n"), writtenDigits));
        }
    }
}
