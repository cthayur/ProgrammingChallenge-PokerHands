using PorkerHands.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.HandAnalyzers
{
    public class HighCardAnalyzer : IHandStrengthAnalyzer
    {
        IHandTieBreakComparer highCardHandComparer;

        public HighCardAnalyzer(IHandTieBreakComparer highCardHandComparer)
        {
            this.highCardHandComparer = highCardHandComparer;
        }

        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            return new HandRankResult { IsHand = true, RankList = hands.OrderByDescending(x => x.NumericCardValue).Select(x => x.NumericCardValue) };
        }


        public string Compare(HandRankResult blackResult, HandRankResult whiteResult)
        {
            return highCardHandComparer.Compare(blackResult, whiteResult);
        }
    }
}
