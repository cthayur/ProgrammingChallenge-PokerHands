using PorkerHands.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.HandAnalyzers
{
    public class FlushAnalyzer : IHandStrengthAnalyzer
    {
        IHandTieBreakComparer highCardHandComparer;

        public FlushAnalyzer(IHandTieBreakComparer highCardHandComparer)
        {
            this.highCardHandComparer = highCardHandComparer;
        }

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var flushSuits = from hand in hands
                            group hand by hand.SuitString into suitGroup
                            where suitGroup.Count() == 5
                            select suitGroup.Key;

            var handRank = new HandRankResult { IsHand = flushSuits.Any() };
            
            if (handRank.IsHand)
            {
                handRank.RankList =
                    hands.OrderByDescending(x => x.NumericCardValue)
                    .Select(x => x.NumericCardValue);
            }

            return handRank;
        }


        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            return highCardHandComparer.Compare(blackResult, whiteResult);
        }
    }
}
