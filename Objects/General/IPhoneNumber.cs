/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace DCoreyDuke.CodeBase.Objects.General
{
    public interface IPhoneNumber
    {
        string AreaCode { get; }

        string CountryCode { get; }

        string LineNumber { get; }

        string Prefix { get; }

        PhoneNumberType Type { get; set; }

        string Value { get; }

        bool IsValidPhoneNumber(string phone);
    }

    /// <summary>
    /// Represents a Phone Number consisting of Country Code, Area Code, Prefix, Line Number
    /// </summary>
    [ComplexType, Serializable]
    public class PhoneNumber : IDisposable, IEquatable<PhoneNumber>, IPhoneNumber
    {
        private readonly RegExValidation _Val = new RegExValidation();

        public PhoneNumber(string value) : this()
        {
            if (!string.IsNullOrEmpty(value))
            {
                // strip all characters, spaces, etc, except numbers and '+'
                string cleanValue = Regex.Replace(value, "[^0-9+]", "");
                this.Value = cleanValue;
                // Convert to Char Array
                char[] cleanChars = cleanValue.ToCharArray();
                // ['+', '1', '1','2', '3', '4', '5', '6', '7', '8', '9', '0']
                if (cleanChars.Length == 12 && cleanChars[0] == '+')
                {
                    //Country Code is 2nd in Array
                    this.CountryCode = cleanChars[1].ToString().Trim();
                    // Next 3 are area code
                    this.AreaCode = new String(cleanChars, 2, 3);
                    // After Area Code is Prefix
                    this.Prefix = new string(cleanChars, 5, 3);
                    // Last 4 are Line Number
                    this.LineNumber = new string(cleanChars, 8, 4);
                }
                // ['1','2', '3', '4', '5', '6', '7', '8', '9', '0']
                else if (cleanChars.Length == 10)
                {
                    // Country Code Defaults to 1
                    this.CountryCode = "1";
                    // Area Code is first 3
                    this.AreaCode = new string(cleanChars, 0, 3);
                    // After Area Code is Prefix
                    this.Prefix = new string(cleanChars, 3, 3);
                    // Last 4 are Line Number
                    this.LineNumber = new string(cleanChars, 6, 4);
                }
                this.Type = PhoneNumberType.Default;
            }
            else
            {
                throw new ArgumentNullException("value", "Value for Phone Number Must Be Provided!");
            }
        }

        public PhoneNumber(string value, PhoneNumberType type) : this(value)
        {
            Type = type;
        }

        private PhoneNumber()
        {
        }

        public string AreaCode { get; }

        public string CountryCode { get; }

        public string LineNumber { get; }

        public string Prefix { get; }

        public PhoneNumberType Type { get; set; }

        public string Value { get; }

        #region IDisposable Support

        private bool _DisposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above. GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _DisposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PhoneNumber() { // Do not change this code. Put cleanup code in Dispose(bool disposing)
        // above. Dispose(false); }

        #endregion IDisposable Support

        public bool Equals(PhoneNumber other)
        {
            if ((this.CountryCode == other.CountryCode) &&
                (this.AreaCode == other.AreaCode) &&
                (this.Prefix == other.Prefix) &&
                (this.LineNumber == other.LineNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                return _Val.IsValid(_Val.PhoneNumber, phone);
            }
            else
            {
                throw new ArgumentNullException("phone", "Value for Phone Number Must Be Provided!");
            }
        }

        public override string ToString()
        {
            return this.Value.Trim();
        }
    }
}