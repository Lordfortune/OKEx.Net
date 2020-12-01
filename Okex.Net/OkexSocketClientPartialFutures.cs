using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Okex.Net.Helpers;
using Okex.Net.RestObjects;
using Okex.Net.SocketObjects.Structure;

namespace Okex.Net
{
	public partial class OkexSocketClient
	{
		#region Futures

		/// <summary>
		/// Depth-Five: Back to the previous five entries of depth data,This data is snapshot data per 100 milliseconds.For every 100 milliseconds, we will snapshot and push 5 entries of market depth data of the current order book.
		/// Depth-All: After subscription, 400 entries of market depth data of the order book will first be pushed. Subsequently every 100 milliseconds we will snapshot and push entries that have changed during this time.
		/// </summary>
		/// <param name="symbol">Trading pair symbol</param>
		/// <param name="depth">Order Book Depth</param>
		/// <param name="onData">The handler for updates</param>
		/// <returns></returns>
		public CallResult<UpdateSubscription> Futures_SubscribeToOrderBook(string symbol, OkexFuturesOrderBookDepth depth, Action<OkexFuturesOrderBook> onData) => Futures_SubscribeToOrderBook_Async(symbol, depth, onData).Result;

		public async Task<CallResult<UpdateSubscription>> Futures_SubscribeToOrderBook_Async(string symbol,
			OkexFuturesOrderBookDepth depth, Action<OkexFuturesOrderBook> onData)
		{
			symbol = symbol.ValidateSymbol();

			var internalHandler = new Action<OkexSocketFuturesOrderBookUpdate>(data =>
			{
				foreach (var d in data.Data)
				{
					d.Symbol = symbol.ToUpper(OkexGlobals.OkexCultureInfo);
					d.DataType = depth == OkexFuturesOrderBookDepth.Depth5 ? OkexFuturesOrderBookDataType.DepthTop5 : data.DataType;
					onData(d);
				}
			});

			var channel = "depth";
			if (depth == OkexFuturesOrderBookDepth.Depth5) channel = "depth5";
			else if (depth == OkexFuturesOrderBookDepth.Depth400) channel = "depth";
			else if (depth == OkexFuturesOrderBookDepth.TickByTick) channel = "depth_l2_tbt";
			var request = new OkexSocketRequest(OkexSocketOperation.Subscribe, $"futures/{channel}:{symbol}");
			return await Subscribe(request, null, false, internalHandler).ConfigureAwait(false);
		}

		#endregion
	}
}
