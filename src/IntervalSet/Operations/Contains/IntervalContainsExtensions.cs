﻿using IntervalSet.Types;

namespace IntervalSet.Operations;
public static class IntervalContainsExtensions
{
    public static bool Contains<T>(this IInterval<T> interval, T other)
        where T : notnull, IComparable<T>, ISpanParsable<T>
    {
        var startComparison = interval.StartBound.IsUnbounded() ? -1 : interval.Start.CompareTo(other);
        var endComparison = interval.EndBound.IsUnbounded() ? -1 : other.CompareTo(interval.End);

        return startComparison < 0 && endComparison < 0
            || startComparison == 0 && interval.StartBound.IsClosed()
            || endComparison == 0 && interval.EndBound.IsClosed();
    }

    public static bool Contains<T>(this Interval<T, Open, Open> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) < 0
            && other.CompareTo(interval.End) < 0;
    }

    public static bool Contains<T>(this Interval<T, Closed, Open> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) <= 0
            && other.CompareTo(interval.End) < 0;
    }

    public static bool Contains<T>(this Interval<T, Open, Closed> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) < 0
            && other.CompareTo(interval.End) <= 0;
    }

    public static bool Contains<T>(this Interval<T, Closed, Closed> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) <= 0
            && other.CompareTo(interval.End) <= 0;
    }

    public static bool Contains<T>(this Interval<T, Open, Unbounded> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) < 0;
    }

    public static bool Contains<T>(this Interval<T, Closed, Unbounded> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return interval.Start.CompareTo(other) <= 0;
    }

    public static bool Contains<T>(this Interval<T, Unbounded, Open> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return other.CompareTo(interval.End) < 0;
    }

    public static bool Contains<T>(this Interval<T, Unbounded, Closed> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return other.CompareTo(interval.End) <= 0;
    }

    public static bool Contains<T>(this Interval<T, Unbounded, Unbounded> interval, T other)
        where T : IComparable<T>, ISpanParsable<T>
    {
        return true;
    }
}
