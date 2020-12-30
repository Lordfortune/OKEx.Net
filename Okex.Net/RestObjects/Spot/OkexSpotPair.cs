﻿using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
    public class OkexSpotPair
    {
        /// <summary>
        /// Trading pair symbol
        /// </summary>
        [JsonProperty("instrument_id")]
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base currency
        /// </summary>
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; } = "";

        /// <summary>
        /// Quote currency
        /// </summary>
        [JsonProperty("quote_currency")]
        public string QuoteCurrency { get; set; } = "";

        /// <summary>
        /// Minimum trading threshold
        /// </summary>
        [JsonProperty("min_size")]
        public decimal SizeMinimum { get; set; }

        /// <summary>
        /// Minimum increment size
        /// </summary>
        [JsonProperty("size_increment")]
        public decimal SizeIncrement { get; set; }

        /// <summary>
        /// 	Price increment
        /// </summary>
        [JsonProperty("tick_size")]
        public decimal PriceTickSize { get; set; }
    }
}
