using Implementation.Days;

namespace Implementation
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dayOneInputLines = File.ReadAllLines(@"Input/DayOneInput.txt");
            Console.WriteLine($"Day One Part 1: {DayOne.SumFirstAndLastDigits(dayOneInputLines, false)}");
            Console.WriteLine($"Day One Part 2: {DayOne.SumFirstAndLastDigits(dayOneInputLines, true)}");

            var dayTwoInputLines = File.ReadAllLines(@"Input/DayTwoInput.txt");
            var dayTwoPartOneExistingSet = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var dayTwoDomainModels = dayTwoInputLines.Select(DayTwo.ParseCubePullGame);
            Console.WriteLine($"Day Two Part 1: {DayTwo.SumPossibleToPull(dayTwoPartOneExistingSet, dayTwoDomainModels)}");
            Console.WriteLine($"Day Two Part 2: {dayTwoDomainModels.Sum(model => model.ProductOfMaximumCounts())}");

            var dayThreeInputLines = File.ReadAllLines(@"Input/DayThreeInput.txt");
            Console.WriteLine($"Day Three Part 1: {DayThree.SumPartNumbersAdjacentToSmybol(dayThreeInputLines.Select(l => l.ToCharArray()).ToArray())}");
            Console.WriteLine($"Day Three Part 2: {DayThree.SumGearRatios(dayThreeInputLines.Select(l => l.ToCharArray()).ToArray())}");
        }
    }
}