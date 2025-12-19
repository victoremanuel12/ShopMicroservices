namespace Ordering.Domain.ValueObjects
{
    public class Payment
    {
        private const int CardNumberLength = 16;
        private const int CVVLength = 3;
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public string PaymentMethod { get; } = default!;
        protected Payment(){}

        private Payment(
            string? cardName,
            string cardNumber,
            string expiration,
            string cvv,
            string paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }
        public static Payment Create(
            string? cardName,
            string cardNumber,
            string expiration,
            string cvv,
            string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) 
                || cardNumber.Length != CardNumberLength 
                || !long.TryParse(cardNumber, out _))
                throw new InvalidCardNumberException(cardNumber);

            if (string.IsNullOrWhiteSpace(expiration))
                throw new InvalidExpirationException(expiration);

            if (string.IsNullOrWhiteSpace(cvv) 
                || cvv.Length != CVVLength 
                || !int.TryParse(cvv, out _))
                throw new InvalidCVVException(CVVLength,cvv);

            if (string.IsNullOrWhiteSpace(paymentMethod))
                throw new RequiredFieldException(paymentMethod);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }
    }
}
