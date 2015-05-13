using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.Comparers
{
    public class HighCardTieComparer : IHandTieBreakComparer
    {
        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            var blackHighCard = blackResult.RankList.First();
            var whiteHighCard = whiteResult.RankList.First();

            if (blackHighCard == whiteHighCard)
                return StaticObjects.TIE;
            else if (blackHighCard > whiteHighCard)
                return StaticObjects.BLACK_WINS;
            else
                return StaticObjects.WHITE_WINS;
        }
    }
}
