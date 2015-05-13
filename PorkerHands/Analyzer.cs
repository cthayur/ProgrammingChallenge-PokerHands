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
        IEnumerable<IHandStrengthAnalyzer> analyzers;

        public Analyzer(IEnumerable<Card> blackCards, IEnumerable<Card> whiteCards, IEnumerable<IHandStrengthAnalyzer> analyzers)
        {
            this.blackCards = blackCards.OrderBy(x => x.NumericCardValue);
            this.whiteCards = whiteCards.OrderBy(x => x.NumericCardValue);
            this.analyzers = analyzers;
        }

        public string GetWinner()
        {

            foreach(var analyzer in analyzers)
            {
                var blackCardsResult = analyzer.Analyze(blackCards);
                var whiteCardsResult = analyzer.Analyze(whiteCards);

                if (blackCardsResult.IsHand && !whiteCardsResult.IsHand)
                    return StaticObjects.BLACK_WINS;
                else if (whiteCardsResult.IsHand && !blackCardsResult.IsHand)
                    return StaticObjects.WHITE_WINS;
                else if (blackCardsResult.IsHand && whiteCardsResult.IsHand)
                    return analyzer.Compare(blackCardsResult, whiteCardsResult);
            }

            return null;
        }        
    }
}
