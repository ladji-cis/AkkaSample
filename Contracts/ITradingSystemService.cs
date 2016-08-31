using System;

namespace AkkaSample.Contracts
{
	public interface ITradingSystemService
	{
		void CreateNewTrade(Guid tradeId, Guid productId, decimal amount, int position);
		void ExecuteTrade(Guid tradeId);
	}
}
