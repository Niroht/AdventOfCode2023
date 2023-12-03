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
            var sum = 0;

            for (int rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
            {
                var row = matrix[rowNumber];

                var currentPartNumber = new StringBuilder();
                var foundAdjacentPart = false;

                for (int columnNumber = 0; columnNumber < row.Length; columnNumber++)
                {
                    var currentCharacter = row[columnNumber];

                    if (currentCharacter == '.' || !char.IsDigit(currentCharacter))
                    {
                        if (foundAdjacentPart)
                        {
                            sum += int.Parse(currentPartNumber.ToString());
                            currentPartNumber = new StringBuilder();
                            foundAdjacentPart = false;
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

                    if (desiredAdjacentPoints.Any(point => PointIsPart(point.Row, point.Column, matrix)))
                    {
                        foundAdjacentPart = true;
                    }
                }

                // End of row - check to see if we ended on a part number
                if (foundAdjacentPart)
                {
                    sum += int.Parse(currentPartNumber.ToString());
                }
            }

            return sum;
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
