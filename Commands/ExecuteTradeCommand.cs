using System;

namespace AkkaSample.Commands
{
	public class ExecuteTradeCommand : IBaseCommand
	{
		public ExecuteTradeCommand(Guid tradeId)
		{
			TradeId = tradeId;
			ExecutionDate = DateTime.UtcNow;
		}

		public Guid TradeId { get;}
		public DateTime ExecutionDate { get; }
	}
}