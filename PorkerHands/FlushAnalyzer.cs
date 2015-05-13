using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class FlushAnalyzer : IHandStrengthAnalyzer
    {
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
    }
}
