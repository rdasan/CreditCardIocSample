namespace CreditCardIocSample.Model
{
	public class CustomerCardResult
	{
		public string TranscationId { get; set; }

		public int AuthCode { get; set; }

		public string ErrorMessage { get; set; }

		public string MaskedCardNumber { get; set; }

		public string Token { get; set; }

		public PaymentStatus PaymentStatus { get; set; }

		public string CardHolderName { get; set; }
	}
}
