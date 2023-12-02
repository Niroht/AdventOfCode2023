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
                return game.Pulls
                .All(pull => pull.All(entry =>
                {
                    return actualContents.ContainsKey(entry.Key) && actualContents[entry.Key] >= entry.Value;
                }));
            };

            return cubePulls.Where(allPullsArePossible).Sum(game => game.Id);
        }

        public static CubePullGame ParseCubePullGame(string pullAsString)
        {
            var parts = pullAsString.Split(": ");
            var id = int.Parse(parts[0].Split(' ')[1]);

            var pullStrings = parts[1].Split("; ");

            var pulls = pullStrings
                .Select(pull => pull
                    .Split(", ")
                    .ToDictionary(colorSet => colorSet.Split(" ")[1], colorSet => int.Parse(colorSet.Split(" ")[0])));

            return new CubePullGame
            {
                Id = id,
                Pulls = pulls
            };
        }
    }

    public class CubePullGame
    {
        public int Id { get; set; }

        public IEnumerable<Dictionary<string, int>> Pulls { get; set; } = new List<Dictionary<string, int>>();
    }
}
