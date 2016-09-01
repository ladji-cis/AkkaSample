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

			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 10m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 11m, 2);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 12m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 13m, 2);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 14m, 1);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 15m, 2);
			service.CreateNewTrade(Guid.NewGuid(), Guid.NewGuid(), 16m, 1);

			Console.ReadLine();

			boot.Dispose();
		}
	}
}
