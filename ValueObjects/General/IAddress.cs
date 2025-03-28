﻿/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DCoreyDuke.CodeBase.Attributes;
using DCoreyDuke.CodeBase.Interfaces;

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    public interface IAddress : IValueObject
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
        private State? _state = ValueObjects.State.Unknown;
        private Country? _country = ValueObjects.Country.US;

        public Address(string address1, string city, State state, string postalCode) : this()
        {
            _address1 = address1;
            _city = city;
            _state = state;
            _postalCode = postalCode;

        }

        public Address(string address1, string city, State state, string postalCode, AddressType type) : this()
        {
            _address1 = address1;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _type = type;

        }
        public Address(string address1, string number, string city, State state, string postalCode, AddressType type) : this()
        {
            _address1 = address1;
            _number = number;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _type = type;

        }

        public Address(string address1, string address2, string number, string city, State state, string postalCode) : this()
        {
            _address1 = address1;
            _address2 = address2;
            _number = number;
            _city = city;
            _state = state;
            _postalCode = postalCode;

        }

        public Address(string address1, string address2, string number, string city, State state, string PostalCode, AddressType type) :
            this(address1, address2, number, city, state, PostalCode)
        {
            Type = type;
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

            if (!string.IsNullOrEmpty(Address1)) sb.AppendLine(Address1);
            if (!string.IsNullOrEmpty(Address2)) sb.AppendLine(Address2);
            if (!string.IsNullOrEmpty(Number)) sb.AppendLine("#: " + Number);
            if (!string.IsNullOrEmpty(Region)) sb.AppendLine("Region: " + Region);
            if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State.ToString()) && !string.IsNullOrEmpty(PostalCode) && !string.IsNullOrEmpty(Country.ToString()))
                sb.AppendLine(City + ", " + State.ToString() + "  " + PostalCode + "  " + Country.ToString());

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