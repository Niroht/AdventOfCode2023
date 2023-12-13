using Implementation.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DayFourTest
    {
        [Theory]
        [InlineData("41 48 83 86 17", "83 86 6 31 17 9 48 53", 8)]
        [InlineData("13 32 20 16 61", "61 30 68 82 17 32 24 19", 2)]
        [InlineData("1 21 53 59 44", "69 82 63 72 16 21 14 1", 2)]
        [InlineData("41 92 73 84 69", "59 84 76 51 58 5 54 83", 1)]
        [InlineData("87 83 26 28 32", "88 30 70 12 93 22 82 36", 0)]
        [InlineData("31 18 13 56 72", "74 77 10 23 35 67 36 11", 0)]
        public void CountWinningNumbersInDraw(string winningNumberString, string numbersDrawnString, int expectedScore)
        {
            var winningNumbers = winningNumberString.Split(' ').Select(int.Parse);
            var drawnNumbers = numbersDrawnString.Split(' ').Select(int.Parse);

            var result = DayFour.SumCardScores(new List<(IEnumerable<int> WinningNumbers, IEnumerable<int> DrawnNumbers)> { (winningNumbers, drawnNumbers) });
            Assert.Equal(expectedScore, result);
        }
    }
}
