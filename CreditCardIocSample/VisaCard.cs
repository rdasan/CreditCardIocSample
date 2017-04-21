using CreditCardIocSample.Client;
using CreditCardIocSample.Model;

namespace CreditCardIocSample
{
	public class VisaCard
	{
		private readonly CreditCardClient _creditCardClient;

		public VisaCard()
		{
			_creditCardClient = new CreditCardClient();
		}

		public CustomerCardResult ChargeCard(CreditCard creditCard)
		{
			var result = _creditCardClient.SendRequest(creditCard);

			var visaCardResult = new CustomerCardResult();
			visaCardResult.CardHolderName = creditCard.CardHolderFullName;

			if (result != null)
			{
				visaCardResult.AuthCode = result.AuthorizationCode;
				visaCardResult.PaymentStatus = PaymentStatus.Approved;
				visaCardResult.ErrorMessage = string.Empty;
				visaCardResult.MaskedCardNumber = creditCard.CardNumber.Substring(11);
				visaCardResult.Token = $"{result.AuthorizationCode}|{result.TransactionId}";
			}
			else
			{
				visaCardResult.ErrorMessage = "Some Error";
				visaCardResult.PaymentStatus = PaymentStatus.Error;
				visaCardResult.Token = string.Empty;
				visaCardResult.TranscationId = string.Empty;
				visaCardResult.MaskedCardNumber = "VISAXXXX";
			}

			return visaCardResult;
		}
	}
}
