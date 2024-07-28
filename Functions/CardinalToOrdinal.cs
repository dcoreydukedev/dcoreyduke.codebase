using System;
using System.Collections.Generic;
using System.Text;

namespace DCoreyDuke.CodeBase.Functions
{
    public static partial class Functions
    {

        /// <summary>
        /// a function  that converts a cardinal  int value into an ordinal string value; for example, it converts 1 into 1st, 2 into 2nd, and so on
        /// </summary>
        public static string CardinalToOrdinal(int number)
        {
            int lastTwoDigits = number % 100;
            switch (lastTwoDigits)
            {
                case 11: // special cases for 11th to 13th
                case 12:
                case 13:
                    return $"{number:N0}th";
                default:
                    int lastDigit = number % 10;
                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{number:N0}{suffix}";
            }
        }

        public static List<string> CardinalToOrdinal(int start, int end)
        {
            List<string> _l = new List<string>();
            for (int i = start; i < end; i++)
            {
                _l.Add(CardinalToOrdinal(i));

            }

            return _l;
        }
    }
}
