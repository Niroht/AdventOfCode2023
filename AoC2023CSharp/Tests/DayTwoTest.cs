using Implementation.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DayTwoTest
    {
        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "12 red; 13 green; 14 blue", true)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "12 red; 13 green; 14 blue", true)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "12 red; 13 green; 14 blue", true)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "12 red; 13 green; 14 blue", true)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "12 red; 13 green; 14 blue", true)]
        public void SetIsPossibleToPull(string desiredSet, string existingSet, bool isPossible)
        {
            var input = DayTwo.ParseCubePullGame(desiredSet);

            var existingSetDictionary = existingSet.Split("; ").ToDictionary(entry => entry.Split(' ')[1], entry => int.Parse(entry.Split(' ')[0]));

            Assert.Equal(isPossible, DayTwo.SumPossibleToPull(existingSetDictionary, new List<CubePullGame> { input }) >= 1);
        }

        [Fact]
        public void FindSumOfPowerOfMinimumCounts()
        {
            var inputs = new List<string>
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            }
            .Select(DayTwo.ParseCubePullGame);

            Assert.Equal(2286, inputs.Sum(input => input.ProductOfMaximumCounts()));
        }
    }
}
