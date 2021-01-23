using System;
using System.Text.RegularExpressions;

namespace RomanApp.Commons.Utils
{
    public class AmountConverter
    {
        public static decimal Convert(string number, bool greaterThanZero, int max = 1000000)
        {
            decimal retval = 0;

            string whole = null;
            string decimals = null;
            string[] parts = null;
            if (number.IndexOf(".") != -1)
            {
                parts = number.Split('.');
            }
            else if (number.IndexOf(",") != -1)
            {
                parts = number.Split(',');
            }
            else
            {
                parts = new string[] { number };
            }

            whole = parts[0].Trim();
            if (parts.Length > 1)
            {
                decimals = parts[1].Trim();
            }
            whole = whole.Replace(".", string.Empty).Replace(",", string.Empty);

            Regex numbersOnly = new Regex("^[0-9]+$");
            if (!numbersOnly.IsMatch(whole))
            {
                throw new AmountConvertionException(FailuireReason.NumberFormat);
            }

            if (whole.Length > max.ToString().Length)
            {
                if (greaterThanZero)
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeGreaterZero);
                }
                else
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeZero);
                }
            }


            if (!string.IsNullOrEmpty(decimals))
            {
                decimals = decimals.Replace(".", string.Empty).Replace(",", string.Empty);
                if (!numbersOnly.IsMatch(decimals))
                {
                    throw new AmountConvertionException(FailuireReason.NumberFormat);
                }
                if (decimals.Length > 2)
                {
                    decimals = decimals.Substring(0, 2);
                }
                if (decimals.Length == 1) 
                {
                    decimals += "0";
                }
            }

            decimal dWhole = decimal.Parse(whole);
            decimal dDecimals = 0;
            if (!string.IsNullOrEmpty(decimals))
            {
                dDecimals = decimal.Parse(decimals) / 100;
            }

            retval = dWhole + dDecimals;

            if (retval > (((decimal)max - 1) + (decimal).99))
            {
                if (greaterThanZero)
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeGreaterZero);
                }
                else
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeZero);
                }
            }

            if(retval < 0)
            {
                if (greaterThanZero)
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeGreaterZero);
                }
                else
                {
                    throw new AmountConvertionException(FailuireReason.OutOfRangeZero);
                }
            }
            else if (retval == 0 && greaterThanZero)
            {
                throw new AmountConvertionException(FailuireReason.OutOfRangeGreaterZero);
            }

            return retval;
        }
    }

    public class AmountConvertionException : Exception
    {
        public AmountConvertionException(FailuireReason reason)
        {
            Reason = reason;
        }

        #region Properties

        public FailuireReason Reason
        {
            get;
            set;
        }

        #endregion
    }

    public enum FailuireReason
    {
        NumberFormat = 0,
        OutOfRangeZero = 1,
        OutOfRangeGreaterZero = 2,
    }
}
