using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerHands
{
    public class Card
    {
        public string OriginalCardValueString
        {
            get
            {
                return ValueString + SuitString;
            }

            set
            {
                ValueString = value.Substring(0, 1);
                SuitString = value.Substring(1);
            }
        }

        public string ValueString { get; set; }
        public string SuitString { get; set; }

        private int numericCardValue;

        public int NumericCardValue
        {
            get
            {
                if (numericCardValue == 0)
                    numericCardValue = StaticObjects.CardRanks[ValueString];

                return numericCardValue;
            }
        }


    }
}
