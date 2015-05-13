using PorkerHands.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.HandAnalyzers
{
    public class ThreeOfAKindAnalyzer : IHandStrengthAnalyzer
    {
        IHandTieBreakComparer highCardComparer;

        public ThreeOfAKindAnalyzer(IHandTieBreakComparer highCardComparer)
        {
            this.highCardComparer = highCardComparer;
        }

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var handRank = new HandRankResult();

            var groups = from hand in hands
                        group hand by hand.NumericCardValue into cardGroup
                        where cardGroup.Count() == 3
                        select cardGroup.Key;

            if(groups.Any())
            {
                handRank.IsHand = true;
                handRank.RankList = new HashSet<int> { groups.First() };
            }

            return handRank;
        }


        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            return highCardComparer.Compare(blackResult, whiteResult);
        }
    }
}
