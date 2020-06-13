/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Objects.General
{
    public interface IEmailAddress
    {
        char At { get; }

        string Domain { get; }

        EmailAddressType Type { get; set; }

        string Username { get; }

        string Value { get; }

        bool IsValidEmailAddress(string email);
    }

    /// <summary> Represents an Email Address's 3 components username@domain.com 1.)Username 2.) @
    /// Symbol 3.) Domain (Mail Server & Top Level Domain) </summary> <remarks> 2 Custom Sort
    /// Comparers Exist for this class </remarks>
    [ComplexType, Serializable]
    public class EmailAddress : IEquatable<EmailAddress>, IEmailAddress, IComparable
    {
        private readonly RegExValidation _Val = new RegExValidation();

        public EmailAddress(string value) : this()
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (_Val.IsValid(_Val.EmailAddress, value))
                {
                    var str = value.Split('@');
                    this.Username = str[0];
                    this.Domain = str[1];
                    this.Value = value;
                    this.Type = EmailAddressType.Default;
                }
                else
                {
                    throw new ArgumentException("value", "Email must be in correct format!");
                }
            }
            else
            {
                throw new ArgumentNullException("value", "Value for Email Must Be Provided!");
            }
        }

        public EmailAddress(string value, EmailAddressType type) : this(value)
        {
            this.Type = type;
        }

        private EmailAddress()
        {
        }

        public char At { get; } = '@';

        public string Domain { get; }

        public EmailAddressType Type { get; set; }

        public string Username { get; }

        public string Value { get; }

        public int CompareTo(object obj)
        {
            EmailAddress e = (EmailAddress)obj;
            return String.Compare(this.ToString(), e.ToString());
        }

        public bool Equals(EmailAddress other)
        {
            return new EmailsAdderssesAreSame().Equals(this, other);
        }

        public override int GetHashCode()
        {
            int hCode = this.ToString().Length + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }

        public bool IsValidEmailAddress(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return _Val.IsValid(_Val.EmailAddress, email);
            }
            else
            {
                throw new ArgumentNullException("Value", "Value for Email Must Be Provided!");
            }
        }

        public override string ToString()
        {
            return this.Value;
        }
    }

    /// <summary>
    /// Custom Comparer to Sort By Domain
    /// </summary>
    public class SortEmailAddressesByDomain : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            EmailAddress e1 = (EmailAddress)a;
            EmailAddress e2 = (EmailAddress)b;
            return String.Compare(e1.Domain, e2.Domain);
        }
    }

    /// <summary>
    /// Custom Comparer to Sort By Username
    /// </summary>
    public class SortEmailAddressesByUsername : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            EmailAddress e1 = (EmailAddress)a;
            EmailAddress e2 = (EmailAddress)b;
            return String.Compare(e1.Username, e2.Username);
        }
    }

    /// <summary>
    /// Defines 2 EmailAddresses as the Same if the Value strings are equal
    /// </summary>
    internal class EmailsAdderssesAreSame : IEqualityComparer<EmailAddress>
    {
        public bool Equals(EmailAddress x, EmailAddress y)
        {
            return (String.Compare(x.Value, y.Value) == 0);
        }

        public int GetHashCode(EmailAddress obj)
        {
            int hCode = obj.Value.Length + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }
    }
}