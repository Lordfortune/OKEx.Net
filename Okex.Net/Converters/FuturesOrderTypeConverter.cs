using System.Collections.Generic;
using CryptoExchange.Net.Converters;

namespace Okex.Net.Converters
{
	public class FuturesOrderTypeConverter : BaseConverter<OkexFuturesOrderType>
	{
		public FuturesOrderTypeConverter() : this(true) { }
		public FuturesOrderTypeConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesOrderType, string>> Mapping => new List<KeyValuePair<OkexFuturesOrderType, string>>
		{
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.NormalOrder, $"{OkexFuturesOrderType.NormalOrder}"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.PostOnly, $"{OkexFuturesOrderType.PostOnly}"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.ImmediateOrCancel, $"{OkexFuturesOrderType.ImmediateOrCancel}"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.FillOrKill, $"{OkexFuturesOrderType.FillOrKill}"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.Market, $"{OkexFuturesOrderType.Market}")
		};
	}
}
