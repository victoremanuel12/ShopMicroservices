using System.Net.Mail;

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Street { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;

        protected Address() { }

        private Address(
            string firstName,
            string lastName,
            string emailAddress,
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
            string emailAddress,
            string addressLine,
            string street,
            string country,
            string state,
            string zipCode)
        {
            ValidateRequired(firstName, nameof(firstName));
            ValidateRequired(lastName, nameof(lastName));
            ValidateRequired(addressLine, nameof(addressLine));
            ValidateRequired(street, nameof(street));
            ValidateRequired(country, nameof(country));
            ValidateRequired(state, nameof(state));
            ValidateRequired(zipCode, nameof(zipCode));

            if (string.IsNullOrWhiteSpace(emailAddress) &&
                !MailAddress.TryCreate(emailAddress, out _))
            {
                throw new InvalidEmailException(emailAddress);
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

        private static void ValidateRequired(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new RequiredFieldException(fieldName);
        }
    }
}
