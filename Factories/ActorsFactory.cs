using System;
using Akka.Actor;
using Akka.DI.Core;
using AkkaSample.Actors.Handlers;
using AkkaSample.Actors.Managers;
using AkkaSample.Actors.SQL;
using AkkaSample.Contracts;

namespace AkkaSample.Factories
{
	public class ActorsFactory : IActorsFactory
	{
		private readonly ActorSystem _system;

		public ActorsFactory(ActorSystem system)
		{
			_system = system;
		}

		public IActorRef SelectActorOf(string actorName)
		{
			var props = _system.DI().Props(GetActorType(actorName));
			return _system.ActorOf(props, actorName);
		}

		public Type GetActorType(string actorName)
		{
			switch (actorName)
			{
				case "TradeManagerActor":
					return typeof(TradeManagerActor);

				case "TradeCommandsHandler":
					return typeof(TradeCommandsHandlerActor);

				case "TradeEventsHandlerActor":
					return typeof(TradeEventsHandlerActor);

				case "BuildSqlQueryActor":
					return typeof(BuildSqlQueryActor);

				case "ExecuteSqlQueryActor":
					return typeof(ExecuteSqlQueryActor);

				default:
					throw new ActorNotFoundException(actorName);
			}
		}
	}
}
