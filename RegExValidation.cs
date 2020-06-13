/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase
{
    public class RegExValidation
    {
        private readonly string _PostalCode_US = @"\d{5}([ \-]\d{4})?";
        private readonly string _PhoneNumber = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        private readonly string _EmailAddress = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        private readonly string _Username1 = @"/^[a-z0-9_-]{3,16}$/";
        private readonly string _Password1 = @"/^[a-z0-9_-]{6,18}$/";
        private readonly string _HexNumber = @"/^#?([a-f0-9]{6}|[a-f0-9]{3})$/";
        private readonly string _URL = @"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/";
        private readonly string _IpAddress = @"/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/";

        public RegExValidation() { }

        /// <summary>
        /// 12345(-6789)
        /// </summary>
        public string PostalCode_US => _PostalCode_US;
        /// <summary>
        /// (123)456-7890
        /// </summary>
        public string PhoneNumber => _PhoneNumber;
        /// <summary>
        /// user@domain.ext
        /// </summary>
        public string EmailAddress => _EmailAddress;
        /// <summary>
        /// We begin by telling the parser to find the beginning of the string (^), followed by any lowercase letter (a-z), number (0-9), an underscore, or a hyphen. Next, {3,16} makes sure that are at least 3 of those characters, but no more than 16. Finally, we want the end of the string ($).
        /// </summary>
        public string Username1 => _Username1;
        /// <summary>
        /// Matching a password is very similar to matching a username. The only difference is that instead of 3 to 16 letters, numbers, underscores, or hyphens, we want 6 to 18 of them ({6,18}).
        /// </summary>
        public string Password1 => _Password1;
        /// <summary>
        /// ex: #ffffff
        /// </summary>
        public string HexNumber => _HexNumber;
        /// <summary>
        /// http(s)//:xxx.domain.com/xxxx
        /// </summary>
        public string URL => _URL;
        /// <summary>
        /// IP v4 Address
        /// </summary>
        public string IpAddress => _IpAddress;



        /// <summary>
        /// Test if Value matches Pattern
        /// </summary>
        /// <param name="pattern">Pattern Name</param>
        /// <param name="value">Value To Test</param>
        /// <returns>True: Value Matches Pattern | False: No Match </returns>
        public bool IsValid(string pattern, string value)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }



    }
}
