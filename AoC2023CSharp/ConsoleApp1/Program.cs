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
        }
    }
}