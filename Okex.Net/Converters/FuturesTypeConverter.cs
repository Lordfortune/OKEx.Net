using System.Collections.Generic;
using CryptoExchange.Net.Converters;

namespace Okex.Net.Converters
{

	internal class FuturesTypeConverter : BaseConverter<OkexFuturesType>
	{
		public FuturesTypeConverter() : this(true) { }
		public FuturesTypeConverter(bool quotes) : base(quotes) { }

		protected override List<KeyValuePair<OkexFuturesType, string>> Mapping => new List<KeyValuePair<OkexFuturesType, string>>
			{
				new KeyValuePair<OkexFuturesType, string>(OkexFuturesType.OpenLong, "1"),
				new KeyValuePair<OkexFuturesType, string>(OkexFuturesType.OpenShort, "2"),
				new KeyValuePair<OkexFuturesType, string>(OkexFuturesType.CloseLong, "3"),
				new KeyValuePair<OkexFuturesType, string>(OkexFuturesType.CloseShort, "4")
			};
	}
}
