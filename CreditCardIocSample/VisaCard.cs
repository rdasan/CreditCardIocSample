using System.Reflection;
using CreditCardIocSample.Client;
using CreditCardIocSample.Model;
using Ninject;

namespace CreditCardIocSample
{
	public class VisaCard
	{
		private readonly ICreditCardClient _creditCardClient;

		public VisaCard()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			_creditCardClient = kernel.Get<ICreditCardClient>();
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
