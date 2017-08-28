using System;
using System.Threading;
using CreditCardIocSample.Model;

namespace CreditCardIocSample.Client
{
	public class CreditCardClient : ICreditCardClient
	{
		public CreditCardClientResult SendRequest(CreditCard creditCard)
		{
			//assuming this method is sending requests to an external third 
			//party library which is doing some intensive processing.
			//Faking the "Intensive Processing" with a time delay
			Console.WriteLine("Sleeping");

			Thread.Sleep(20000);
			
			return new CreditCardClientResult
			{
				AuthorizationCode = 1234,
				TransactionId = "eyfg7fgiuewhfghjfehfy",
				CreditCard = creditCard
			};
		}
	}
}
