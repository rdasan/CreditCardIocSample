using CreditCardIocSample.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			_kernel.Bind<ICreditCardClient>().To<CreditCardClient>();
		}

		[TestMethod]
		public void NullCreditCardShouldFail()
		{
			// arrange
			var creditCardClientMock = _kernel.GetMock<ICreditCardClient>();
			
		}
	}
}
