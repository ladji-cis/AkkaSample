using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkkaSample.Domains.Aggregates;

namespace AkkaSample.Domains.Events
{
	public class CreatedTradeEvent : DomainEvent
	{
		public Guid TradeId { get; set; }
		public Guid ProductId { get; set; }
		public decimal Amount { get; set; }
		public int Position { get; set; }

		public CreatedTradeEvent(Trade trade)
		{
			TradeId = trade.Id;
			ProductId = trade.ProductId;
			Amount = trade.Amount;
			Position = trade.Position;
		}

		public override string ToString()
		{
			return $"TradeId: {TradeId}, ProductId: {ProductId}, Amount: {Amount}, Position: {Position}";
		}
	}
}
