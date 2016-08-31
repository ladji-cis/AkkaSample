using System;

namespace AkkaSample.Commands
{
	public class CreateNewTradeCommand : IBaseCommand
	{
		public Guid TradeId { get; }
		public Guid ProductId { get; }
		public decimal Amount { get; }
		public int Position { get; }

		public CreateNewTradeCommand(Guid tradeId, Guid productId, decimal amount, int position)
		{
			TradeId = tradeId;
			ProductId = productId;
			Amount = amount;
			Position = position;
		}
	}

}