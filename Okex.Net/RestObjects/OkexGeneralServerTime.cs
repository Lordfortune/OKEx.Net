using Newtonsoft.Json;
using System;

namespace Okex.Net.RestObjects
{
    public class OkexGeneralServerTime
    {
        [JsonProperty("iso")]
        public DateTime IsoTime { get; set; }

        [JsonProperty("epoch")]
        public decimal EpochTime { get; set; }
    }
}
