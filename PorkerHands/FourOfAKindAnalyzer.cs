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
