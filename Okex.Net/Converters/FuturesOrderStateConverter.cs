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
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Failed, $"{OkexFuturesOrderState.Failed}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Canceled, $"{OkexFuturesOrderState.Canceled}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Open, $"{OkexFuturesOrderState.Open}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.PartiallyFilled, $"{OkexFuturesOrderState.PartiallyFilled}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.FullyFilled, $"{OkexFuturesOrderState.FullyFilled}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Submitting, $"{OkexFuturesOrderState.Submitting}"),
			new KeyValuePair<OkexFuturesOrderState, string>(OkexFuturesOrderState.Canceling, $"{OkexFuturesOrderState.Canceling}")
		};
	}
}
