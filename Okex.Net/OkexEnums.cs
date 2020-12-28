namespace Okex.Net
{
	public enum OkexSpotPeriod
	{
		/// <summary>
		/// 1m
		/// </summary>
		OneMinute,

		/// <summary>
		/// 3m
		/// </summary>
		ThreeMinutes,

		/// <summary>
		/// 5m
		/// </summary>
		FiveMinutes,

		/// <summary>
		/// 15m
		/// </summary>
		FifteenMinutes,

		/// <summary>
		/// 30m
		/// </summary>
		ThirtyMinutes,

		/// <summary>
		/// 1h
		/// </summary>
		OneHour,

		/// <summary>
		/// 2h
		/// </summary>
		TwoHours,

		/// <summary>
		/// 4h
		/// </summary>
		FourHours,

		/// <summary>
		/// 6h
		/// </summary>
		SixHours,

		/// <summary>
		/// 12h
		/// </summary>
		TwelveHours,

		/// <summary>
		/// 1d
		/// </summary>
		OneDay,

		/// <summary>
		/// 1w
		/// </summary>
		OneWeek
	}

	public enum OkexSpotOrderType
	{
		/// <summary>
		/// Limit Order
		/// </summary>
		Limit,

		/// <summary>
		/// Market Order
		/// </summary>
		Market,
	}

	public enum OkexSpotOrderSide
	{
		/// <summary>
		/// Buy
		/// </summary>
		Buy,

		/// <summary>
		/// Sell
		/// </summary>
		Sell
	}

	public enum OkexSpotBillType
	{
		/// <summary>
		/// Funds transferred in/out
		/// </summary>
		Transfer,

		/// <summary>
		/// Funds changed from trades
		/// </summary>
		Trade,

		/// <summary>
		/// Fee rebate as per fee schedule
		/// </summary>
		Rebate,

		/// <summary>
		/// Fee rebate as per fee schedule
		/// </summary>
		Fee,

		/*
		Deposit,
		Withdraw,
		Buy,
		Sell,
		BeginnersTask,
		InviteFriendsToCompleteBeginnersTask,
		DeductionOfTaskReward,
		InvitationBonus,
		CanceledWithdrawal,
		DeductedForEvents,
		ReceivedFromEvents,
		TransferFromFutures,
		TransferToFutures,
		TransactionFeeRebate,
		ReceiveRedPacket,
		SendRedPacket,
		C2CBuy,
		C2CSell,
		Deduct,
		Convert,
		TransferToAssetsAccount,
		TransferFromAssetsAccount,
		TransferToC2CAccount,
		TransferFromC2CAccount,
		TransferToMarginAccount,
		TransferFromMarginAccount,
		Borrow,
		Repay,
		MarketMakerBonus,
		MarketMakerRebate,
		FeeSettledWithLP,
		PurchaseLoyaltyPoints,
		TransferLoyaltyPoints,
		MMProgramBonus,
		MMProgramRebate,
		TransferFromSpotAccount,
		TransferToSpotAccount,
		TransferToETT,
		TransferFromETT,
		DeductedForMining,
		GainFromMining,
		ExtraYield,
		IncentiveBonusDistribution,
		TransferFromOKPiggyBank,
		TransferToOKPiggyBank,
		TransferFromSwapAccount,
		TransferToSwapAccount,
		RepayBonus,
		MarginFeeSettledWithLP
		*/
	}

	public enum OkexSpotTimeInForce
	{
		NormalOrder,
		PostOnly,
		FillOrKil,
		ImmediateOrCancel
	}

	public enum OkexSpotOrderState
	{
		Failed,
		Canceled,
		Open,
		PartiallyFilled,
		FullyFilled,
		Submitting,
		Canceling,

		/// <summary>
		/// Open + PartiallyFilled
		/// </summary>
		Incomplete,

		/// <summary>
		/// Canceled + fully Filled
		/// </summary>
		Complete
	}

	public enum OkexSpotOrderBookDepth
	{
		Depth5,
		Depth400,
		TickByTick,
	}

	public enum OkexSpotOrderBookDataType
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


	public enum OkexSpotMarginOrderSourceType
	{
		Spot,
		Margin,
	}

	public enum OkexFundingAccountType
	{
		TotalAccountAssets,
		Spot,
		Futures,
		C2C,
		Margin,
		FundingAccount,
		PiggyBank,
		Swap,
		Option,
		MiningAccount
	}

	public enum OkexFundingTransferAccountType
	{
		SubAccount,
		Spot,
		Futures,
		C2C,
		Margin,
		FundingAccount,
		PiggyBank,
		Swap,
		Option,
	}

	public enum OkexFundingBillType
	{
		Deposit,
		Withdrawal,
		CanceledWithdrawal,
		TransferIntoFutures,
		TransferFromFutures,
		TransferIntoSubAccount,
		TransferFromSubAccount,
		Claim,
		TransferIntoETT,
		TransferFromETT,
		TransferIntoC2C,
		TransferFromC2C,
		TransferIntoMargin,
		TransferFromMargin,
		TransferIntoSpotAccount,
		TransferFromSpotAccount,
	}

	public enum OkexFundingDepositStatus
	{
		WaitingForConfirmation,
		DepositCredited,
		DepositSuccessful,
	}

	public enum OkexFundingWithdrawalStatus
	{
		PendingCancel,
		Cancelled,
		Failed,
		Pending,
		Sending,
		Sent,
		AwaitingEmailVerification,
		AwaitingManualVerification,
		AwaitingIdentityVerification
	}

	public enum OkexFundinWithdrawalDestination
	{
		OKEx,
		CoinAll,
		Others,
	}

	public enum OkexFuturesOrderBookDepth
	{
		Depth5,
		Depth400,
		TickByTick,
	}

	public enum OkexFuturesOrderBookDataType
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

	public enum OkexFuturesType
	{
		OpenLong = 1,
		OpenShort = 2,
		CloseLong = 3,
		CloseShort = 4
	}


	public enum OkexFuturesOrderMatchPrice
	{
		No = 0,
		Yes = 1
	}

	public enum OkexFuturesOrderState
	{
		Failed = -2,
		Canceled = -1,
		Open = 0,
		PartiallyFilled  = 1,
		FullyFilled = 2,
		Submitting = 3,
		Canceling = 4
	}
}
