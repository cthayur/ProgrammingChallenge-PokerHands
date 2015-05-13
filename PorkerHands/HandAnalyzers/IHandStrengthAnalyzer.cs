using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands.HandAnalyzers
{
    public interface IHandStrengthAnalyzer
    {
        HandRankResult Analyze(IEnumerable<Card> hands);
        string Compare(HandRankResult blackResult, HandRankResult whiteResult);
    }
}
