using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TimeEnumerable;

public partial class TimeEnumerable : IEnumerable<DateTime>
{
    public IEnumerator<DateTime> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    private readonly IEnumerable<DateTime> _enumerable = Enumerable.Empty<DateTime>();
}