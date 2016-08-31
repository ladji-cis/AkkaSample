using System;
using Akka.Actor;
using AkkaSample.Commands;
using AkkaSample.Contracts;

namespace AkkaSample.Actors.Handlers
{
	public class TradeCommandsHandlerActor : TypedActor,
		IHandle<CreateNewTradeCommand>,
		IHandle<ExecuteTradeCommand>
	{
		private readonly ITradingSystemService _tradingSystemService;

		public TradeCommandsHandlerActor(IActorsFactory factory, ITradingSystemService tradingSystemService)
		{
			_tradingSystemService = tradingSystemService;
		}

		public void Handle(CreateNewTradeCommand message)
		{
			_tradingSystemService.CreateNewTrade(message.TradeId, message.ProductId, message.Amount, message.Position);
			Console.WriteLine("Handled TradeCommand :" + message.TradeId);
		}

		public void Handle(ExecuteTradeCommand message)
		{
			_tradingSystemService.ExecuteTrade(message.TradeId);
			Console.WriteLine("Handled : ExecuteTradeCommand");
		}
	}
}
