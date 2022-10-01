using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeEnumerable;

public partial class TimeEnumerable : IEnumerable<DateTime>
{
    public static IEnumerable<DateTime> EachDayTimeAfter(DateTime from, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return EachDayOfWeekAfter(from, each.Select(time => time.Day).ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }

    public static IEnumerable<DateTime> EachDayTimeBefore(DateTime from, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return EachDayOfWeekBefore(from, each.Select(time => time.Day).ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }

    public static IEnumerable<DateTime> EachDayTimeBetween(DateTime from, DateTime until, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return EachDayOfWeekBetween(from, until, occurrences.Keys.ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }
}

public static partial class DateTimeExtensions
{
    public static IEnumerable<DateTime> EachDayTimeAfter(this DateTime from, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return TimeEnumerable.EachDayOfWeekAfter(from, each.Select(time => time.Day).ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }

    public static IEnumerable<DateTime> EachDayTimeBefore(this DateTime from, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return TimeEnumerable.EachDayOfWeekBefore(from, each.Select(time => time.Day).ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }

    public static IEnumerable<DateTime> EachDayTimeBetween(this DateTime from, DateTime until, params DayTime[] each)
    {
        var occurrences = each
            .GroupBy(x => x.Day)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return TimeEnumerable.EachDayOfWeekBetween(from, until, occurrences.Keys.ToArray())
            .SelectMany(time => occurrences[time.DayOfWeek]
                .Select(timeDay => new DateTime(time.Year, time.Month, time.Day,
                    timeDay.Time.Hour, timeDay.Time.Minute, timeDay.Time.Second, timeDay.Time.Millisecond)))
            .Distinct()
            .OrderBy(x => x);
    }
}