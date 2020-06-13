/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Objects.General
{
    public interface IName
    {
        string First { get; }

        string Last { get; }

        string Middle { get; }

        string Prefix { get; }

        string Suffix { get; }
    }

    /// <summary>
    /// Defines a Person's Name
    /// </summary>
    /// <remarks>A Custom Sort Comparer Exists for this Class</remarks>
    [ComplexType, Serializable]
    public sealed class Name : IEquatable<Name>, IName, IComparable
    {
        public Name(string first, string last)
        {
            this.Prefix = string.Empty; this.Suffix = string.Empty;
            this.First = first; this.Middle = string.Empty; this.Last = last;
        }

        public Name(string first, string middle, string last)
        {
            this.Prefix = string.Empty; this.Suffix = string.Empty;
            this.First = first; this.Middle = middle; this.Last = last;
        }

        public Name(string prefix, string first, string middle, string last)
        {
            this.Prefix = prefix; this.Suffix = string.Empty;
            this.First = first; this.Middle = middle; this.Last = last;
        }

        public Name(string prefix, string first, string middle, string last, string suffix)
        {
            this.Prefix = prefix; this.Suffix = suffix;
            this.First = first; this.Middle = middle; this.Last = last;
        }

        /// <summary>
        /// Construct Name Object from Array of Strings
        /// </summary>
        /// <param name="val">
        /// Option 1.) ["First", "Middle", "Last"] | Option 2.) ["Prefix", "First", "Middle",
        /// "Last", "Suffix"]
        /// **Use string.Empty for n/a value
        /// </param>
        public Name(string[] val)
        {
            if (val.Length < 3)
            {
                throw new Exception("Value Array Must Contain at Least First, MMiddle, and Last Name Values! Use string.empty if n/a.");
            }
            if (val.Length > 5)
            {
                throw new Exception("Value array Must Not Contain More Than 5 Elements!");
            }
            // First, Middle, Last
            if (val.Length == 3)
            {
                this.Prefix = string.Empty; this.Suffix = string.Empty;
                this.First = val[0]; this.Middle = val[1]; this.Last = val[2];
            }
            // Prefix, First, Middle, Last, Suffix
            if (val.Length == 5)
            {
                this.Prefix = val[0]; this.Suffix = val[4];
                this.First = val[1]; this.Middle = val[2]; this.Last = val[3];
            }
        }

        /// <summary>
        /// Create A Name Object By Splitting A Display Name String
        /// ex: John D. Doe | Peter Smith | Dr. John K. Smith Sr.
        /// </summary>
        public Name(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var str = value.Split(' ');
                if (str.Length == 2)
                {
                    this.Prefix = string.Empty; this.Suffix = string.Empty;
                    this.First = str[0]; this.Middle = string.Empty; this.Last = str[1];
                }
                else if (str.Length == 3)
                {
                    this.Prefix = string.Empty; this.Suffix = string.Empty;
                    this.First = str[0]; this.Middle = str[1]; this.Last = str[2];
                }
                else if (str.Length == 4) // Assume prefix
                {
                    this.Prefix = str[0]; this.Suffix = string.Empty;
                    this.First = str[1]; this.Middle = str[2]; this.Last = str[3];
                }
                else if (str.Length == 5)
                {
                    this.Prefix = str[0]; this.Suffix = str[4];
                    this.First = str[1]; this.Middle = str[2]; this.Last = str[3];
                }
            }
            else
            {
                throw new ArgumentNullException("value", "A String Containing a Name must be provided!");
            }
        }

        [Required(ErrorMessage = "First Name is required"), StringLength(256, MinimumLength = 1, ErrorMessage = "First Name MUST be between 1 and 256 Chars.")]
        public string First { get; }

        [Required(ErrorMessage = "Last Name is required"), StringLength(256, MinimumLength = 1, ErrorMessage = "Last Name MUST be between 1 and 256 Chars.")]
        public string Last { get; }

        public string Middle { get; }

        public string Prefix { get; }

        public string Suffix { get; }

        public int CompareTo(object obj)
        {
            Name n = (Name)obj;
            return String.Compare(this.ToString(), n.ToString());
        }

        public bool Equals(Name other)
        {
            return new NamesAreSame().Equals(this, other);
        }

        public override int GetHashCode()
        {
            int hCode = this.ToString().Length + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }

        public string GetInitials(bool includePeriods, bool allCaps)
        {
            StringBuilder str = new StringBuilder();

            if (includePeriods == true)
            {
                // Include M.I.
                if (!string.IsNullOrEmpty(this.Middle))
                {
                    str.AppendFormat("{0}.{1}.{2}.", this.First.ToCharArray()[0], this.Middle.ToCharArray()[0], this.Last.ToCharArray()[0]);
                }
                else
                {
                    str.AppendFormat("{0}.{1}.", this.First.ToCharArray()[0], this.Last.ToCharArray()[0]);
                }
            }
            else
            {
                // Include M.I.
                if (!string.IsNullOrEmpty(this.Middle))
                {
                    str.AppendFormat("{0}{1}{2}.", this.First.ToCharArray()[0], this.Middle.ToCharArray()[0], this.Last.ToCharArray()[0]);
                }
                else
                {
                    str.AppendFormat("{0}{1}.", this.First.ToCharArray()[0], this.Last.ToCharArray()[0]);
                }
            }

            if (allCaps) return str.ToString().Trim().ToUpper();
            else return str.ToString().Trim().ToLower();
        }

        public string GetName(NameFormat nameFormat)
        {
            StringBuilder sb = new StringBuilder();

            if (nameFormat == NameFormat.FirstNameFirst)
            {
                if (!string.IsNullOrEmpty(this.Prefix))
                {
                    sb.Append(this.FirstLetterCapital(this.Prefix));
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.First)))
                {
                    sb.Append(this.First);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Middle)))
                {
                    sb.Append(this.Middle);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Last)))
                {
                    sb.Append(this.Last);
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Suffix)))
                {
                    sb.Append(" ");
                    sb.Append(this.Suffix);
                }
            }
            else if (nameFormat == NameFormat.LastNameFirst)
            {
                if (!string.IsNullOrEmpty(this.Prefix))
                {
                    sb.Append(this.FirstLetterCapital(this.Prefix));
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Last)))
                {
                    sb.Append(this.Last);
                    sb.Append(", ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.First)))
                {
                    sb.Append(this.First);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Middle)))
                {
                    sb.Append(this.Middle);
                    sb.Append(" ");
                }

                if (!string.IsNullOrEmpty(this.FirstLetterCapital(this.Suffix)))
                {
                    sb.Append(" ");
                    sb.Append(this.Suffix);
                }
            }

            return sb.ToString().Trim();
        }

        public int Length()
        {
            return (this.Prefix.Length + this.First.Length + this.Middle.Length + this.Last.Length + this.Suffix.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(this.Prefix))
            {
                sb.Append(this.Prefix + " ");
            }
            if (!string.IsNullOrEmpty(this.First))
            {
                sb.Append(this.First + " ");
            }
            if (!string.IsNullOrEmpty(this.Middle))
            {
                sb.Append(this.Middle + " ");
            }
            if (!string.IsNullOrEmpty(this.Last))
            {
                sb.Append(this.Last + " ");
            }
            if (!string.IsNullOrEmpty(this.Suffix))
            {
                sb.Append(this.Suffix);
            }
            return sb.ToString().Trim();
        }

        private string FirstLetterCapital(string str)
        {
            if (str.Length > 1) return char.ToUpper(str[0]) + str.Substring(1).ToLower();
            else return char.ToUpper(str[0]).ToString();
        }
    }

    /// <summary>
    /// Custom Comparer to Sort By Last Name
    /// </summary>
    public class SortNamesByLastName : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Name n1 = (Name)a;
            Name n2 = (Name)b;
            return String.Compare(n1.Last, n2.Last);
        }
    }

    /// <summary>
    /// Defines 2 Names as Equal if they both contain the same string values
    /// </summary>
    internal class NamesAreSame : IEqualityComparer<Name>
    {
        public bool Equals(Name x, Name y)
        {
            // String.Compare(x, y) returns 0 if both strings are the same
            return ((String.Compare(x.Prefix, y.Prefix) == 0) &&
                    (String.Compare(x.First, y.First) == 0) &&
                    (String.Compare(x.Middle, y.Middle) == 0) &&
                    (String.Compare(x.Last, y.Last) == 0) &&
                    (String.Compare(x.Suffix, y.Suffix) == 0));
        }

        public int GetHashCode(Name obj)
        {
            int hCode = obj.Length() + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }
    }
}