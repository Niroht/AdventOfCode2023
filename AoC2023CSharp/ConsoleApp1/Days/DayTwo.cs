using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Days
{
    public class DayTwo
    {
        public static int SumPossibleToPull(Dictionary<string, int> actualContents, IEnumerable<CubePullGame> cubePulls)
        {
            var allPullsArePossible = (CubePullGame game) =>
            {
                return game.MaximumPullsPerColor.All(entry => actualContents.TryGetValue(entry.Key, out var actualValue) && actualValue >= entry.Value);
            };

            return cubePulls.Where(allPullsArePossible).Sum(game => game.Id);
        }

        public static CubePullGame ParseCubePullGame(string pullAsString)
        {
            var parts = pullAsString.Split(": ");
            var id = int.Parse(parts[0].Split(' ')[1]);

            var pullStrings = parts[1].Split("; ");

            var pullsByColorPerGame = pullStrings
                .Select(pull => pull
                    .Split(", ")
                    .ToDictionary(colorSet => colorSet.Split(" ")[1], colorSet => int.Parse(colorSet.Split(" ")[0])));

            var maximumPullsByColor = new Dictionary<string, int>();

            foreach (var pull in pullsByColorPerGame)
            {
                foreach(var entry in pull)
                {
                    if (maximumPullsByColor.TryGetValue(entry.Key, out var existingValue))
                    {
                        if (existingValue < entry.Value)
                        {
                            maximumPullsByColor[entry.Key] = entry.Value;
                        }
                    }
                    else
                    {
                        maximumPullsByColor.Add(entry.Key, entry.Value);
                    }
                }
            }

            return new CubePullGame
            {
                Id = id,
                MaximumPullsPerColor = maximumPullsByColor,
            };
        }
    }

    public class CubePullGame
    {
        public int Id { get; set; }

        public Dictionary<string, int> MaximumPullsPerColor { get; set; } = new Dictionary<string, int>();

        public long ProductOfMaximumCounts()
        {
            return MaximumPullsPerColor.Aggregate(1, (accumulator, entry) => accumulator * entry.Value);
        }
    }
}
