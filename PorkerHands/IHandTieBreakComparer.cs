using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public interface IHandTieBreakComparer
    {
        string Compare(HandRankResult blackResult, HandRankResult whiteResult);
    }
}
