using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Days
{
    public class DayThree
    {
        public static int SumPartNumbersAdjacentToSmybol(char[][] matrix)
        {
            return ParseMatrix(matrix).SumPartNumbers;
        }

        public static int SumGearRatios(char[][] matrix)
        {
            return ParseMatrix(matrix).SumGearRatios;
        }

        private static (int SumPartNumbers, int SumGearRatios) ParseMatrix(char[][] matrix)
        {
            var sumPartNumbers = 0;

            var partsWithNumbers = new Dictionary<(int Row, int Column), List<int>> ();

            for (int rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
            {
                var row = matrix[rowNumber];

                var currentPartNumber = new StringBuilder();
                var adjacentParts = new HashSet<(int Row, int Column)>(); ;

                for (int columnNumber = 0; columnNumber < row.Length; columnNumber++)
                {
                    var currentCharacter = row[columnNumber];

                    if (currentCharacter == '.' || !char.IsDigit(currentCharacter))
                    {
                        if (adjacentParts.Any())
                        {
                            var partNumberNumeric = int.Parse(currentPartNumber.ToString());
                            sumPartNumbers += partNumberNumeric;

                            RecalculateGears(partsWithNumbers, adjacentParts, partNumberNumeric);

                            // Reset
                            currentPartNumber = new StringBuilder();
                            adjacentParts.Clear();
                        }
                        else
                        {
                            currentPartNumber.Clear();
                        }

                        continue;
                    }

                    currentPartNumber.Append(currentCharacter);

                    var desiredAdjacentPoints = new List<(int Row, int Column)>
                    {
                        (rowNumber - 1, columnNumber - 1), (rowNumber - 1, columnNumber), (rowNumber - 1, columnNumber + 1),
                        (rowNumber, columnNumber - 1),                                    (rowNumber, columnNumber + 1),
                        (rowNumber + 1, columnNumber - 1), (rowNumber + 1, columnNumber), (rowNumber + 1, columnNumber + 1)
                    };

                    foreach(var desiredAdjacentPoint in desiredAdjacentPoints.Where(point => PointIsPart(point.Row, point.Column, matrix)))
                    {
                        adjacentParts.Add(desiredAdjacentPoint);
                    }
                }

                // End of row - check to see if we ended on a part number
                if (adjacentParts.Any())
                {
                    var partNumberNumeric = int.Parse(currentPartNumber.ToString());
                    sumPartNumbers += partNumberNumeric;
                    RecalculateGears(partsWithNumbers, adjacentParts, partNumberNumeric);
                }
            }

            return (sumPartNumbers, partsWithNumbers.Where(gear => gear.Value.Count == 2).Sum(gear => gear.Value.First() * gear.Value.Last()));
        }

        private static void RecalculateGears(Dictionary<(int Row, int Column), List<int>> gears, HashSet<(int Row, int Column)> adjacentParts, int partNumberNumeric)
        {
            foreach (var part in adjacentParts)
            {
                if (gears.ContainsKey(part))
                {
                    gears[part].Add(partNumberNumeric);
                }
                else
                {
                    gears.Add(part, new List<int> { partNumberNumeric });
                }
            }
        }

        private static bool PointIsPart(
            int desiredRow,
            int desiredColumn,
            char[][] matrix)
        {
            var outOfBounds = desiredRow < 0 || desiredRow >= matrix.Length || desiredColumn < 0 || desiredColumn >= matrix[desiredRow].Length;
            if (outOfBounds)
            {
                return false;
            }

            var currentCharacter = matrix[desiredRow][desiredColumn];
            return currentCharacter != '.' && !char.IsDigit(currentCharacter);
        }
    }
}
