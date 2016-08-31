using System;
using AkkaSample.Contracts;
using Autofac;

namespace AkkaSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var boot = new Bootstrapper();

			var service = Bootstrapper.Container.Resolve<ITradingSystemService>();

			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 50m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 63m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 99m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 78m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 25m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 28m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 73m, 1);

			Console.ReadLine();

			boot.Dispose();
		}
	}
}
