using System;

namespace CreditCardIocSample.Model
{
	public class CreditCard
	{
		public string CardNumber { get; set; }
		public int Cvv { get; set; }
		public string  CardHolderFullName { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int Amount { get; set; }
	}
}