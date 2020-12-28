using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using Okex.Net.Converters.Futures;
using Okex.Net.Enums;
using Okex.Net.Helpers;
using Okex.Net.RestObjects;

namespace Okex.Net
{
	public partial class OkexClient
	{
		#region Futures Account API

		/// <summary>
		/// Get market data. This endpoint provides the snapshots of market data and can be used without verifications.
		/// Rate Limit: 20 requests per 2 seconds (Based on IP speed limit)
		/// Notes
		/// - The tick size is the smallest unit of price.The order price must be a multiple of the tick size.If the tick size is 0.01, entering a price of 0.022 will be adjusted to 0.02 instead.
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<IEnumerable<OkexFuturesContract>> Futures_GetTradingContracts(CancellationToken ct = default) => Futures_GetTradingContracts_Async(ct).Result;
		/// <summary>
		/// Get market data. This endpoint provides the snapshots of market data and can be used without verifications.
		/// Rate Limit: 20 requests per 2 seconds (Based on IP speed limit)
		/// Notes
		/// - The tick size is the smallest unit of price.The order price must be a multiple of the tick size.If the tick size is 0.01, entering a price of 0.022 will be adjusted to 0.02 instead.
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<IEnumerable<OkexFuturesContract>>> Futures_GetTradingContracts_Async(CancellationToken ct = default)
		{
			return await SendRequest<IEnumerable<OkexFuturesContract>>(GetUrl(Endpoints_Futures_TradingContracts), HttpMethod.Get, ct).ConfigureAwait(false);
		}

