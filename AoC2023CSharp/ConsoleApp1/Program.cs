﻿using Implementation.Days;

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
            Console.WriteLine($"Day Two Part 1: {DayTwo.SumPossibleToPull(dayTwoPartOneExistingSet, dayTwoInputLines.Select(DayTwo.ParseCubePullGame))}");
        }
    }
}