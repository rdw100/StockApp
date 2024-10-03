namespace StockApp.Shared
{
    using System;

    /// <summary>
    /// Calculates the Unix timestamp conversions, based on seconds, for date computation.
    /// </summary>
    public class UnixTimestampCalculator
    {
        protected readonly DateTime day;

        public long MondayUnixTime { get; private set; }
        public long FridayUnixTime { get; private set; }

        public UnixTimestampCalculator() { }

        /// <summary>
        /// Calculates nearest Monday and Friday.
        /// </summary>
        /// <param name="dateTime">A date and time of day.</param>
        public UnixTimestampCalculator(DateTime dateTime)
        {
            day = dateTime;
            MondayUnixTime = GetMondayUnixTimestamp(dateTime);
            FridayUnixTime = GetFridayUnixTimestamp(dateTime);
        }

        /// <summary>
        /// Calculates the most recent Monday.
        /// </summary>
        /// <param name="dateTime">A date and time of day.</param>
        /// <returns>Returns the most recent Monday.</returns>
        public long GetMondayUnixTimestamp(DateTime dateTime)
        {
            // Find the most recent Monday (or today if it's Monday)
            DateTime monday = GetMostRecentMonday(dateTime);

            // Convert to Unix timestamp
            //return ((DateTimeOffset)monday).ToUnixTimeSeconds();
            return ToUnixTime(monday);
        }

        /// <summary>
        /// Calculates Friday, based on recent Monday.
        /// </summary>
        /// <param name="dateTime">A date and time of day.</param>
        /// <returns>Returns the most recent Friday.</returns>
        public long GetFridayUnixTimestamp(DateTime dateTime)
        {
            // Find the most recent Monday (or today if it's Monday)
            DateTime monday = GetMostRecentMonday(dateTime);

            // Calculate the Unix timestamp for Friday (5 days after Monday)
            DateTime friday = monday.AddDays(4);

            // Convert to Unix timestamp
            //return ((DateTimeOffset)friday).ToUnixTimeSeconds();
            return ToUnixTime(friday);
        }

        /// <summary>
        /// Calculates recent Monday.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        private DateTime GetMostRecentMonday(DateTime currentDate)
        {
            int daysToSubtract = (int)currentDate.DayOfWeek - (int)DayOfWeek.Monday;
            if (daysToSubtract < 0)
            {
                daysToSubtract += 7;
            }
            return currentDate.Date.AddDays(-daysToSubtract);
        }

        /// <summary>
        /// Calculates Unix timestamp in seconds past epoch from DateTime.
        /// </summary>
        /// <param name="dateTime">DateTime as Date and Time of day.</param>
        /// <returns>Returns Unix timestamp in seconds past epoch</returns>
        public static long ToUnixTime(DateTime dateTime)
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }

        /// <summary>
        /// Calculates DateTime from Unix timestamp in seconds past epoch.
        /// </summary>
        /// <param name="unixTime">Unix timestamp</param>
        /// <returns>Returns DateTime from Unix timestamp in seconds past epoch</returns>
        public static DateTime ToDateTime(long unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTime = epoch.AddSeconds(unixTime).ToLocalTime();
            return dateTime;
        }
    }
}