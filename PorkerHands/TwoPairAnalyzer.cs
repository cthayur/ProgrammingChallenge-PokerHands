using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class TwoPairAnalyzer : IHandStrengthAnalyzer
    {
        IHandStrengthAnalyzer pairAnalyzer;

        public TwoPairAnalyzer(IHandStrengthAnalyzer pairAnalyzer)
        {
            this.pairAnalyzer = pairAnalyzer;
        }

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var handRank = new HandRankResult();

            var firstPairResult = pairAnalyzer.Analyze(hands);

            if(firstPairResult.IsHand)
            {
                var firstPairCard = firstPairResult.RankList.First();
                var secondPairResult = pairAnalyzer.Analyze(hands.Where(x => x.NumericCardValue != firstPairCard));

                if(secondPairResult.IsHand)
                {
                    handRank.IsHand = true;

                    var secondPairCard = secondPairResult.RankList.First();
                    var rankList = new List<int> { firstPairCard, secondPairCard }.OrderByDescending(x => x).ToList();

                    rankList.Add(
                        hands.Where(x => x.NumericCardValue != firstPairCard 
                                    && x.NumericCardValue != secondPairCard)
                        .First().NumericCardValue);

                    handRank.RankList = rankList;
                }
            }

            return handRank;
        }
    }
}
