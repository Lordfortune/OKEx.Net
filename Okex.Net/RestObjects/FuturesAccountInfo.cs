using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Okex.Net.RestObjects
{
	public class FuturesAccountInfo
	{
		[JsonProperty("info")]
		public Dictionary<string, OkexFuturesAccount> Info { get; set; }
	}
}
