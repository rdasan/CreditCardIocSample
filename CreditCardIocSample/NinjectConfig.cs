using CreditCardIocSample;
using CreditCardIocSample.Client;
using Ninject.Modules;

public class NinjectConfig : NinjectModule
{
	public override void Load()
	{
		Bind<ICreditCardClient>().To<CreditCardClient>();
	}
}