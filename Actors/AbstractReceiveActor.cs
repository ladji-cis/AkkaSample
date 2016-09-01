using System;
using Akka.Actor;
using AkkaSample.Contracts;

namespace AkkaSample.Actors
{
	public abstract class AbstractReceiveActor : ReceiveActor
	{
		protected readonly IActorsFactory SupervisorFactory;
		protected readonly IActorRef NextActor;

		protected AbstractReceiveActor(IActorsFactory supervisorsFactory)
		{
			SupervisorFactory = supervisorsFactory;

			if (!string.IsNullOrEmpty(NextActorName))
			{
				NextActor = SupervisorFactory.SelectActorOf(NextActorName);
			}
		}

		protected override void PreStart()
		{
			base.PreStart();
			Become(ListenForCommands);
		}

		//protected override void PreRestart(Exception reason, object message)
		//{
		//	foreach (var each in Context.GetChildren())
		//	{
		//		Context.Unwatch(each);
		//		Context.Stop(each);
		//	}
		//	PostStop();
		//}

		protected abstract string NextActorName { get; }

		protected abstract void ListenForCommands();
	}
}
