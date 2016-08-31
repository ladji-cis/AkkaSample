using Akka.Actor;

namespace AkkaSample.Contracts
{
	public interface IActorsFactory
	{
		IActorRef SelectActorOf(string actorName);
	}
}
