using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesContract
	{
		[JsonProperty("available_qty")]
		public decimal? AvailableQuantity { get; set; }
		[JsonProperty("fixed_balance")]
		public decimal? FixedBalance { get; set; }
		[JsonProperty("instrument_id")]
		public string InstrumentId { get; set; }
		[JsonProperty("margin_frozen")]
		public decimal? MarginFrozen { get; set; }
		[JsonProperty("realized_pnl")]
		public decimal? RealizedPnl { get; set; }
		[JsonProperty("unrealized_pnl")]
		public decimal? UnrealizedPnl { get; set; }
	}
}
