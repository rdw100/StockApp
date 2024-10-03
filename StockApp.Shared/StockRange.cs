namespace StockApp.Shared.Enums
{
    /// <summary>
    /// Represents length of periodic data.
    /// </summary>
    public enum StockRange
    {
        [StringValue("1d")]
        OneDay,
        [StringValue("5d")]
        FiveDays,
        [StringValue("1mo")]
        OneMonth,
        [StringValue("3mo")]
        ThreeMonths,
        [StringValue("6mo")]
        SixMonths,
        [StringValue("1y")]
        OneYear,
        [StringValue("2y")]
        TwoYears,
        [StringValue("5y")]
        FiveYears,
        [StringValue("10y")]
        TenYears,
        [StringValue("ytd")]
        YearToDate,
        [StringValue("max")]
        Max
    }
}