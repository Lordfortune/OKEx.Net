﻿using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
    public class OkexMarginLoanResponse
    {
        /// <summary>
        /// Result of the request
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }

        /// <summary>
        /// Borrow ID
        /// </summary>
        [JsonProperty("borrow_id")]
        public long? BorrowId { get; set; }

        /// <summary>
        /// client-supplied order ID
        /// </summary>
        [JsonProperty("client_oid")]
        public string ClientOrderId { get; set; } = "";
    }

}