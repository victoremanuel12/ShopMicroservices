namespace Ordering.Domain.ValueObjects
{
    public record Address
    {

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? EmailAdress { get; set; } = default!;
        public string AdressLine { get; set; } = default!;
        public string Street { get; init; } = default!;
        public string Country { get; init; } = default!;
        public string State { get; init; } = default!;
        public string ZipCode { get; init; } = default!;
        public Address(string firstName, string lastName, string emailAdress, string adressLine, string street, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAdress;
            AdressLine = adressLine;
            Street = street;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

    }
}
