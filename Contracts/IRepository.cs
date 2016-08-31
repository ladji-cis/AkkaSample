using System;
using AkkaSample.Domains;
using AkkaSample.Domains.Aggregates;
using AkkaSample.Domains.Events;

namespace AkkaSample.Contracts
{
	public interface IRepository
	{
		void Save(Aggregate aggregate);
		Aggregate Get(Guid aggegateId);
	}
}
