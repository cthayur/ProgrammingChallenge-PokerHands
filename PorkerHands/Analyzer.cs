using PorkerHands.Comparers;
using PorkerHands.HandAnalyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class Analyzer
    {
        IEnumerable<Card> blackCards;
        IEnumerable<Card> whiteCards;
        List<IHandStrengthAnalyzer> analyzers;

        public Analyzer(IEnumerable<Card> blackCards, IEnumerable<Card> whiteCards)
        {
            this.blackCards = blackCards.OrderBy(x => x.NumericCardValue);
            this.whiteCards = whiteCards.OrderBy(x => x.NumericCardValue);

            SetUpAnalyzers();
        }

        public string GetWinner()
        {

            foreach(var analyzer in analyzers)
            {
                var blackCardsResult = analyzer.Analyze(blackCards);
                var whiteCardsResult = analyzer.Analyze(whiteCards);

                if (blackCardsResult.IsHand && !whiteCardsResult.IsHand)
                    return "Black Wins.";
                else if (whiteCardsResult.IsHand && !blackCardsResult.IsHand)
                    return "White Wins.";
                else if (blackCardsResult.IsHand && whiteCardsResult.IsHand)
                    return "Tie.";
            }

            return null;
        }

        private void SetUpAnalyzers()
        {
            var highCardTieComparer = new HighCardTieComparer();
            var highCardHandTieComparer = new HighCardHandTieComparer();
            var flushAnalyzer = new FlushAnalyzer(highCardHandTieComparer);
            var straightAnalyzer = new StraightAnalyzer(highCardTieComparer);
            var threeOfAKindAnalyzer = new ThreeOfAKindAnalyzer();
            var pairAnalyzer = new PairAnalyzer();

            analyzers = new List<IHandStrengthAnalyzer>();
            analyzers.Add(new StraightFlushAnalyzer(flushAnalyzer, straightAnalyzer, highCardTieComparer));
            analyzers.Add(new FourOfAKindAnalyzer(highCardTieComparer));
            analyzers.Add(new FullHouseAnalyzer(threeOfAKindAnalyzer, pairAnalyzer, highCardTieComparer));
            analyzers.Add(flushAnalyzer);
            analyzers.Add(straightAnalyzer);
            analyzers.Add(threeOfAKindAnalyzer);
            analyzers.Add(new TwoPairAnalyzer(pairAnalyzer));
            analyzers.Add(pairAnalyzer);
            analyzers.Add(new HighCardAnalyzer());
        }
    }
}
