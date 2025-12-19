using System.Net.Mail;

namespace Ordering.Domain.Models
{
    public class Customer : Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public static Customer Create(CustomerId id, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new RequiredFieldException(name);
            if (!MailAddress.TryCreate(email, out _))
                throw new InvalidEmailException(email);

            var custumer = new Customer
            {
                Id = id,
                Name = name,
                Email = email
            };
            return custumer;
        }
    }
}
