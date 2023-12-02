using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Days
{
    public static class DayOne
    {
        public static int SumFirstAndLastDigits(IEnumerable<string> input, bool digitsWrittenOut)
        {
            var digitStrings = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" }
            };

            var concatFirstAndLastDigits = (string line) =>
            {
                var digits = new List<string>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        digits.Add(line[i].ToString());
                        continue;
                    }
                    if (digitsWrittenOut == false)
                    {
                        continue;
                    }

                    if (digitStrings.Keys.Any(digitString => digitString.StartsWith(line[i])))
                    {
                        var writtenDigit = line[i].ToString();
                        for (int j = 1; j + i < line.Length; j++)
                        {
                            var nextCharacter = line[i + j];

                            var potentialWrittenDigit = writtenDigit + nextCharacter;
                            if (!digitStrings.Keys.Any(digitString => digitString.StartsWith(potentialWrittenDigit)))
                            {
                                break;
                            }

                            writtenDigit = potentialWrittenDigit;
                            if (digitStrings.ContainsKey(writtenDigit))
                            {
                                digits.Add(digitStrings[writtenDigit]);

                                i += j - 1;
                            }
                        }
                    }
                }

                return int.Parse($"{digits.First()}{digits.Last()}");
            };

            return input
                .Sum(concatFirstAndLastDigits);
        }
    }
}
