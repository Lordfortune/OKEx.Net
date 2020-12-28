using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Okex.Net.Enums;
using Okex.Net.Helpers;
using Okex.Net.RestObjects;
using Okex.Net.SocketObjects.Futures;
using Okex.Net.SocketObjects.Structure;

namespace Okex.Net
{
	public partial class OkexSocketClient
	{
		#region Futures

		/// <summary>
		/// Depth-Five: The latest 5 entries of the market depth data is snapshooted and pushed every 100 milliseconds.
		/// Depth-All: After subscription, 400 entries of market depth data of the order book will first be pushed. Subsequently every 100 milliseconds we will snapshot and push entries that have changed during this time.
		/// Depth-TickByTick: The 400 entries of market depth data of the order book that return for the first time after subscription will be pushed; subsequently as long as there's any change of market depth data of the order book, the changes will be pushed tick by tick. Subsequently as long as there's any change of market depth data of the order book, the changes will be pushed tick by tick.
		/// </summary>
		/// <param name="symbol">Trading pair symbol</param>
		/// <param name="depth">Order Book Depth</param>
		/// <param name="onData">The handler for updates</param>
		/// <returns></returns>
		public CallResult<UpdateSubscription> Futures_SubscribeToOrderBook(string symbol, OkexOrderBookDepth depth, Action<OkexFuturesOrderBook> onData) => Futures_SubscribeToOrderBook_Async(symbol, depth, onData).Result;
		/// <summary>
		/// Depth-Five: The latest 5 entries of the market depth data is snapshooted and pushed every 100 milliseconds.
		/// Depth-All: After subscription, 400 entries of market depth data of the order book will first be pushed. Subsequently every 100 milliseconds we will snapshot and push entries that have changed during this time.
		/// Depth-TickByTick: The 400 entries of market depth data of the order book that return for the first time after subscription will be pushed; subsequently as long as there's any change of market depth data of the order book, the changes will be pushed tick by tick. Subsequently as long as there's any change of market depth data of the order book, the changes will be pushed tick by tick.
		/// </summary>
		/// <param name="symbol">Trading pair symbol</param>
		/// <param name="depth">Order Book Depth</param>
		/// <param name="onData">The handler for updates</param>
		/// <returns></returns>
		public async Task<CallResult<UpdateSubscription>> Futures_SubscribeToOrderBook_Async(string symbol, OkexOrderBookDepth depth, Action<OkexFuturesOrderBook> onData)
		{
			symbol = symbol.ValidateSymbol();

			var internalHandler = new Action<OkexFuturesOrderBookUpdate>(data =>
			{
				foreach (var d in data.Data)
				{
					d.Symbol = symbol.ToUpper(OkexGlobals.OkexCultureInfo);
					d.DataType = depth == OkexOrderBookDepth.Depth5 ? OkexOrderBookDataType.DepthTop5 : data.DataType;
					onData(d);
				}
			});

			var channel = "depth";
			if (depth == OkexOrderBookDepth.Depth5) channel = "depth5";
			else if (depth == OkexOrderBookDepth.Depth400) channel = "depth";
			else if (depth == OkexOrderBookDepth.TickByTick) channel = "depth_l2_tbt";
			var request = new OkexSocketRequest(OkexSocketOperation.Subscribe, $"futures/{channel}:{symbol}");
			return await Subscribe(request, null, false, internalHandler).ConfigureAwait(false);
		}
		#endregion
	}
}
