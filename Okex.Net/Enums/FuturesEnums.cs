namespace Okex.Net.Enums
{
	public enum OkexFuturesMarginMode
	{
		Crossed,
		Fixed
	}

	public enum OkexFuturesTimeInForce
	{
		NormalOrder,
		PostOnly,
		FillOrKil,
		ImmediateOrCancel,
		Market
	}

	public enum OkexFuturesOrderType
	{
		OpenLong,
		OpenShort,
		CloseLong,
		CloseShort,
	}
}
