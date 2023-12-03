using Implementation.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DayThreeTest
    {
        [Fact]
        public void HorizontallyAdjacent()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '*', '2'}
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(1 + 2, result);
        }

        [Fact]
        public void VerticallyAdjacent()
        {
            var matrix = new char[][]
            {
                new char[] { '1',},
                new char[] { '*',},
                new char[] { '2',},
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(1 + 2, result);
        }

        [Fact]
        public void VerticallyAndHorizontallyAdjacent()
        {
            var matrix = new char[][]
            {
                new char[] { '.', '1', '.'},
                new char[] { '2', '*', '3'},
                new char[] { '.', '4', '.'},
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(1 + 2 + 3 + 4, result);
        }

        [Fact]
        public void DiagonallyAdjacent()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '.', '2'},
                new char[] { '.', '$', '.'},
                new char[] { '3', '.', '4'},
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(1 + 2 + 3 + 4, result);
        }

        [Fact]
        public void ContiguousNumbers()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '2', '*', '3', '4' }
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(12 + 34, result);
        }

        [Fact]
        public void PartNumbersSpanDirections()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '2', '3'},
                new char[] { '.', '$', '.'},
                new char[] { '4', '.', '5'},
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(123 + 4 + 5, result);
        }

        [Fact]
        public void NoAdjacentParts()
        {
            var matrix = new char[][]
            {
                new char[] { '1', '2', '3'},
                new char[] { '.', '.', '.'},
                new char[] { '4', '#', '5'},
            };

            var result = DayThree.SumPartNumbersAdjacentToSmybol(matrix);

            Assert.Equal(4 + 5, result);
        }
    }
}
