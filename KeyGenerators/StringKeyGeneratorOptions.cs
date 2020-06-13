/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.KeyGenerators
{
    /// <summary>
    /// Options for String Key Generator
    /// </summary>
    public sealed class StringKeyGeneratorOptions
    {
        /// <summary>
        /// Defaults:
        /// Length: 12
        /// Caps: false
        /// Numbers: true
        /// SpecialChars: false
        /// </summary>
        public StringKeyGeneratorOptions()
        {
            this.Length = 12;
            this.IncludeCaps = false;
            this.IncludeDigits = true;
            this.IncludeSpecialChars = false;
        }

        /// <summary>
        /// Include Upper Case Letters
        /// </summary>
        public bool IncludeCaps { get; set; }

        /// <summary>
        /// Include Digits 1-9
        /// </summary>
        public bool IncludeDigits { get; set; }

        /// <summary> Include ['#', '$', '@', '*', '&', '%', '!', '^', '/', '+', '-'] </summary>
        public bool IncludeSpecialChars { get; set; }

        /// <summary>
        /// The Total Length of the String Key To Be Returned
        /// </summary>
        public int Length { get; set; }

        public override string ToString()
        {
            return String.Format("Length: {0}, Caps: {1}, Numbers: {2}, Chars: {3}",
                         this.Length.ToString(),
                         this.IncludeCaps.ToString(),
                         this.IncludeDigits.ToString(),
                         this.IncludeSpecialChars.ToString()
                     );
        }
    }
}