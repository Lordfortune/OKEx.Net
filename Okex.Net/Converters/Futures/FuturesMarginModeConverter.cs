using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using Okex.Net.Enums;

namespace Okex.Net.Converters.Futures
{
	internal class FuturesMarginModeConverter : BaseConverter<OkexFuturesMarginMode>
	{
		public FuturesMarginModeConverter() : this(true) { }
		public FuturesMarginModeConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesMarginMode, string>> Mapping => new List<KeyValuePair<OkexFuturesMarginMode, string>>
		{
			new KeyValuePair<OkexFuturesMarginMode, string>(OkexFuturesMarginMode.Crossed, "crossed"),
			new KeyValuePair<OkexFuturesMarginMode, string>(OkexFuturesMarginMode.Fixed, "fixed"),
		};
	}
}
