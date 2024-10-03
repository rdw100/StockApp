using ScottPlot;
using ScottPlot.Finance;

public static class ChartHelper
{
    public static Plot PlotSmaCurves(Plot plot, List<OHLC> prices)
    {
        int[] windowSizes = { 3, 8, 20 };
        foreach (int windowSize in windowSizes)
        {
            // Calculate SMA
            SimpleMovingAverage sma = new(prices, windowSize);

            // Plot the SMA on the provided BlazorPlot
            var sp = plot.Add.Scatter(sma.Dates, sma.Means);
            sp.LegendText = $"SMA {windowSize}";
            sp.MarkerSize = 0;
            sp.LineWidth = 3;
            sp.Color = Colors.Navy.WithAlpha(1 - windowSize / 30.0);
        }

        return plot;
    }

    /// <summary>
    /// Price envelopes define upper and lower price range levels.
    /// </summary>
    /// <param name="plot">The financial plot displays price data binned into time ranges</param>
    /// <param name="prices">The price data</param>
    /// <returns>Returns a finance plots that displays price data binned into time ranges</returns>
    /// <remarks>Typical values used: 
    /// Short term: 10 day moving average, bands at 1.5 standard deviations. (1.5 times the standard dev. +/- the SMA)
    /// Medium term: 20 day moving average, bands at 2 standard deviations.
    /// Long term: 50 day moving average, bands at 2.5 standard deviations.
    /// </remarks>
    public static Plot PlotBollinger(Plot plot, List<OHLC> prices)
    {
        // calculate Bollinger Bands
        BollingerBands bb = new(prices, 20);

        // display center line (mean) as a solid line
        var sp1 = plot.Add.Scatter(bb.Dates, bb.Means);
        sp1.MarkerSize = 0;
        sp1.Color = Colors.Navy;

        // display upper bands (positive variance) as a dashed line
        var sp2 = plot.Add.Scatter(bb.Dates, bb.UpperValues);
        sp2.MarkerSize = 0;
        sp2.Color = Colors.Navy;
        sp2.LinePattern = LinePattern.Dotted;

        // display lower bands (positive variance) as a dashed line
        var sp3 = plot.Add.Scatter(bb.Dates, bb.LowerValues);
        sp3.MarkerSize = 0;
        sp3.Color = Colors.Navy;
        sp3.LinePattern = LinePattern.Dotted;
        
        return plot;
    }
}
