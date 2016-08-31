using System;
using System.Collections.Generic;
using AkkaSample.Domains.Events;

namespace AkkaSample.Domains.Aggregates
{
	public abstract class Aggregate
	{
		public Guid Id { get; set; }
		public int Version { get; set; }
		public DateTime CreationDate { get; set; }

		private readonly IList<DomainEvent> _changes;

		protected Aggregate()
		{
			_changes = new List<DomainEvent>();
		}

		public IEnumerable<DomainEvent> GetUncommittedChanges()
		{
			return _changes;
		}

		public void MarkAsCommitted()
		{
			lock (_changes)
			{
				_changes.Clear();
			}
		} 

		public void ApplyChanges(DomainEvent domainEvent, bool isNew = true)
		{
			lock (_changes)
			{
				if (isNew)
				{
					_changes.Add(domainEvent);
				}
				else
				{
					Version++;
				}
			}
		}
	}
}
