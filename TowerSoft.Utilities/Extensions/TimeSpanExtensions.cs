namespace TowerSoft.Utilities.Extensions {
    /// <summary>
    /// TimeSpan extension methods
    /// </summary>
    public static class TimeSpanExtensions {
        /// <summary>
        /// Convert a TimeSpan to a long string. Example: 2 hours, 1 minute, 34 seconds
        /// </summary>
        /// <param name="time">TimeSpan to convert</param>
        /// <returns>
        /// Example output values:<br/>
        /// 24 seconds<br/>
        /// 1 minute, 35 seconds<br/>
        /// 1 hour, 24 minutes, 1 second
        /// </returns>
        public static string ToLongString(this TimeSpan time) {
            TimeSpan duration = time.Duration();

            string formatted = string.Format("{0}{1}{2}{3}",
                duration.Days > 0 ? string.Format("{0:0} day{1}, ", duration.Days, duration.Days == 1 ? string.Empty : "s") : string.Empty,
                duration.Hours > 0 ? string.Format("{0:0} hour{1}, ", duration.Hours, duration.Hours == 1 ? string.Empty : "s") : string.Empty,
                duration.Minutes > 0 ? string.Format("{0:0} minute{1}, ", duration.Minutes, duration.Minutes == 1 ? string.Empty : "s") : string.Empty,
                duration.Seconds > 0 ? string.Format("{0:0} second{1}", duration.Seconds, duration.Seconds == 1 ? string.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted[..^2];

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }

        /// <summary>
        /// Convert a TimeSpan to a short string. Example: 2h, 1m, 34s
        /// </summary>
        /// <param name="time">TimeSpan to convert</param>
        /// <returns>
        /// Example output values:<br/>
        /// 24s<br/>
        /// 1m, 35s<br/>
        /// 1h, 24m, 1s
        /// </returns>
        public static string ToShortString(this TimeSpan time) {
            TimeSpan duration = time.Duration();

            string formatted = string.Format("{0}{1}{2}{3}",
                duration.Days > 0 ? string.Format("{0:0}d, ", duration.Days) : string.Empty,
                duration.Hours > 0 ? string.Format("{0:0}h, ", duration.Hours) : string.Empty,
                duration.Minutes > 0 ? string.Format("{0:0}m, ", duration.Minutes) : string.Empty,
                duration.Seconds > 0 ? string.Format("{0:0}s", duration.Seconds) : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted[..^2];

            if (string.IsNullOrEmpty(formatted)) formatted = "0s";

            return formatted;
        }

        /// <summary>
        /// Output a rounded time string to display how long ago something happened
        /// </summary>
        /// <param name="time">TimeSpan of the duration</param>
        /// <returns>
        /// Example output values:<br/>
        /// Right now <c>(Used if less than 20 seconds ago)</c><br/>
        /// 24 seconds ago<br/>
        /// 1 minute ago<br/>
        /// 2 hours ago
        /// </returns>
        public static string ToRoundedString(this TimeSpan time) {
            TimeSpan duration = time.Duration();
            if (duration.Days > 365) {
                int years = (int)Math.Floor(duration.Days / 365.25);
                return $"{years} year{(years == 1 ? "" : "s")} ago";
            }

            if (duration.Days > 0) return $"{duration.Days} day{(duration.Days == 1 ? "" : "s")} ago";
            if (duration.Hours > 0) return $"{duration.Hours} hour{(duration.Hours == 1 ? "" : "s")} ago";
            if (duration.Minutes > 0) return $"{duration.Minutes} minute{(duration.Minutes == 1 ? "" : "s")} ago";

            if (duration.Seconds > 20)
                return $"{duration.Seconds} seconds ago";
            return "Right now";
        }
    }
}
