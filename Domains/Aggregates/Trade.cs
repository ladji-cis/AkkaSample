using System;
using AkkaSample.Domains.Events;

namespace AkkaSample.Domains.Aggregates
{
	public class Trade : Aggregate
	{
		public Guid ProductId { get; set; }
		public decimal Amount { get; set; }
		public int Position { get; set; }

		public Trade(Guid tradeId, Guid productId, decimal amount, int position)
		{
			Id = tradeId;
			ProductId = productId;
			Amount = amount;
			Position = position;
		}

		public static Trade CreateNew(Guid tradeId, Guid productId, decimal amount, int position)
		{
			var trade = new Trade(tradeId, productId, amount, position);

			trade.ApplyChanges(new CreatedTradeEvent(trade)); 

			return trade;
		}

		public static void ExecuteTrade(Trade trade)
		{
			
		}

		public override string ToString()
		{
			return $"TradeId: {Id} : {Amount}";
		}
	}
}