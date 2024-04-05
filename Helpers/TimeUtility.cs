using System;
namespace HelpSpace.Helpers
{
    public class TimeUtility
    {
        public static DateTime CurrentKyivTime()
        {
            TimeZoneInfo Eastern_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Europe/Kiev");
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Eastern_Standard_Time);
            return dateTime_Eastern;
        }

        public static DateTime CurrentSofiaTime()
        {
            TimeZoneInfo Eastern_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Europe/Sofia");
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Eastern_Standard_Time);
            return dateTime_Eastern;
        }

        public static DateTime CurrentUTCTime()
        {
            return DateTime.UtcNow;
        }
    }
}

