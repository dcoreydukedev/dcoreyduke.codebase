/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.KeyGenerators
{
    public class Randoms
    {
        private static readonly StringKeyGenerator _StringKeyGenerator = new StringKeyGenerator();

        static Randoms()
        {
        }

        public static char GetRandomDigit()
        {
            return (char)_StringKeyGenerator.GetRandomDigit();
        }

        public static char GetRandomLetter()
        {
            return _StringKeyGenerator.GetRandomLetter();
        }

        /// <summary>
        /// Get A Random Number Between 1 and 10
        /// </summary>
        /// <returns>Random Number Between 1 and 10</returns>
        public static int GetRandomNumber()
        {
            return _StringKeyGenerator.GetRandomDigit();
        }

        public static char GetRandomSpecialCharacter()
        {
            return _StringKeyGenerator.GetRandomSpecialCharacter();
        }
    }
}