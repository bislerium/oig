using oig.domain.Entities;

namespace oig.domain.Shared
{

    public static class Extensions
    {
        public const string TIMEZONE_ID = "NST"; // Default TimeZone ID: Nepal Standard Time

        public static DateTimeOffset GetLocalInvoiceDateTimeUTCOffset<T>(this Invoice<T> invoice, string timeZoneID = TIMEZONE_ID)
        {
            return GetLocalDateTime(invoice.InvoiceDateTimeUTCOffset, timeZoneID);
        }

        public static DateTimeOffset GetLocalInvoiceDueDateTimeUTCOffset<T>(this Invoice<T> invoice, string timeZoneID = TIMEZONE_ID)
        {
            return GetLocalDateTime(invoice.InvoiceDueDateTimeUTCOffset, timeZoneID);
        }

        public static DateTimeOffset GetLocalOrderdDateTimeUTCOffset<T>(this Order<T> order, string timeZoneID = TIMEZONE_ID)
        {
            return GetLocalDateTime(order.OrderedDateTimeUTCOffset, timeZoneID);
        }

        // Default to time zone for Nepal (Nepal Standard Time - NST)
        public static DateTimeOffset GetLocalDateTime(DateTimeOffset dateTimeOffset, string timeZoneID = TIMEZONE_ID)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneID);
            return TimeZoneInfo.ConvertTime(dateTimeOffset, localTimeZone);
        }

        // This example displays the format and corresponding output:
        //       d: 6/15/2008
        //       D: Sunday, June 15, 2008
        //       f: Sunday, June 15, 2008 9:15 PM
        //       F: Sunday, June 15, 2008 9:15:07 PM
        //       g: 6/15/2008 9:15 PM
        //       G: 6/15/2008 9:15:07 PM
        //       m: June 15
        //       o: 2008-06-15T21:15:07.0000000
        //       R: Sun, 15 Jun 2008 21:15:07 GMT
        //       s: 2008-06-15T21:15:07
        //       t: 9:15 PM
        //       T: 9:15:07 PM
        //       u: 2008-06-15 21:15:07Z
        //       U: Monday, June 16, 2008 4:15:07 AM
        //       y: June, 2008
        //
        //       'h:mm:ss.ff t': 9:15:07.00 P
        //       'd MMM yyyy': 15 Jun 2008
        //       'HH:mm:ss.f': 21:15:07.0
        //       'dd MMM HH:mm:ss': 15 Jun 21:15:07
        //       '\Mon\t\h\: M': Month: 6
        //       'HH:mm:ss.ffffzzz': 21:15:07.0000-07:00
    }
}
