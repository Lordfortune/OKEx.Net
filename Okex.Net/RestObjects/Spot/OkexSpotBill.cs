﻿using Newtonsoft.Json;
using Okex.Net.Converters;
using Okex.Net.Enums;
using System;

namespace Okex.Net.RestObjects
{
    public class OkexSpotBill
    {
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Token symbol
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = "";

        /// <summary>
        /// Remaining balance
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Bill ID
        /// </summary>
        [JsonProperty("ledger_id")]
        public long LedgerId { get; set; }

        /// <summary>
        /// Amount changed
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Type of bills
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(SpotBillTypeConverter))]
        public OkexSpotBillType Type { get; set; }

        /// <summary>
        /// Order details when type is trade or fee
        /// </summary>
        [JsonProperty("details")]
        public OkexSpotBillDetails? Details { get; set; }
    }

    public class OkexSpotBillDetails
    {
        [JsonProperty("instrument_id")]
        public string Symbol { get; set; } = "";

        //[JsonProperty("product_id")]
        //public string ProductId { get; set; } = "";

        [JsonProperty("order_id")]
        public long OrderId { get; set; }
    }
}
