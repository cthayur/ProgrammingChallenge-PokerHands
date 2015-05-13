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
            analyzers = new List<IHandStrengthAnalyzer>();
            analyzers.Add(new StraightFlushAnalyzer(new FlushAnalyzer(new HighCardHandTieComparer()), new StraightAnalyzer(), new HighCardTieComparer()));
            analyzers.Add(new FourOfAKindAnalyzer(new HighCardTieComparer()));
            analyzers.Add(new FullHouseAnalyzer(new ThreeOfAKindAnalyzer(), new PairAnalyzer(), new HighCardTieComparer()));
            analyzers.Add(new FlushAnalyzer(new HighCardHandTieComparer()));
            analyzers.Add(new StraightAnalyzer());
            analyzers.Add(new ThreeOfAKindAnalyzer());
            analyzers.Add(new TwoPairAnalyzer(new PairAnalyzer()));
            analyzers.Add(new PairAnalyzer());
            analyzers.Add(new HighCardAnalyzer());
        }
    }
}
