namespace Okex.Net.RestObjects
{
	public class OkexFuturesOrderParams
	{
		public string ClientOrderId { get; set; }
		public string InstrumentId { get; set; }
		public OkexFuturesType Type { get; set; }
		public decimal? Price { get; set; }
		public decimal Size { get; set; }
		public OkexFuturesOrderMatchPrice? MatchPrice { get; set; }
		public OkexFuturesOrderType? OrderType { get; set; }
	}
}
