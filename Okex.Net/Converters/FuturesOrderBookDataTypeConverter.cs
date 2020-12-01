using System.Collections.Generic;
using CryptoExchange.Net.Converters;

namespace Okex.Net.Converters
{
	public class FuturesOrderBookDataTypeConverter : BaseConverter<OkexFuturesOrderBookDataType>
	{
		public FuturesOrderBookDataTypeConverter() : this(true) { }
		public FuturesOrderBookDataTypeConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesOrderBookDataType, string>> Mapping => new List<KeyValuePair<OkexFuturesOrderBookDataType, string>>
		{
			new KeyValuePair<OkexFuturesOrderBookDataType, string>(OkexFuturesOrderBookDataType.Api, "api"),
			new KeyValuePair<OkexFuturesOrderBookDataType, string>(OkexFuturesOrderBookDataType.DepthTop5, "depth5"),
			new KeyValuePair<OkexFuturesOrderBookDataType, string>(OkexFuturesOrderBookDataType.DepthPartial, "partial"),
			new KeyValuePair<OkexFuturesOrderBookDataType, string>(OkexFuturesOrderBookDataType.DepthUpdate, "update"),
		};
	}
}
