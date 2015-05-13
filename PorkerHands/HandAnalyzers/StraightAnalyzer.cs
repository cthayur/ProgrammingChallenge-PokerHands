using PorkerHands.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.HandAnalyzers
{
    public class StraightAnalyzer : IHandStrengthAnalyzer
    {
        IHandTieBreakComparer highCardComparer;

        public StraightAnalyzer(IHandTieBreakComparer highCardComparer)
        {
            this.highCardComparer = highCardComparer;
        }

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
            return highCardComparer.Compare(blackResult, whiteResult);
        }
    }
}
