﻿using Ardalis.GuardClauses;

namespace Swiftrade.Core.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; private set; }
        private PhoneNumber() { }
        public PhoneNumber(string number)
        {

            Guard.Against.NullOrWhiteSpace(number, nameof(number));

            Value = number;
        }

    }
}
