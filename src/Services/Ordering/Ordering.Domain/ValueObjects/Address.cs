using System;
using System.Net.Mail;

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Street { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;

        protected Address() { }

        private Address(
            string firstName,
            string lastName,
            string? emailAddress,
            string addressLine,
            string street,
            string country,
            string state,
            string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Street = street;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Create(
            string firstName,
            string lastName,
            string? emailAddress,
            string addressLine,
            string street,
            string country,
            string state,
            string zipCode)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(addressLine))
                throw new ArgumentException("Address line cannot be empty.", nameof(addressLine));

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));

            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("State cannot be empty.", nameof(state));

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Zip code cannot be empty.", nameof(zipCode));

            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                if (!MailAddress.TryCreate(emailAddress, out _))
                    throw new ArgumentException("Invalid email address format.", nameof(emailAddress));
            }

            return new Address(
                firstName,
                lastName,
                emailAddress,
                addressLine,
                street,
                country,
                state,
                zipCode
            );
        }
    }
}
