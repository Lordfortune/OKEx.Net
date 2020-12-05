using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesAccount
	{
		/// <summary>
		/// Account balance currency eg.BTC
		/// </summary>
		[JsonProperty("currency")]
		public string Currency { get; set; } = "";

		/// <summary>
		/// Account Type
		/// </summary>
		[JsonProperty("margin_mode")]
		public string MarginMode { get; set; } = "";

		/// <summary>
		/// Equity of the account
		/// </summary>
		[JsonProperty("equity")]
		public decimal? Equity { get; set; }

		/// <summary>
		/// Balance of the account
		/// </summary>
		[JsonProperty("total_avail_balance")]
		public decimal? TotalAvailBalance { get; set; }

		/// <summary>
		/// Margin (frozen for open orders + open interests)
		/// </summary>
		[JsonProperty("margin")]
		public decimal? Margin { get; set; }

		/// <summary>
		/// Margin frozen for open interests
		/// </summary>
		[JsonProperty("margin_frozen")]
		public decimal? MarginFrozen { get; set; }

		/// <summary>
		/// Margin frozen for open orders
		/// </summary>
		[JsonProperty("margin_for_unfilled")]
		public decimal? MarginForUnfilled { get; set; }

		/// <summary>
		/// Realized profit and loss
		/// </summary>
		[JsonProperty("realized_pnl")]
		public decimal? RealizedPnl { get; set; }

		/// <summary>
		/// Unrealized profit and loss
		/// </summary>
		[JsonProperty("unrealized_pnl")]
		public decimal? UnRealizedPnl { get; set; }

		/// <summary>
		/// Margin ratio
		/// </summary>
		[JsonProperty("margin_ratio")]
		public decimal? MarginRatio { get; set; }

		/// <summary>
		/// Maintenance Margin Ratio
		/// </summary>
		[JsonProperty("maint_margin_ratio")]
		public decimal? MaintMarginRatio { get; set; }

		/// <summary>
		/// Liquidation mode
		/// </summary>
		[JsonProperty("liqui_mode")]
		public string LiquidationMode { get; set; } = "";

		/// <summary>
		/// Transferable amount
		/// </summary>
		[JsonProperty("can_withdraw")]
		public decimal? CanWithdraw { get; set; }

		/// <summary>
		/// liquidation fee
		/// </summary>
		[JsonProperty("liqui_fee_rate")]
		public decimal? LiquidationFee { get; set; }

		/// <summary>
		/// Underlying index e.g:BTC-USD，BTC-USDT
		/// </summary>
		[JsonProperty("underlying")]
		public string Underlying { get; set; } = "";

		[JsonProperty("auto_margin")]
		public decimal? AutoMargin { get; set; }
		[JsonProperty("contracts")]
		public OkexFuturesContract[]? Contracts { get; set; }
	}
}
