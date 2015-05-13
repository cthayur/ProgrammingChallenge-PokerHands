using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class StraightFlushAnalyzer : IHandStrengthAnalyzer
    {
        IHandStrengthAnalyzer flushAnalyzer;
        IHandStrengthAnalyzer straightAnalyzer;
        IHandTieBreakComparer highCardComparer;

        public StraightFlushAnalyzer(IHandStrengthAnalyzer flushAnalyzer, IHandStrengthAnalyzer straightAnalyzer, IHandTieBreakComparer highCardComparer)
        {
            this.flushAnalyzer = flushAnalyzer;
            this.straightAnalyzer = straightAnalyzer;
            this.highCardComparer = highCardComparer;
        }

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var handRank = new HandRankResult();

            var flushResult = flushAnalyzer.Analyze(hands);

            if(flushResult.IsHand)
            {
                var straightResult = straightAnalyzer.Analyze(hands);

                if(straightResult.IsHand)
                {
                    handRank.IsHand = true;
                    handRank.RankList = new HashSet<int> { straightResult.RankList.First() };
                }
            }

            return handRank;
        }

        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            return highCardComparer.Compare(blackResult, whiteResult);
        }
    }
}
