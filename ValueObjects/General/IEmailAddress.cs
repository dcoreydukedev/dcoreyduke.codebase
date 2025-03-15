/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.Interfaces;

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    public interface IEmailAddress : IValueObject
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
                    Username = str[0];
                    Domain = str[1];
                    Value = value;
                    Type = EmailAddressType.Default;
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
            Type = type;
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
            return string.Compare(ToString(), e.ToString());
        }

        public bool Equals(EmailAddress other)
        {
            return new EmailsAdderssesAreSame().Equals(this, other);
        }

        public override int GetHashCode()
        {
            int hCode = ToString().Length + RandomNumberGenerator.Uniform(1, 100);
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
            return Value;
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
            return string.Compare(e1.Domain, e2.Domain);
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
            return string.Compare(e1.Username, e2.Username);
        }
    }

    /// <summary>
    /// Defines 2 EmailAddresses as the Same if the Value strings are equal
    /// </summary>
    internal class EmailsAdderssesAreSame : IEqualityComparer<EmailAddress>
    {
        public bool Equals(EmailAddress x, EmailAddress y)
        {
            return string.Compare(x.Value, y.Value) == 0;
        }

        public int GetHashCode(EmailAddress obj)
        {
            int hCode = obj.Value.Length + RandomNumberGenerator.Uniform(1, 100);
            return hCode.GetHashCode();
        }
    }
}