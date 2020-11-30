using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
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
			return await SendRequest<IEnumerable<OkexFuturesMarketData>>(GetUrl(Endpoints_Futures_TradingContracts), HttpMethod.Get, ct).ConfigureAwait(false);
		}

		#endregion
	}
}
