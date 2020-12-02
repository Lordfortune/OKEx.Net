using System;
using CryptoExchange.Net.Attributes;
using Newtonsoft.Json;
using Okex.Net.Converters;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesOrderDetails
	{
		/// <summary>
		/// Contract ID, e,g. BTC-USD-180213 ,BTC-USDT-191227
		/// </summary>
		[JsonProperty("instrument_id")]
		public string Symbol { get; set; }

		/// <summary>
		/// Quantity
		/// </summary>
		[JsonProperty("size")]
		public decimal? Size { get; set; }

		/// <summary>
		/// Order creation time
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Filled quantity
		/// </summary>
		[JsonProperty("filled_qty")]
		public string FilledQuantity { get; set; } = "";

		/// <summary>
		/// Transaction Fee
		/// </summary>
		[JsonProperty("fee")]
		public decimal? Fee { get; set; }

		/// <summary>
		/// Order ID
		/// </summary>
		[JsonProperty("order_id")]
		public string OrderId { get; set; }

		/// <summary>
		/// Price of order
		/// </summary>
		[JsonProperty("price")]
		public decimal? Price { get; set; }

		/// <summary>
		/// Average filled price
		/// </summary>
		[JsonProperty("price_avg"), JsonOptionalProperty]
		public decimal? PriceAverage { get; set; }

		/// <summary>
		/// Type (1: open long 2: open short 3: close long 4: close short)
		/// </summary>
		[JsonProperty("type"), JsonConverter(typeof(FuturesTypeConverter))]
		public OkexFuturesType Type { get; set; }

		/// <summary>
		/// Contract value
		/// </summary>
		[JsonProperty("contract_val")]
		public decimal? ContractValue { get; set; }

		/// <summary>
		/// Leverage, 1-100x
		/// </summary>
		[JsonProperty("leverage")]
		public decimal? Leverage { get; set; }

		/// <summary>
		/// Client-supplied order ID
		/// </summary>
		[JsonProperty("client_oid")]
		public string ClientOrderId { get; set; }

		/// <summary>
		/// Specify 0: Normal order (Unfilled and 0 imply normal limit order) 1: Post only 2: Fill or Kill 3: Immediate Or Cancel
		/// </summary>
		[JsonProperty("order_type"), JsonConverter(typeof(FuturesOrderTypeConverter))]
		public OkexFuturesOrderType OrderType { get; set; }

		/// <summary>
		/// Profit and loss
		/// </summary>
		[JsonProperty("pnl")]
		public string PNL { get; set; }

		/// <summary>
		/// Order Status: -2 = Failed -1 = Canceled 0 = Open 1 = Partially Filled 2 = Fully Filled 3 = Submitting 4 = Canceling
		/// </summary>
		[JsonProperty("state"), JsonConverter(typeof(FuturesOrderStateConverter))]
		public OkexFuturesOrderState State { get; set; }
	}
}
