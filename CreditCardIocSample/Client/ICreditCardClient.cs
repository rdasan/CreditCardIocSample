using CreditCardIocSample.Model;

namespace CreditCardIocSample.Client
{
	public interface ICreditCardClient
	{
		CreditCardClientResult SendRequest(CreditCard creditCard);
	}
}