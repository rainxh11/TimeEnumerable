using System;
using System.Collections.Generic;
using System.Text;

namespace TimeEnumerable;

public class DayTime : IEquatable<DayTime>, IEquatable<DateTime>
{
    public DayOfWeek Day { get; init; }
    public TimeOnly Time { get; init; }

    public static implicit operator DayTime(DateTime dateTime)
    {
        return new()
               {
                   Time = new TimeOnly(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond),
                   Day  = dateTime.DayOfWeek
               };
    }

    public void Deconstruct(out DayOfWeek day, out TimeOnly time)
    {
        day  = Day;
        time = Time;
    }

    public bool Equals(DayTime other)
    {
        return Day == other?.Day
               && Time == other?.Time;
    }

    public bool Equals(DateTime other)
    {
        return Day == other.DayOfWeek
               && Time == new TimeOnly(other.Hour, other.Minute, other.Second, other.Millisecond);
    }
}