using System;
using AkkaSample.Contracts;
using AkkaSample.Domains.Events;

namespace AkkaSample.Actors.SQL
{
	public class BuildSqlQueryActor : AbstractReceiveActor
	{
		public BuildSqlQueryActor(IActorsFactory supervisorsFactory) : base(supervisorsFactory)
		{
		}

		protected override string NextActorName => "ExecuteSqlQueryActor";

		protected override void ListenForCommands()
		{
			Receive<CreatedTradeEvent>(m => Become(() => InternalProcess(m)));
		}

		private void InternalProcess(CreatedTradeEvent @event)
		{
			var query = "SELECT * FROM Trades WHERE ID = " + @event.TradeId + " AND Amount = " + @event.Amount;

			NextActor.Tell(query, NextActor);

			ListenForCommands();
		}
	}
}
