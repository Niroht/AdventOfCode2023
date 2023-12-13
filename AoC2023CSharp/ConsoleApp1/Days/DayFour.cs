using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Days
{
    public static class DayFour
    {
        public static int SumCardScores(IEnumerable<(IEnumerable<int> WinningNumbers, IEnumerable<int> DrawnNumbers)> cards) 
        {
            return cards.Sum(card =>
            {
                return card.DrawnNumbers.Aggregate(0, (accumulator, draw) =>
                {
                    if (card.WinningNumbers.Contains(draw))
                    {
                        return accumulator == 0 ? 1 : accumulator * 2;
                    }

                    return accumulator;
                });
            });
        }
    }
}
