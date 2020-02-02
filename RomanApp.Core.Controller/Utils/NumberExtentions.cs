using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Core.Controller.Utils
{
    public static class MathExtentions
    {

        public static decimal RoundCents(this decimal value, bool wholeNumbers)
        {
            decimal retval = 0;

            if (wholeNumbers)
            {
                retval = Math.Floor(value);
            }
            else
            {
                int cents = (int)((value % 1) * 100);
                int c0 = cents;
                int c25 = cents - 25;
                int c50 = cents - 50;
                int c75 = cents - 75;

                if (c0 < Math.Abs(c25))
                {
                    retval = value - (decimal)c0 / (decimal)100;
                }
                else if (Math.Abs(c25) < Math.Abs(c50))
                {
                    retval = value - (decimal)c25 / (decimal)100;
                }
                else if (Math.Abs(c50) < Math.Abs(c75))
                {
                    retval = value - (decimal)c50 / (decimal)100;
                }
                else
                {
                    retval = value - (decimal)c75 / (decimal)100;
                }

                decimal retvalCents = Math.Truncate((retval % 1) * 100) / 100;
                retval = Math.Truncate(retval) + retvalCents;

            }

            return retval;
        }


        public static bool IsWholeNumber(this decimal value)
        {
            return value % 1 == 0;
        }

    }
}
