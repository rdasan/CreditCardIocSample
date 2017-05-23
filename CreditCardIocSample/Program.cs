using System;
using CreditCardIocSample.Client;
using CreditCardIocSample.Model;

namespace CreditCardIocSample
{
	class Program
	{
		private static ICreditCardClient ccClient;

		static void Main(string[] args)
		{
			MasterCard masterCard = new MasterCard();
			VisaCard visaCard = new VisaCard(); 

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
				var customerResult = visaCard.ChargeCard(creditCard);
				Console.WriteLine(customerResult.ToString());
			}
			if (option == "2")
			{
				var customerResult = masterCard.ChargeCard(creditCard);
				Console.WriteLine(customerResult.ToString());
			}
			else
			{
				Console.WriteLine("\tInvalid Option");
			}
		}
	}
}
