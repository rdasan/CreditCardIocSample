using System;
using CreditCardIocSample.Model;

namespace CreditCardIocSample
{
	class Program
	{

		static void Main(string[] args)
		{
			var creditCard = new CreditCard
			{
				CardNumber = "4111222233334444",
				CardHolderFullName = "Test Tester",
				Amount = 100,
				Cvv = 123,
				ExpirationDate = new DateTime(2020, 12, 4)
			};

			Console.WriteLine("\tEnter '1' for Visa Card\n\tEnter '2' for MasterCard");

			var option = Console.ReadLine();
			if (option == "1")
			{
			// var customerResult = _visaCard.ChargeCard(creditCard);
			}
			if (option == "2")
			{
				var masterCard = new MasterCard();
				var customerResult = masterCard.ChargeCard(creditCard);
			}
			else
			{
				Console.WriteLine("\tInvalid Option");
			}
		}
	}
}
