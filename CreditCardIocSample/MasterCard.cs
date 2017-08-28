using System.Reflection;
using CreditCardIocSample.Client;
using CreditCardIocSample.Model;
using Ninject;

namespace CreditCardIocSample
{
	public class MasterCard : IMasterCard
	{
		private readonly ICreditCardClient _creditCardClient;
		
		public MasterCard()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			_creditCardClient = kernel.Get<ICreditCardClient>();
		}

		public CustomerCardResult ChargeCard(CreditCard creditCard)
		{
			var result = _creditCardClient.SendRequest(creditCard);

			var masterCardResult = new CustomerCardResult();
			masterCardResult.CardHolderName = creditCard.CardHolderFullName;

			if (result != null)
			{
				masterCardResult.AuthCode = result.AuthorizationCode;
				masterCardResult.PaymentStatus = PaymentStatus.Approved;
				masterCardResult.ErrorMessage = string.Empty;
				masterCardResult.MaskedCardNumber = creditCard.CardNumber.Substring(11);
				masterCardResult.Token = $"{creditCard.CardHolderFullName}|{result.AuthorizationCode}|{result.TransactionId}";
			}
			else
			{
				masterCardResult.ErrorMessage = "Some Error";
				masterCardResult.PaymentStatus = PaymentStatus.Error;
				masterCardResult.Token = string.Empty;
				masterCardResult.TranscationId = string.Empty;
				masterCardResult.MaskedCardNumber = "MASTERXXXX";
			}

			return masterCardResult;
		}
	}
}