using System;
using AkkaSample.Contracts;

namespace AkkaSample.Actors.SQL
{
	public class ExecuteSqlQueryActor : AbstractReceiveActor
	{
		public ExecuteSqlQueryActor(IActorsFactory supervisorsFactory) : base(supervisorsFactory)
		{
		}

		protected override string NextActorName  => string.Empty;

		protected override void ListenForCommands()
		{
			Receive<string>(m => Become(() => InternalProcess(m)));
		}

		private void InternalProcess(string query)
		{
			Console.WriteLine(query);
			ListenForCommands();
		}
	}
}
