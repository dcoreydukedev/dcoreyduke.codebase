/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DCoreyDuke.CodeBase.Attributes;

namespace DCoreyDuke.CodeBase.Objects.General
{
    public interface IAddress
    {
        string? Address1 { get; set; }
        string? Address2 { get; set; }
        string? City { get; set; }
        Country? Country { get; set; }
        string? Number { get; set; }
        string? PostalCode { get; set; }
        string? Region { get; set; }
        State? State { get; set; }
        AddressType? Type { get; set; }
    }

    [ComplexType, Serializable, Verifyable]
    public class Address : IEquatable<Address>, IComparable<Address>, IAddress
    {

        private string? _address1 = string.Empty, _address2 = string.Empty, _number = string.Empty, _city = string.Empty, _region = string.Empty, _postalCode = string.Empty;
        private AddressType? _type = AddressType.Default;
        private State? _state = Objects.State.Unknown;
        private Country? _country = Objects.Country.US;

        public Address(string address1, string city, State state, string postalCode) : this()
        {
            this._address1 = address1;
            this._city = city;
            this._state = state;
            this._postalCode = postalCode;

        }

        public Address(string address1, string city, State state, string postalCode, AddressType type) : this()
        {
            this._address1 = address1;
            this._city = city;
            this._state = state;
            this._postalCode = postalCode;
            this._type = type;

        }
        public Address(string address1, string number, string city, State state, string postalCode, AddressType type) : this()
        {
            this._address1 = address1;
            this._number = number;
            this._city = city;
            this._state = state;
            this._postalCode = postalCode;
            this._type = type;

        }

        public Address(string address1, string address2, string number, string city, State state, string postalCode) : this()
        {
            this._address1 = address1;
            this._address2 = address2;
            this._number = number;
            this._city = city;
            this._state = state;
            this._postalCode = postalCode;

        }

        public Address(string address1, string address2, string number, string city, State state, string PostalCode, AddressType type) :
            this(address1, address2, number, city, state, PostalCode)
        {
            this.Type = type;
        }

        private Address()
        {
            //Private Default Constructor
        }

        public AddressType? Type { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public State? State { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public Country? Country { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(this.Address1)) sb.AppendLine(this.Address1);
            if (!string.IsNullOrEmpty(this.Address2)) sb.AppendLine(this.Address2);
            if (!string.IsNullOrEmpty(this.Number)) sb.AppendLine("#: " + this.Number);
            if (!string.IsNullOrEmpty(this.Region)) sb.AppendLine("Region: " + this.Region);
            if (!string.IsNullOrEmpty(this.City) && !string.IsNullOrEmpty(this.State.ToString()) && !string.IsNullOrEmpty(this.PostalCode) && !string.IsNullOrEmpty(this.Country.ToString()))
                sb.AppendLine(this.City + ", " + this.State.ToString() + "  " + this.PostalCode + "  " + this.Country.ToString());

            return sb.ToString();
        }

        public bool Equals(Address other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other", "other address cannot be null");
            }
            else if (other == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Address other)
        {
            if (other == null)
            {
                return -1;
            }
            else if (other == this)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

}