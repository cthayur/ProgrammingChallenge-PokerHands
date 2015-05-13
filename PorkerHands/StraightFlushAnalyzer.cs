﻿using System;
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

        public StraightFlushAnalyzer(IHandStrengthAnalyzer flushAnalyzer, IHandStrengthAnalyzer straightAnalyzer)
        {
            this.flushAnalyzer = flushAnalyzer;
            this.straightAnalyzer = straightAnalyzer;
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
    }
}
