using System.Collections.Generic;
using CryptoExchange.Net.Converters;

namespace Okex.Net.Converters
{
	internal class FuturesMatchPriceConverter : BaseConverter<OkexFuturesOrderMatchPrice>
	{
		public FuturesMatchPriceConverter() : this(true) { }
		public FuturesMatchPriceConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesOrderMatchPrice, string>> Mapping => new List<KeyValuePair<OkexFuturesOrderMatchPrice, string>>
			{
				new KeyValuePair<OkexFuturesOrderMatchPrice, string>(OkexFuturesOrderMatchPrice.No, "0"),
				new KeyValuePair<OkexFuturesOrderMatchPrice, string>(OkexFuturesOrderMatchPrice.Yes, "1")
			};
	}
}
