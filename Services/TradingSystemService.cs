using System;
using Akka.Actor;
using AkkaSample.Commands;
using AkkaSample.Contracts;

namespace AkkaSample.Services
{
	internal class TradingSystemService : ITradingSystemService
	{
		private readonly IActorRef _manager;

		public TradingSystemService(IActorsFactory factory)
		{
			_manager = factory.SelectActorOf("TradeManagerActor");
		}

		public void CreateNewTrade(Guid tradeId, Guid productId, decimal amount, int position)
		{
			_manager.Tell(new CreateNewTradeCommand(tradeId, productId, amount, position), _manager);
		}

		public void ExecuteTrade(Guid tradeId)
		{
			_manager.Tell(new ExecuteTradeCommand(tradeId), _manager);
		}
	}
}