﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class PairAnalyzer : IHandStrengthAnalyzer
    {
        public HandRankResult Analyze(IEnumerable<Card> hands)
        {
            var handRank = new HandRankResult();

            var pairGroup = from hand in hands
                            group hand by hand.NumericCardValue into cardGroup
                            where cardGroup.Count() == 2
                            select cardGroup.Key;

            if(pairGroup.Any())
            {
                var pairCardValue = pairGroup.First();
                var rankList = new List<int> { pairCardValue };

                var remainingRankedCards = hands.Where(x => x.NumericCardValue != pairCardValue)
                                            .OrderByDescending(x => x.NumericCardValue)
                                            .Select(x => x.NumericCardValue);

                rankList.AddRange(remainingRankedCards);
                
                handRank.IsHand = true;
                handRank.RankList = rankList;
            }

            return handRank;
        }
    }
}
