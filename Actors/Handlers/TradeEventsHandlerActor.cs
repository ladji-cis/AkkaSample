using Akka.Actor;
using AkkaSample.Contracts;
using AkkaSample.Domains.Events;

namespace AkkaSample.Actors.Handlers
{
	public class TradeEventsHandlerActor : TypedActor,
		IHandle<CreatedTradeEvent>
	{
		private readonly IActorRef _sqlBuilder;

		public TradeEventsHandlerActor(IActorsFactory factory)
		{
			_sqlBuilder = factory.SelectActorOf("BuildSqlQueryActor");
		}

		public void Handle(CreatedTradeEvent message)
		{
			_sqlBuilder.Tell(message);
		}
	}
}
