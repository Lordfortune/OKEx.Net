using System.Collections.Generic;
using CryptoExchange.Net.Attributes;
using Newtonsoft.Json;
using Okex.Net.Converters.Shared;
using Okex.Net.Enums;
using Okex.Net.RestObjects;

namespace Okex.Net.SocketObjects.Futures
{
	public class OkexFuturesOrderBookUpdate
	{
		[JsonProperty("table")]
		internal string Table { get; set; } = "";

		[JsonProperty("action"), JsonOptionalProperty, JsonConverter(typeof(OrderBookDataTypeConverter))]
		internal OkexOrderBookDataType DataType { get; set; }

		[JsonProperty("data")]
		public IEnumerable<OkexFuturesOrderBook> Data { get; set; } = default!;
	}

}
