using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Okex.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesOrderBook
	{
		[JsonProperty("instrument_id"), JsonOptionalProperty]
		public string Symbol { get; set; } = "";

		[JsonProperty("checksum"), JsonOptionalProperty]
		public long Checksum { get; set; }

		[JsonOptionalProperty, JsonConverter(typeof(FuturesOrderBookDataTypeConverter))]
		public OkexFuturesOrderBookDataType DataType { get; set; } = OkexFuturesOrderBookDataType.Api;

		/// <summary>
		/// Selling side
		/// </summary>
		[JsonProperty("asks")]
		public List<OkexFuturesOrderBookEntry> Asks { get; set; } = new List<OkexFuturesOrderBookEntry>();

		/// <summary>
		/// Buying side
		/// </summary>
		[JsonProperty("bids")]
		public List<OkexFuturesOrderBookEntry> Bids { get; set; } = new List<OkexFuturesOrderBookEntry>();

		/// <summary>
		/// Timestamp
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
	}

	[JsonConverter(typeof(ArrayConverter))]
	public class OkexFuturesOrderBookEntry
	{
		/// <summary>
		/// The price for this entry
		/// </summary>
		[ArrayProperty(0)]
		public decimal Price { get; set; }

		/// <summary>
		/// The contract size at the price
		/// </summary>
		[ArrayProperty(1)]
		public decimal ContractSize { get; set; }

		/// <summary>
		/// The number of the liquidated orders at the price
		/// </summary>
		[ArrayProperty(2)]
		public decimal LiquidatedOrdersByPrice { get; set; }
		/// <summary>
		/// The number of orders at the price
		/// </summary>
		[ArrayProperty(3)]
		public decimal OrdersByPrice { get; set; }
	}
}
