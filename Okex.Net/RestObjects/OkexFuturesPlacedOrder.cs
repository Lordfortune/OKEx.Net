using Newtonsoft.Json;

namespace Okex.Net.RestObjects
{
	public class OkexFuturesPlacedOrder
	{
		/// <summary>
		/// Order ID. If order placement fails, this value will be -1.
		/// </summary>
		[JsonProperty("order_id")]
		public long OrderId { get; set; }

		/// <summary>
		/// Client-supplied order ID
		/// </summary>
		[JsonProperty("client_oid")]
		public string ClientOrderId { get; set; } = "";

		/// <summary>
		/// The result of the request
		/// </summary>
		[JsonProperty("result")]
		public string Result { get; set; }

		/// <summary>
		///Error code for order placement. Success = 0
		/// </summary>
		[JsonProperty("error_code")]
		public string ErrorCode { get; set; } = "";

		/// <summary>
		/// Error message will be returned if order placement fails, otherwise it will be blank
		/// </summary>
		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; } = "";
	}
}
