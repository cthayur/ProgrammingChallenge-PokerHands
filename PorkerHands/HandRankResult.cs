using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class HandRankResult
    {
        public bool IsHand { get; set; }
        public IEnumerable<int> RankList { get; set; }
    }
}
