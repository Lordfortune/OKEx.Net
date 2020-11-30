using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesMarketData
	{
		[JsonProperty("instrument_id")]
		public string InstrumentId { get; set; }
		[JsonProperty("underlying")]
		public string Underlying { get; set; }
		[JsonProperty("base_currency")]
		public string BaseCurrency { get; set; }
		[JsonProperty("quote_currency")]
		public string QuoteCurrency { get; set; }
		[JsonProperty("settlement_currency")]
		public string SettlementCurrency { get; set; }
		[JsonProperty("contract_val")]
		public string ContractVal { get; set; }
		[JsonProperty("listing")]
		public string Listing { get; set; }
		[JsonProperty("delivery")]
		public string Delivery { get; set; }
		[JsonProperty("tick_size")]
		public string TickSize { get; set; }
		[JsonProperty("trade_increment")]
		public string TradeIncrement { get; set; }
		[JsonProperty("alias")]
		public string Alias { get; set; }
		[JsonProperty("is_inverse")]
		public string IsInverse { get; set; }
		[JsonProperty("contract_val_currency")]
		public string ContractValCurrency { get; set; }
		[JsonProperty("category")]
		public string Category { get; set; }
		[JsonProperty("underlying_index")]
		public string UnderlyingIndex { get; set; }
	}
}
