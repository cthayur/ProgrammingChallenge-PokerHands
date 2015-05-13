using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public static class StaticObjects
    {
        public static Dictionary<string, int> CardRanks;
        public static HashSet<string> DistinctSuits;

        static StaticObjects()
        {
            SetUpCardRanks();
            SetUpDistinctSuits();
        }

        private static void SetUpDistinctSuits()
        {
            DistinctSuits = new HashSet<string>();
            DistinctSuits.Add("H");
            DistinctSuits.Add("C");
            DistinctSuits.Add("D");
            DistinctSuits.Add("S");
        }

        private static void SetUpCardRanks()
        {
            CardRanks = new Dictionary<string, int>();
            CardRanks.Add("2", 2);
            CardRanks.Add("3", 3);
            CardRanks.Add("4", 4);
            CardRanks.Add("5", 5);
            CardRanks.Add("6", 6);
            CardRanks.Add("7", 7);
            CardRanks.Add("8", 8);
            CardRanks.Add("9", 9);
            CardRanks.Add("T", 10);
            CardRanks.Add("J", 11);
            CardRanks.Add("Q", 12);
            CardRanks.Add("K", 13);
            CardRanks.Add("A", 14);
        }
    }
}
