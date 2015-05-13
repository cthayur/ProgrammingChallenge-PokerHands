using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class FourOfAKindAnalyzer : IHandStrengthAnalyzer
    {

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var groups = from hand in hands
                        group hand by hand.NumericCardValue into cardGroup
                        where cardGroup.Count() == 4
                        select cardGroup.Key;

            var handRank = new HandRankResult();

            if (groups.Any())
            {
                handRank.IsHand = true;
                handRank.RankList = new HashSet<int> { groups.First() };
            }

            return handRank;
        }
    }
}
