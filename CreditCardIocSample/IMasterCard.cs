using CreditCardIocSample.Model;

namespace CreditCardIocSample
{
	public interface IMasterCard
	{
		CustomerCardResult ChargeCard(CreditCard creditCard);
	}
}