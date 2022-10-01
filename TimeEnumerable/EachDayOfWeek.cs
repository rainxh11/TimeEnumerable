using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeEnumerable;

public partial class TimeEnumerable : IEnumerable<DateTime>
{
    public static IEnumerable<DateTime> EachDayOfWeekAfter(DateTime from, params DayOfWeek[] each)
        => Each(TimeSpan.FromDays(1), from.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();

    public static IEnumerable<DateTime> EachDayOfWeekBefore(DateTime from, params DayOfWeek[] each)
        => Each(TimeSpan.FromDays(-1), from.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();

    public static IEnumerable<DateTime> EachDayOfWeekBetween(DateTime from, DateTime until, params DayOfWeek[] each)
        => EachBetween(TimeSpan.FromDays(1), from.Date, until.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();
}

public static partial class DateTimeExtensions
{
    public static IEnumerable<DateTime> EachDayOfWeekAfter(this DateTime from, params DayOfWeek[] each)
        => TimeEnumerable.Each(TimeSpan.FromDays(1), from.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();

    public static IEnumerable<DateTime> EachDayOfWeekBefore(this DateTime from, params DayOfWeek[] each)
        => TimeEnumerable.Each(TimeSpan.FromDays(-1), from.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();

    public static IEnumerable<DateTime> EachDayOfWeekBetween(this DateTime from, DateTime until,
        params DayOfWeek[] each)
        => TimeEnumerable.EachBetween(TimeSpan.FromDays(1), from.Date, until.Date)
            .Where(date => each.Contains(date.DayOfWeek))
            .Distinct();
}