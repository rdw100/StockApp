namespace StockApp.Shared.Enums
{
    /// <summary>
    /// Represents time between data points.
    /// </summary>
    public enum StockInterval
    {
        [StringValue("1m")]
        OneMinutes,
        [StringValue("2m")]
        TwoMinutes,
        [StringValue("5m")]
        FiveMinutes,
        [StringValue("15m")]
        FifteenMinutes,
        [StringValue("30m")]
        ThirtyMinutes,
        [StringValue("60m")]
        SixtyMinutes,
        [StringValue("1h")]
        OneHour,
        [StringValue("1d")]
        OneDay,
        [StringValue("5d")]
        FiveDays,
        [StringValue("1wk")]
        OneWeek,
        [StringValue("1mo")]
        OneMonth,
        [StringValue("3mo")]
        ThreeMonths,
        [StringValue("max")]
        Max
    }
}