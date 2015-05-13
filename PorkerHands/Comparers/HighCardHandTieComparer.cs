using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.Comparers
{
    public class HighCardHandTieComparer : IHandTieBreakComparer
    {
        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            var result = StaticObjects.TIE;

            for (var i = 0; i < blackResult.RankList.Count(); i++)
            {
                var currentBlackRank = blackResult.RankList.ElementAt(i);
                var currentWhiteRank = whiteResult.RankList.ElementAt(i);

                if (currentBlackRank == currentWhiteRank)
                    continue;
                else if (currentBlackRank > currentWhiteRank)
                    return StaticObjects.BLACK_WINS;
                else
                    return StaticObjects.WHITE_WINS;
            }

            return result;
        }
    }
}