		/// <summary>
		/// Retrieve a trading pair's order book. Pagination is not supported here; the entire orderbook will be returned per request. This is publicly accessible without account authentication. WebSocket is recommended here.
		/// Rate limit: 20 requests per 2 seconds (Depending on the underlying speed limit)
		/// Notes:
		/// - Aggregation of the order book means that orders within a certain price range is combined and considered as one order cluster.
		/// - When size is not passed in the parameters, one entry is returned; when size is 0, no entry is returned.The maximum size is 200. When requesting more than 200 entries, at most 200 entries are returned.
		/// </summary>
		/// <param name="symbol">Contract ID,e.g. BTC-USD-180213,BTC-USDT-191227</param>
		/// <param name="size">Number of results per request. Maximum 200</param>
		/// <param name="depth">Aggregation of the order book. e.g . 0.1, 0.001</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<OkexFuturesOrderBook> Futures_GetOrderBook(string symbol, int? size = null, decimal? depth = null, CancellationToken ct = default) => Futures_GetOrderBook_Async(symbol, size, depth, ct).Result;
		/// <summary>
		/// Retrieve a trading pair's order book. Pagination is not supported here; the entire orderbook will be returned per request. This is publicly accessible without account authentication. WebSocket is recommended here.
		/// Rate limit: 20 requests per 2 seconds (Depending on the underlying speed limit)
		/// Notes:
		/// - Aggregation of the order book means that orders within a certain price range is combined and considered as one order cluster.
		/// - When size is not passed in the parameters, one entry is returned; when size is 0, no entry is returned.The maximum size is 200. When requesting more than 200 entries, at most 200 entries are returned.
		/// </summary>
		/// <param name="symbol">Contract ID,e.g. BTC-USD-180213,BTC-USDT-191227</param>
		/// <param name="size">Number of results per request. Maximum 200</param>
		/// <param name="depth">Aggregation of the order book. e.g . 0.1, 0.001</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<OkexFuturesOrderBook>> Futures_GetOrderBook_Async(string symbol, int? size = null, decimal? depth = null, CancellationToken ct = default)
		{
			symbol = symbol.ValidateSymbol();
			size?.ValidateIntBetween(nameof(size), 1, 200);

			var parameters = new Dictionary<string, object>();
			parameters.AddOptionalParameter("size", size);
			parameters.AddOptionalParameter("depth", depth);

			return await SendRequest<OkexFuturesOrderBook>(GetUrl(Endpoints_Futures_OrderBook, symbol), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
		}


		/// <summary>
		/// Get market data. This endpoint provides the snapshots of market data and can be used without verifications.
		/// Limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<IEnumerable<OkexFuturesMarketData>> Futures_GetMarketData(CancellationToken ct = default) => Futures_GetMarketData_Async(ct).Result;
		/// <summary>
		/// Get market data. This endpoint provides the snapshots of market data and can be used without verifications.
		/// Limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<IEnumerable<OkexFuturesMarketData>>> Futures_GetMarketData_Async(CancellationToken ct = default)
		{
			return await SendRequest<IEnumerable<OkexFuturesMarketData>>(GetUrl(Endpoints_Futures_Accounts), HttpMethod.Get, ct).ConfigureAwait(false);
		}
		/// <summary>
        /// Retrieve information from all tokens in the futures account. You are recommended to get the information one token at a time to improve performance.
        /// Rate Limit: 1 per 10 seconds (Speed limit based on UserID)
        /// Notes:
        /// - For "all open interests/all account info" futures account endpoints, if no position/token is held then no response will be returned. For "single open interests/single account info" endpoints, if no position/token is held then the response will return with default value.
        /// - Fixed-margin mode:
        /// - - Account equity = Balance of Funding Account + Balance of Fixed-margin Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts
        /// - - Available Margin = Balance of Funding Account + Balance of Fixed-margin Account + RPL (Realized Profit and Loss) of the Contract - Maintenance Margin of the Open Interests - Margin frozen for Open Orders
        /// - Cross-margin mode:
        /// - - Account Equity = Balance of Fund Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts
        /// - - Available Margin = Balance of Fund Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts - Maintenance Margin of the Open Interests - Margin frozen for Open Orders
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        public WebCallResult<OkexFuturesBalances> Futures_GetBalances(CancellationToken ct = default) => Futures_GetBalances_Async(ct).Result;
		/// <summary>
		/// Retrieve information from all tokens in the futures account. You are recommended to get the information one token at a time to improve performance.
		/// Rate Limit: 1 per 10 seconds (Speed limit based on UserID)
		/// Notes:
		/// - For "all open interests/all account info" futures account endpoints, if no position/token is held then no response will be returned. For "single open interests/single account info" endpoints, if no position/token is held then the response will return with default value.
		/// - Fixed-margin mode:
		/// - - Account equity = Balance of Funding Account + Balance of Fixed-margin Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts
		/// - - Available Margin = Balance of Funding Account + Balance of Fixed-margin Account + RPL (Realized Profit and Loss) of the Contract - Maintenance Margin of the Open Interests - Margin frozen for Open Orders
		/// - Cross-margin mode:
		/// - - Account Equity = Balance of Fund Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts
		/// - - Available Margin = Balance of Fund Account + RPL (Realized Profit and Loss) of All Contracts + UPL (Unrealized Profit and Loss) of All Contracts - Maintenance Margin of the Open Interests - Margin frozen for Open Orders
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<OkexFuturesBalances>> Futures_GetBalances_Async(CancellationToken ct = default)
		{
			return await SendRequest<OkexFuturesBalances>(GetUrl(Endpoints_Futures_Accounts), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
		}

		/// <summary>
		/// Retrieve order details by order ID.Can get order information for nearly 3 months。 Unfilled orders will be kept in record for only two hours after it is canceled.
		/// Rate limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="symbol">Contract ID,e.g.BTC-USD-180213 ,BTC-USDT-191227</param>
		/// <param name="orderId">Order ID Either client_oid or order_id must be present.</param>
		/// <param name="clientOrderId">Client-supplied order ID Either client_oid or order_id must be present.</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>

		/// <summary>
		/// Retrieve information from all tokens in the futures account. You are recommended to get the information one token at a time to improve performance.
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<FuturesAccountInfo> Futures_GetAllBalances(CancellationToken ct = default) => Futures_GetAllBalances_Async(ct).Result;
		/// <summary>
		/// Retrieve information from all tokens in the futures account. You are recommended to get the information one token at a time to improve performance.
		/// </summary>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<FuturesAccountInfo>> Futures_GetAllBalances_Async(CancellationToken ct = default)
		{
			var result = await SendRequest<FuturesAccountInfo>(GetUrl(Endpoints_Futures_Accounts), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
			return result;
		}

		public WebCallResult<OkexFuturesOrder> Futures_GetOrderDetails(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default) => Futures_GetOrderDetails_Async(symbol, orderId, clientOrderId, ct).Result;
		/// <summary>
		/// Retrieve order details by order ID. Unfilled orders will be kept in record for only two hours after it is canceled.
		/// Rate limit: 60 requests per 2 seconds (Depending on the underlying speed limit)
		/// Notes:
		/// - status is the older version ofstateand both can be used interchangeably in the short term.It is recommended to switch tostate`.
		/// - The client_oid is optional and you can customize it using alpha-numeric characters with length 1 to 32. This parameter is used to identify your orders in the public orders feed.No warning is sent when client_oid is not unique. In case of multiple identical client_oid, only the latest entry will be returned.
		/// - If the order is not filled in the order life cycle, the record may be removed.
		/// - Unfilled order status may change according to the market conditions.
		/// - Can get order information for nearly 3 months
		/// </summary>
		/// <param name="symbol">Contract ID,e.g.BTC-USD-180213 ,BTC-USDT-191227</param>
		/// <param name="orderId">Order ID Either client_oid or order_id must be present.</param>
		/// <param name="clientOrderId">Client-supplied order ID Either client_oid or order_id must be present.</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<OkexFuturesOrder>> Futures_GetOrderDetails_Async(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
		{
			symbol = symbol.ValidateSymbol();

			if (orderId == null && string.IsNullOrEmpty(clientOrderId))
				throw new ArgumentException("Either orderId or clientOrderId must be present.");

			if (orderId != null && !string.IsNullOrEmpty(clientOrderId))
				throw new ArgumentException("Either orderId or clientOrderId must be present.");

			return await SendRequest<OkexFuturesOrder>(GetUrl(Endpoints_Futures_OrderDetails.Replace("<instrument_id>", symbol), orderId.HasValue ? orderId.ToString() : clientOrderId!), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
		}

		/// </summary>
		/// <param name="symbol">Contract ID,e.g. BTC-USD-180213 ,BTC-USDT-191227</param>
		/// <param name="type">1:open long 2:open short 3:close long 4:close short</param>
		/// <param name="size">The number of contracts bought or sold (minimum size as 1)</param>
		/// <param name="timeInForce">‘0’: Normal order. Parameter will be deemed as '0' if left blank. ‘1’: Post only (Order shall be filled only as maker) ‘2’: Fill or Kill (FOK) ‘3’: Immediate or Cancel (IOC) 4：Market</param>
		/// <param name="price">Price of each contract</param>
		/// <param name="match_price">Whether order is placed at best counter party price (‘0’:no ‘1’:yes). The parameter is defaulted as ‘0’. If it is set as '1', the price parameter will be ignored，When posting orders at best bid price, order_type can only be '0' (regular order)</param>
		/// <param name="clientOrderId">You can customize order IDs to identify your orders. The system supports alphabets + numbers(case-sensitive，e.g:A123、a123), or alphabets (case-sensitive，e.g:Abc、abc) only, between 1-32 characters.</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<OkexFuturesPlacedOrder> Futures_PlaceOrder(string symbol, OkexFuturesOrderType type, decimal size, OkexFuturesTimeInForce timeInForce = OkexFuturesTimeInForce.NormalOrder, decimal? price = null, bool match_price = false, string? clientOrderId = null, CancellationToken ct = default) => Futures_PlaceOrder_Async(symbol, type, size, timeInForce, price, match_price, clientOrderId, ct).Result;
		/// <summary>
		/// OKEx futures trading supports limit and market orders. You can place an order only if you have sufficient funds. Once your order is placed, the amount will be put on hold during the order lifecycle. The assets and amount on hold depends on the order's specific type and parameters.
		/// The futures maximum openable leverage multiple is determined by your positions, pending orders and the number of new orders placed at the time of opening. For details: https://www.okex.com/derivatives/futures/position
		/// Rate Limit: 60 requests per 2 seconds (Speed limit rules: 1) The speed limit is not accumulated between different contracts； 2) Api limit is separated by underlying. Different tenure of the same underlying share the limit； 3) The speed limit between the Coin Margined Futures and the USDT Margined Futures is not accumulated)
		/// Notes:
		/// - instrument_id
		///   The instrument_id must match a valid contract ID. The contract list is available via the /instruments endpoint.
		/// - client_oid
		///   The client_oid is optional. It should be a unique ID generated by your trading system. This parameter is used to identify your orders in the public orders feed. No warning is sent when client_oid is not unique.
		///	  In case of multiple identical client_oid, only the latest entry will be returned.
		///	- type
		///	  You can specify the order type when placing an order. If you are not holding any positions, you can only open new positions, either long or short. You can only close the positions that has been already held.
		///	  The price must be specified in tick size product units. The tick size is the smallest unit of price. Can be obtained through the /instrument interface.
		///	- price
		///	  The price is the price of buying or selling a contract. price must be an incremental multiple of the tick_size. tick_size is the smallest incremental unit of price, which is available via the /instruments endpoint.
		///	- size
		///	  size is the number of contracts bought or sold. The value must be an integer.
		///	- match_price
		///	  The match_price means that you prefer the order to be filled at a best price of the counterpart, where your buy order will be filled at the price of Ask-1. The match_price means that your sell order will be filled at the price of Bid-1.
		///	- Order life cycle
		///	  The HTTP Request will respond when an order is either rejected (insufficient funds, invalid parameters, etc) or received (accepted by the matching engine). A 200 response indicates that the order was received and is active.
		///	  Active orders may execute immediately (depending on price and market conditions) either partially or fully. A partial execution will put the remaining size of the order in the open state. An order that is filled Fully, will go into the completed state.
		///	  Users listening to streaming market data are encouraged to use the client_oid field to identify their received messages in the feed. The REST response with a server order_id may come after the received message in the public data feed.
		///	- Response
		///	  A successful order will be assigned an order id. A successful order is defined as one that has been accepted by the matching engine. Open orders will not expire until filled or canceled.
		/// </summary>
		/// <param name="symbol">Contract ID,e.g. BTC-USD-180213 ,BTC-USDT-191227</param>
		/// <param name="type">1:open long 2:open short 3:close long 4:close short</param>
		/// <param name="size">The number of contracts bought or sold (minimum size as 1)</param>
		/// <param name="timeInForce">‘0’: Normal order. Parameter will be deemed as '0' if left blank. ‘1’: Post only (Order shall be filled only as maker) ‘2’: Fill or Kill (FOK) ‘3’: Immediate or Cancel (IOC) 4：Market</param>
		/// <param name="price">Price of each contract</param>
		/// <param name="match_price">Whether order is placed at best counter party price (‘0’:no ‘1’:yes). The parameter is defaulted as ‘0’. If it is set as '1', the price parameter will be ignored，When posting orders at best bid price, order_type can only be '0' (regular order)</param>
		/// <param name="clientOrderId">You can customize order IDs to identify your orders. The system supports alphabets + numbers(case-sensitive，e.g:A123、a123), or alphabets (case-sensitive，e.g:Abc、abc) only, between 1-32 characters.</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public async Task<WebCallResult<OkexFuturesPlacedOrder>> Futures_PlaceOrder_Async(string symbol, OkexFuturesOrderType type, decimal size, OkexFuturesTimeInForce timeInForce = OkexFuturesTimeInForce.NormalOrder, decimal? price = null, bool match_price = false, string? clientOrderId = null, CancellationToken ct = default)
		{
			symbol = symbol.ValidateSymbol();
			clientOrderId?.ValidateStringLength("clientOrderId", 0, 32);
			if (clientOrderId != null && !Regex.IsMatch(clientOrderId, "^(([a-z]|[A-Z]|[0-9]){0,32})$"))
				throw new ArgumentException("ClientOrderId supports alphabets (case-sensitive) + numbers, or letters (case-sensitive) between 1-32 characters.");

			var parameters = new Dictionary<string, object>
				{
					 { "instrument_id", symbol },
					 { "type", JsonConvert.SerializeObject(type, new FuturesOrderTypeConverter(false)) },
					 { "size", size },
					 { "match_price", match_price?1:0 },
					 { "order_type", JsonConvert.SerializeObject(timeInForce, new FuturesTimeInForceConverter(false)) },
				};
			parameters.AddOptionalParameter("client_oid", clientOrderId);
			parameters.AddOptionalParameter("price", price);

			return await SendRequest<OkexFuturesPlacedOrder>(GetUrl(Endpoints_Futures_PlaceOrder), HttpMethod.Post, ct, parameters, signed: true).ConfigureAwait(false);
		}

		//public WebCallResult<OkexFuturesPlacedOrder> Futures_PlaceOrder(OkexFuturesOrderParams orderParams,
		//	CancellationToken ct = default)
		//{
		//	return Futures_PlaceOrder_Async(orderParams, ct).Result;
		//}

		//public async Task<WebCallResult<OkexFuturesPlacedOrder>> Futures_PlaceOrder_Async(OkexFuturesOrderParams orderParams, CancellationToken ct = default)
		//{
		//	orderParams.InstrumentId = orderParams.InstrumentId.ValidateSymbol();
		//	if (orderParams.Size < 1)
		//	{
		//		throw new ArgumentException("The number of contracts bought or sold (minimum size as 1)");
		//	}

		//	if (orderParams.MatchPrice.HasValue && (orderParams.MatchPrice == OkexFuturesOrderMatchPrice.Yes && orderParams. != OkexFuturesOrderType.NormalOrder))
		//	{
		//		throw new ArgumentException("When posting orders at best bid price, order_type can only be '0' (regular order)");
		//	}

		//	if (orderParams.ClientOrderId != null &&
		//		 !Regex.IsMatch(orderParams.ClientOrderId, "^(([a-z]|[A-Z]|[0-9]){0,32})$"))
		//	{
		//		throw new ArgumentException("ClientOrderId supports alphabets (case-sensitive) + numbers, or letters (case-sensitive) between 1-32 characters.");
		//	}

		//	var parameters = CreateFuturesOrderParamsForRequest(orderParams);
		//	return await SendRequest<OkexFuturesPlacedOrder>(GetUrl(Endpoints_Futures_PlaceOrder), HttpMethod.Post, ct, parameters, signed: true).ConfigureAwait(false);
		//}

		//private Dictionary<string, object> CreateFuturesOrderParamsForRequest(OkexFuturesOrderParams orderParams)
		//{
		//	var parameters = new Dictionary<string, object>
		//	{
		//		{ "instrument_id", orderParams.InstrumentId },
		//		{ "type", JsonConvert.SerializeObject(orderParams.Type, new FuturesTypeConverter(false)) },
		//		{ "size", orderParams.Size}
		//	};
		//	parameters.AddOptionalParameter("client_oid", orderParams.ClientOrderId);
		//	parameters.AddOptionalParameter("match_price", JsonConvert.SerializeObject(orderParams.MatchPrice, new FuturesMatchPriceConverter(false)));
		//	parameters.AddOptionalParameter("price", orderParams.Price);
		//	parameters.AddOptionalParameter("order_type", JsonConvert.SerializeObject(orderParams.OrderType, new FuturesOrderTypeConverter(false)));

		//	return parameters;
		//}

		#endregion
	}
}
