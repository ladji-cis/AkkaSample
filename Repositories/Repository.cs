using System;
using System.Collections.Concurrent;
using System.Linq;
using Akka.Actor;
using Akka.Util.Internal;
using AkkaSample.Contracts;
using AkkaSample.Domains.Aggregates;

namespace AkkaSample.Repositories
{
	public class Repository : IRepository
	{
		private readonly IEventStore _eventStore;
		private readonly BlockingCollection<Aggregate> _database;
		private readonly IActorRef _eventsHandler;

		public Repository(IEventStore eventStore, IActorsFactory supervisorsFactory) 
		{
			_eventStore = eventStore;
			_database = new BlockingCollection<Aggregate>();
			_eventsHandler = supervisorsFactory.SelectActorOf("TradeEventsHandlerActor");
		}

		public void Save(Aggregate aggregate)
		{
			aggregate.GetUncommittedChanges().ForEach(e =>
			{
				_eventsHandler.Tell(e, _eventsHandler);
			});
			_database.Add(aggregate); // TODO : Save aggregate into EventStore
			aggregate.MarkAsCommitted();		
		}

		public Aggregate Get(Guid aggegateId)
		{
			// TODO : Return aggregate from EventStore
			return _database.SingleOrDefault(x => x.Id == aggegateId);
		}
	}
}