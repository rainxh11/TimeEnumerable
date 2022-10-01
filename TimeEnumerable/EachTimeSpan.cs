using System;
using System.Collections.Generic;
using System.Text;

namespace TimeEnumerable;

public partial class TimeEnumerable : IEnumerable<DateTime>
{
    public static IEnumerable<DateTime> Each(TimeSpan each, DateTime from)
    {
        yield return from;
        var current = from;

        var spanIsNegative = each == each.Negate();

        while (spanIsNegative
                   ? current >= DateTime.MinValue
                   : current <= DateTime.MaxValue)
            yield return current += each;
    }

    public static IEnumerable<DateTime> EachBetween(TimeSpan each, DateTime from, DateTime until)
    {
        var start = from <= until ? from : until;
        var end = until > from ? until : from;
        yield return start;

        while (start <= end)
            yield return start += each.Duration();
    }
}

public static partial class DateTimeExtensions
{
    public static IEnumerable<DateTime> Each(this DateTime from, TimeSpan each)
    {
        yield return from;
        var current = from;

        var spanIsNegative = each == each.Negate();

        while (spanIsNegative
                   ? current >= DateTime.MinValue
                   : current <= DateTime.MaxValue)
            yield return current += each;
    }

    public static IEnumerable<DateTime> EachBetween(this DateTime from, DateTime until, TimeSpan each)
    {
        var start = from <= until ? from : until;
        var end = until > from ? until : from;
        yield return start;

        while (start <= end)
            yield return start += each.Duration();
    }
}