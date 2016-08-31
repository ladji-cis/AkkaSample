using System;
using AkkaSample.Commands;
using AkkaSample.Contracts;
using AkkaSample.Domains.Aggregates;

namespace AkkaSample.Actors.Managers
{
	public class TradeManagerActor : AbstractReceiveActor
	{
		private readonly IRepository _repository;

		public TradeManagerActor(IActorsFactory factory, IRepository repository) : base(factory)
		{
			_repository = repository;
		}

		protected override string NextActorName => string.Empty;

		protected override void ListenForCommands()
		{
			Receive<CreateNewTradeCommand>(m => Become(() => InternalProcess(m)));
			Receive<ExecuteTradeCommand>(m => Become(() => InternalProcess(m)));
		}

		private void InternalProcess(CreateNewTradeCommand command)
		{
			var trade = Trade.CreateNew(command.TradeId, command.ProductId, command.Amount, command.Position);
			_repository.Save(trade);
			ListenForCommands();
		}

		private void InternalProcess(ExecuteTradeCommand command)
		{
			var trade = _repository.Get(command.TradeId);
			Trade.ExecuteTrade((dynamic)trade);
			ListenForCommands();
		}
	}
}