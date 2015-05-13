using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class FullHouseAnalyzer : IHandStrengthAnalyzer
    {
        IHandStrengthAnalyzer threeOfAKindAnalyzer;
        IHandStrengthAnalyzer pairAnalyzer;
        IHandTieBreakComparer highCardComparer;

        public FullHouseAnalyzer(IHandStrengthAnalyzer threeOfAKindAnalyzer, IHandStrengthAnalyzer pairAnalyzer, IHandTieBreakComparer highCardComparer)
        {
            this.threeOfAKindAnalyzer = threeOfAKindAnalyzer;
            this.pairAnalyzer = pairAnalyzer;
            this.highCardComparer = highCardComparer;
        }
        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var handRank = new HandRankResult();
            var threeOfAKindResult = threeOfAKindAnalyzer.Analyze(hands);

            if (threeOfAKindResult.IsHand)
            {
                var threeOfAKindCardRank = threeOfAKindResult.RankList.First();
                var pairResult = pairAnalyzer.Analyze(hands.Where(x => x.NumericCardValue != threeOfAKindCardRank));

                if(pairResult.IsHand)
                {
                    handRank.IsHand = true;
                    handRank.RankList = new HashSet<int> { threeOfAKindCardRank };
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
