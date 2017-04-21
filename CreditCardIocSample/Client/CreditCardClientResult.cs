using CreditCardIocSample.Model;

namespace CreditCardIocSample.Client
{
	public class CreditCardClientResult
	{
		public string TransactionId { get; set; }	

		public int AuthorizationCode { get; set; }

		public CreditCard CreditCard { get; set; }
	}
}
