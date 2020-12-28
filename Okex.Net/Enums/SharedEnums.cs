namespace Okex.Net.Enums
{
	public enum OkexOrderBookDataType
	{
		/// <summary>
		/// This does not exists normally. Used for Rest Api response
		/// </summary>
		Api,

		/// <summary>
		/// This does not exists normally. Used for Web Socket Depth5 response
		/// </summary>
		DepthTop5,

		/// <summary>
		/// Web Socket Order Book Partial Data
		/// </summary>
		DepthPartial,

		/// <summary>
		/// Web Socket Order Book Update Data
		/// </summary>
		DepthUpdate,
	}

	public enum OkexOrderBookDepth
	{
		Depth5,
		Depth400,
		TickByTick,
	}

}
