using System.Collections.Generic;
using CryptoExchange.Net.Converters;

namespace Okex.Net.Converters
{
	internal class FuturesOrderStateConverter : BaseConverter<OkexFuturesOrderState>
	{
		public FuturesOrderStateConverter() : this(true) { }
		public FuturesOrderStateConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesOrderState, string>> Mapping => new List<KeyValuePair<OkexFuturesOrderState, string>>
		{
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Failed, "-2"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Canceled, "-1"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Open, "0"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.PartiallyFilled, "1"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.FullyFilled, "2"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Submitting, "3"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Canceling, "4")
		};
	}
}
