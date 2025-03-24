/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using DCoreyDuke.CodeBase.Interfaces;

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    public interface IName : IValueObject
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
            Prefix = string.Empty; Suffix = string.Empty;
            First = first; Middle = string.Empty; Last = last;
        }

        public Name(string first, string middle, string last)
        {
            Prefix = string.Empty; Suffix = string.Empty;
            First = first; Middle = middle; Last = last;
        }

        public Name(string prefix, string first, string middle, string last)
        {
            Prefix = prefix; Suffix = string.Empty;
            First = first; Middle = middle; Last = last;
        }

        public Name(string prefix, string first, string middle, string last, string suffix)
        {
            Prefix = prefix; Suffix = suffix;
            First = first; Middle = middle; Last = last;
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
                Prefix = string.Empty; Suffix = string.Empty;
                First = val[0]; Middle = val[1]; Last = val[2];
            }
            // Prefix, First, Middle, Last, Suffix
            if (val.Length == 5)
            {
                Prefix = val[0]; Suffix = val[4];
                First = val[1]; Middle = val[2]; Last = val[3];
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
                    Prefix = string.Empty; Suffix = string.Empty;
                    First = str[0]; Middle = string.Empty; Last = str[1];
                }
                else if (str.Length == 3)
                {
                    Prefix = string.Empty; Suffix = string.Empty;
                    First = str[0]; Middle = str[1]; Last = str[2];
                }
                else if (str.Length == 4) // Assume prefix
                {
                    Prefix = str[0]; Suffix = string.Empty;
                    First = str[1]; Middle = str[2]; Last = str[3];
                }
                else if (str.Length == 5)
                {
                    Prefix = str[0]; Suffix = str[4];
                    First = str[1]; Middle = str[2]; Last = str[3];
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
            return string.Compare(ToString(), n.ToString());
        }

        public bool Equals(Name other)
        {
            return new NamesAreSame().Equals(this, other);
        }

        public override int GetHashCode()
        {
            int hCode = ToString().Length + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }

        public string GetInitials(bool includePeriods, bool allCaps)
        {
            StringBuilder str = new StringBuilder();

            if (includePeriods == true)
            {
                // Include M.I.
                if (!string.IsNullOrEmpty(Middle))
                {
                    str.AppendFormat("{0}.{1}.{2}.", First.ToCharArray()[0], Middle.ToCharArray()[0], Last.ToCharArray()[0]);
                }
                else
                {
                    str.AppendFormat("{0}.{1}.", First.ToCharArray()[0], Last.ToCharArray()[0]);
                }
            }
            else
            {
                // Include M.I.
                if (!string.IsNullOrEmpty(Middle))
                {
                    str.AppendFormat("{0}{1}{2}.", First.ToCharArray()[0], Middle.ToCharArray()[0], Last.ToCharArray()[0]);
                }
                else
                {
                    str.AppendFormat("{0}{1}.", First.ToCharArray()[0], Last.ToCharArray()[0]);
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
                if (!string.IsNullOrEmpty(Prefix))
                {
                    sb.Append(FirstLetterCapital(Prefix));
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(First)))
                {
                    sb.Append(First);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(Middle)))
                {
                    sb.Append(Middle);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(Last)))
                {
                    sb.Append(Last);
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(Suffix)))
                {
                    sb.Append(" ");
                    sb.Append(Suffix);
                }
            }
            else if (nameFormat == NameFormat.LastNameFirst)
            {
                if (!string.IsNullOrEmpty(Prefix))
                {
                    sb.Append(FirstLetterCapital(Prefix));
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(Last)))
                {
                    sb.Append(Last);
                    sb.Append(", ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(First)))
                {
                    sb.Append(First);
                    sb.Append(" ");
                }
                if (!string.IsNullOrEmpty(FirstLetterCapital(Middle)))
                {
                    sb.Append(Middle);
                    sb.Append(" ");
                }

                if (!string.IsNullOrEmpty(FirstLetterCapital(Suffix)))
                {
                    sb.Append(" ");
                    sb.Append(Suffix);
                }
            }

            return sb.ToString().Trim();
        }

        public int Length()
        {
            return Prefix.Length + First.Length + Middle.Length + Last.Length + Suffix.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Prefix))
            {
                sb.Append(Prefix + " ");
            }
            if (!string.IsNullOrEmpty(First))
            {
                sb.Append(First + " ");
            }
            if (!string.IsNullOrEmpty(Middle))
            {
                sb.Append(Middle + " ");
            }
            if (!string.IsNullOrEmpty(Last))
            {
                sb.Append(Last + " ");
            }
            if (!string.IsNullOrEmpty(Suffix))
            {
                sb.Append(Suffix);
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
            return string.Compare(n1.Last, n2.Last);
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
            return string.Compare(x.Prefix, y.Prefix) == 0 &&
                    string.Compare(x.First, y.First) == 0 &&
                    string.Compare(x.Middle, y.Middle) == 0 &&
                    string.Compare(x.Last, y.Last) == 0 &&
                    string.Compare(x.Suffix, y.Suffix) == 0;
        }

        public int GetHashCode(Name obj)
        {
            int hCode = obj.Length() + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }
    }
}