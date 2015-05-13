using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class StraightAnalyzer : IHandStrengthAnalyzer
    {
        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var isHand = hands.Zip(hands.Skip(1), (a, b) => (a.NumericCardValue + 1) == b.NumericCardValue).All(x => x);

            var handRank = new HandRankResult { IsHand = isHand };

            if (handRank.IsHand)
                handRank.RankList = new HashSet<int> { hands.Max(x => x.NumericCardValue) };

            return handRank;
        }


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
