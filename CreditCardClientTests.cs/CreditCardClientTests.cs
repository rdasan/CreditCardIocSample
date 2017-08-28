using System;
using CreditCardIocSample.Client;
using CreditCardIocSample.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;

namespace CreditCardClientTests.cs
{
	[TestClass]
	public class CreditCardClientTests
	{
		private readonly MoqMockingKernel _kernel;

		public CreditCardClientTests()
		{
			_kernel = new MoqMockingKernel();
		}

		public void SetUp()
		{
			_kernel.Reset();
		}

		[TestMethod]
		public void ProperCreditCardShouldReturnSuccessResult()
		{
			// arrange
			var creditCard = new CreditCard
			{
				CardNumber = "4111222233334444",
				CardHolderFullName = "Test Tester",
				Amount = 100,
				Cvv = 123,
				ExpirationDate = new DateTime(2020, 12, 4)
			};

			var creditCardResult = new CreditCardClientResult
			{
				AuthorizationCode = 1234,
				TransactionId = "This is my result",
				CreditCard = creditCard
			};

			var creditCardClientMock = _kernel.GetMock<ICreditCardClient>();
				creditCardClientMock.Setup(mock => mock.SendRequest(It.IsAny<CreditCard>())).Returns(creditCardResult);

			var client = _kernel.Get<ICreditCardClient>();

			CreditCardClientResult clientResult = client.SendRequest(creditCard);
			
			clientResult.AuthorizationCode.Should().Be(1234);
			clientResult.TransactionId.Should().NotBeNullOrEmpty();
			clientResult.CreditCard.Should().NotBeNull();
			clientResult.CreditCard.CardNumber.Should().Be("4111222233334444");

		}
	}
}
