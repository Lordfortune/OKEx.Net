﻿using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
    public class OkexFundingAssetBalance
    {
        /// <summary>
        /// Token symbol, e.g. 'BTC'
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = "";

        /// <summary>
        /// Amount available
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// Remaining balance
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Amount on hold (unavailable)
        /// </summary>
        [JsonProperty("hold")]
        public decimal Hold { get; set; }
    }
}
