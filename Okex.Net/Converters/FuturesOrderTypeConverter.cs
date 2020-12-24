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
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.NormalOrder, "0"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.PostOnly, "1"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.FillOrKill, "2"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.ImmediateOrCancel, "3"),
			new KeyValuePair<OkexFuturesOrderType, string>(OkexFuturesOrderType.Market, "4")
		};
	}
}
