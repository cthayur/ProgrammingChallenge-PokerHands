using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public interface IHandStrengthAnalyzer
    {
        HandRankResult Analyze(IEnumerable<Card> hands);
    }
}
