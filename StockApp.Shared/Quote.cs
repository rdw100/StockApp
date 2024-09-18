using System.Text.Json.Serialization;

namespace StockApp.Shared.Api
{
    public class QuoteResult
    {
        [JsonPropertyName("quoteResponse")]
        public QuoteResponse QuoteResponse { get; set; }
    }

    public partial class QuoteResponse
    {
        [JsonPropertyName("result")]
        public List<Result> Result { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }
    }

    public partial class Result
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("quoteType")]
        public string QuoteType { get; set; }

        [JsonPropertyName("typeDisp")]
        public string TypeDisp { get; set; }

        [JsonPropertyName("quoteSourceName")]
        public string QuoteSourceName { get; set; }

        [JsonPropertyName("triggerable")]
        public bool Triggerable { get; set; }

        [JsonPropertyName("customPriceAlertConfidence")]
        public string CustomPriceAlertConfidence { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("regularMarketChangePercent")]
        public double RegularMarketChangePercent { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonPropertyName("marketState")]
        public string MarketState { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("longName")]
        public string LongName { get; set; }

        [JsonPropertyName("messageBoardId")]
        public string MessageBoardId { get; set; }

        [JsonPropertyName("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonPropertyName("exchangeTimezoneShortName")]
        public string ExchangeTimezoneShortName { get; set; }

        [JsonPropertyName("gmtOffSetMilliseconds")]
        public long GmtOffSetMilliseconds { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("esgPopulated")]
        public bool EsgPopulated { get; set; }

        [JsonPropertyName("averageAnalystRating")]
        public string AverageAnalystRating { get; set; }

        [JsonPropertyName("tradeable")]
        public bool Tradeable { get; set; }

        [JsonPropertyName("cryptoTradeable")]
        public bool CryptoTradeable { get; set; }

        [JsonPropertyName("hasPrePostMarketData")]
        public bool HasPrePostMarketData { get; set; }

        [JsonPropertyName("firstTradeDateMilliseconds")]
        public long FirstTradeDateMilliseconds { get; set; }

        [JsonPropertyName("priceHint")]
        public long PriceHint { get; set; }

        [JsonPropertyName("preMarketChange")]
        public double PreMarketChange { get; set; }

        [JsonPropertyName("preMarketChangePercent")]
        public double PreMarketChangePercent { get; set; }

        [JsonPropertyName("preMarketTime")]
        public long PreMarketTime { get; set; }

        [JsonPropertyName("preMarketPrice")]
        public double PreMarketPrice { get; set; }

        [JsonPropertyName("regularMarketChange")]
        public double RegularMarketChange { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonPropertyName("regularMarketDayHigh")]
        public double RegularMarketDayHigh { get; set; }

        [JsonPropertyName("regularMarketDayRange")]
        public string RegularMarketDayRange { get; set; }

        [JsonPropertyName("regularMarketDayLow")]
        public double RegularMarketDayLow { get; set; }

        [JsonPropertyName("regularMarketVolume")]
        public long RegularMarketVolume { get; set; }

        [JsonPropertyName("regularMarketPreviousClose")]
        public double RegularMarketPreviousClose { get; set; }

        [JsonPropertyName("bid")]
        public double Bid { get; set; }

        [JsonPropertyName("ask")]
        public double Ask { get; set; }

        [JsonPropertyName("bidSize")]
        public long BidSize { get; set; }

        [JsonPropertyName("askSize")]
        public long AskSize { get; set; }

        [JsonPropertyName("fullExchangeName")]
        public string FullExchangeName { get; set; }

        [JsonPropertyName("financialCurrency")]
        public string FinancialCurrency { get; set; }

        [JsonPropertyName("regularMarketOpen")]
        public double RegularMarketOpen { get; set; }

        [JsonPropertyName("averageDailyVolume3Month")]
        public long AverageDailyVolume3Month { get; set; }

        [JsonPropertyName("averageDailyVolume10Day")]
        public long AverageDailyVolume10Day { get; set; }

        [JsonPropertyName("fiftyTwoWeekLowChange")]
        public double FiftyTwoWeekLowChange { get; set; }

        [JsonPropertyName("fiftyTwoWeekLowChangePercent")]
        public double FiftyTwoWeekLowChangePercent { get; set; }

        [JsonPropertyName("fiftyTwoWeekRange")]
        public string FiftyTwoWeekRange { get; set; }

        [JsonPropertyName("fiftyTwoWeekHighChange")]
        public double FiftyTwoWeekHighChange { get; set; }

        [JsonPropertyName("fiftyTwoWeekHighChangePercent")]
        public double FiftyTwoWeekHighChangePercent { get; set; }

        [JsonPropertyName("fiftyTwoWeekLow")]
        public double FiftyTwoWeekLow { get; set; }

        [JsonPropertyName("fiftyTwoWeekHigh")]
        public double FiftyTwoWeekHigh { get; set; }

        [JsonPropertyName("fiftyTwoWeekChangePercent")]
        public double FiftyTwoWeekChangePercent { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dividendDate")]
        public long? DividendDate { get; set; }

        [JsonPropertyName("earningsTimestamp")]
        public long EarningsTimestamp { get; set; }

        [JsonPropertyName("earningsTimestampStart")]
        public long EarningsTimestampStart { get; set; }

        [JsonPropertyName("earningsTimestampEnd")]
        public long EarningsTimestampEnd { get; set; }

        [JsonPropertyName("earningsCallTimestampStart")]
        public long EarningsCallTimestampStart { get; set; }

        [JsonPropertyName("earningsCallTimestampEnd")]
        public long EarningsCallTimestampEnd { get; set; }

        [JsonPropertyName("isEarningsDateEstimate")]
        public bool IsEarningsDateEstimate { get; set; }

        [JsonPropertyName("trailingAnnualDividendRate")]
        public double TrailingAnnualDividendRate { get; set; }

        [JsonPropertyName("trailingPE")]
        public double TrailingPe { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dividendRate")]
        public double? DividendRate { get; set; }

        [JsonPropertyName("trailingAnnualDividendYield")]
        public double TrailingAnnualDividendYield { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dividendYield")]
        public double? DividendYield { get; set; }

        [JsonPropertyName("epsTrailingTwelveMonths")]
        public double EpsTrailingTwelveMonths { get; set; }

        [JsonPropertyName("epsForward")]
        public double EpsForward { get; set; }

        [JsonPropertyName("epsCurrentYear")]
        public double EpsCurrentYear { get; set; }

        [JsonPropertyName("priceEpsCurrentYear")]
        public double PriceEpsCurrentYear { get; set; }

        [JsonPropertyName("sharesOutstanding")]
        public long SharesOutstanding { get; set; }

        [JsonPropertyName("bookValue")]
        public double BookValue { get; set; }

        [JsonPropertyName("fiftyDayAverage")]
        public double FiftyDayAverage { get; set; }

        [JsonPropertyName("fiftyDayAverageChange")]
        public double FiftyDayAverageChange { get; set; }

        [JsonPropertyName("fiftyDayAverageChangePercent")]
        public double FiftyDayAverageChangePercent { get; set; }

        [JsonPropertyName("twoHundredDayAverage")]
        public double TwoHundredDayAverage { get; set; }

        [JsonPropertyName("twoHundredDayAverageChange")]
        public double TwoHundredDayAverageChange { get; set; }

        [JsonPropertyName("twoHundredDayAverageChangePercent")]
        public double TwoHundredDayAverageChangePercent { get; set; }

        [JsonPropertyName("marketCap")]
        public long MarketCap { get; set; }

        [JsonPropertyName("forwardPE")]
        public double ForwardPe { get; set; }

        [JsonPropertyName("priceToBook")]
        public double PriceToBook { get; set; }

        [JsonPropertyName("sourceInterval")]
        public long SourceInterval { get; set; }

        [JsonPropertyName("exchangeDataDelayedBy")]
        public long ExchangeDataDelayedBy { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
