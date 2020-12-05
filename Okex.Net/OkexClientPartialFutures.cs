using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using Okex.Net.Converters;
using Okex.Net.Helpers;
using Okex.Net.RestObjects;

namespace Okex.Net
{
	public partial class OkexClient
	{
		#region Futures Account API

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
		/// Retrieve a trading pair's order book. Pagination is not supported here; the entire orderbook will be returned per request. This is publicly accessible without account authentication. WebSocket is recommended here.
		/// Rate limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="symbol">Trading pair symbol</param>
		/// <param name="size">Number of results per request. Maximum 200</param>
		/// <param name="depth">Aggregation of the order book. e.g . 0.1, 0.001</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		public WebCallResult<OkexFuturesOrderBook> Future_GetOrderBook(string symbol, int? size = null, decimal? depth = null, CancellationToken ct = default) => Futures_GetOrderBook_Async(symbol, size, depth, ct).Result;
		/// <summary>
		/// Retrieve a trading pair's order book. Pagination is not supported here; the entire orderbook will be returned per request. This is publicly accessible without account authentication. WebSocket is recommended here.
		/// Rate limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="symbol">Trading pair symbol</param>
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

			var result = await SendRequest<OkexFuturesOrderBook>(GetUrl(Endpoints_Futures_OrderBook, symbol), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
			if (!result || result.Data == null)
				return new WebCallResult<OkexFuturesOrderBook>(result.ResponseStatusCode, result.ResponseHeaders, default, result.Error);

			if (result.Error != null)
				return new WebCallResult<OkexFuturesOrderBook>(result.ResponseStatusCode, result.ResponseHeaders, default, new ServerError(result.Error.Code, result.Error.Message));

			result.Data.Symbol = symbol.ToUpper(OkexGlobals.OkexCultureInfo);
			return new WebCallResult<OkexFuturesOrderBook>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
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

		public WebCallResult<OkexFuturesOrderDetails> Futures_GetOrderDetails(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default) => Futures_GetOrderDetails_Async(symbol, orderId, clientOrderId, ct).Result;
		/// <summary>
		/// Retrieve order details by order ID.Can get order information for nearly 3 months。 Unfilled orders will be kept in record for only two hours after it is canceled.
		/// Rate limit: 20 requests per 2 seconds
		/// </summary>
		/// <param name="symbol">Contract ID,e.g.BTC-USD-180213 ,BTC-USDT-191227</param>
		/// <param name="orderId">Order ID Either client_oid or order_id must be present.</param>
		/// <param name="clientOrderId">Client-supplied order ID Either client_oid or order_id must be present.</param>
		/// <param name="ct">Cancellation Token</param>
		/// <returns></returns>
		/// 
		public async Task<WebCallResult<OkexFuturesOrderDetails>> Futures_GetOrderDetails_Async(string symbol, long? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
		{
			symbol = symbol.ValidateSymbol();

			if (orderId == null && string.IsNullOrEmpty(clientOrderId))
				throw new ArgumentException("Either orderId or clientOrderId must be present.");

			if (orderId != null && !string.IsNullOrEmpty(clientOrderId))
				throw new ArgumentException("Either orderId or clientOrderId must be present.");

			var parameters = new Dictionary<string, object>
			{
				{ "instrument_id", symbol },
			};

			return await SendRequest<OkexFuturesOrderDetails>(GetUrl(Endpoints_Futures_OrderDetails, orderId.HasValue ? orderId.ToString() : clientOrderId!), HttpMethod.Get, ct, parameters, signed: true).ConfigureAwait(false);
		}

		public WebCallResult<OkexFuturesPlacedOrder> Futures_PlaceOrder(OkexFuturesOrderParams orderParams,
			CancellationToken ct = default)
		{
			return Futures_PlaceOrder_Async(orderParams, ct).Result;
		}

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

		public async Task<WebCallResult<OkexFuturesPlacedOrder>> Futures_PlaceOrder_Async(OkexFuturesOrderParams orderParams, CancellationToken ct = default)
		{
			orderParams.InstrumentId = orderParams.InstrumentId.ValidateSymbol();
			if (orderParams.Size < 1)
			{
				throw new ArgumentException("The number of contracts bought or sold (minimum size as 1)");
			}

			if (orderParams.MatchPrice.HasValue && (orderParams.MatchPrice == OkexFuturesOrderMatchPrice.Yes && orderParams.OrderType != OkexFuturesOrderType.NormalOrder))
			{
				throw new ArgumentException("When posting orders at best bid price, order_type can only be '0' (regular order)");
			}

			if (orderParams.ClientOrderId != null &&
				 !Regex.IsMatch(orderParams.ClientOrderId, "^(([a-z]|[A-Z]|[0-9]){0,32})$"))
			{
				throw new ArgumentException("ClientOrderId supports alphabets (case-sensitive) + numbers, or letters (case-sensitive) between 1-32 characters.");
			}

			var parameters = CreateFuturesOrderParamsForRequest(orderParams);
			return await SendRequest<OkexFuturesPlacedOrder>(GetUrl(Endpoints_Futures_PlaceOrder), HttpMethod.Post, ct, parameters, signed: true).ConfigureAwait(false);
		}

		private Dictionary<string, object> CreateFuturesOrderParamsForRequest(OkexFuturesOrderParams orderParams)
		{
			var parameters = new Dictionary<string, object>
			{
				{ "instrument_id", orderParams.InstrumentId },
				{ "type", JsonConvert.SerializeObject(orderParams.Type, new FuturesTypeConverter(false)) },
				{ "size", orderParams.Size}
			};
			parameters.AddOptionalParameter("client_oid", orderParams.ClientOrderId);
			parameters.AddOptionalParameter("match_price", JsonConvert.SerializeObject(orderParams.MatchPrice, new FuturesMatchPriceConverter(false)));
			parameters.AddOptionalParameter("price", orderParams.Price);
			parameters.AddOptionalParameter("order_type", JsonConvert.SerializeObject(orderParams.OrderType, new FuturesOrderTypeConverter(false)));

			return parameters;
		}

		#endregion
	}
}
