﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbounded;

namespace IntervalRecords.Types;
public sealed record OpenClosedInterval<T> : Interval<T>
    where T : struct, IEquatable<T>, IComparable<T>, IComparable
{
    public static new readonly ClosedInterval<T> Empty = new ClosedInterval<T>(Unbounded<T>.NaN, Unbounded<T>.NaN);

    public static readonly ClosedInterval<T> Unbounded = new ClosedInterval<T>(Unbounded<T>.NegativeInfinity, Unbounded<T>.PositiveInfinity);

    public override IntervalType IntervalType => IntervalType.OpenClosed;

    public override bool StartInclusive => false;

    public override bool EndInclusive => true;

    public OpenClosedInterval(Unbounded<T> start, Unbounded<T> end) : base(start, end)
    {
    }

    public static OpenClosedInterval<T> RightBounded(T end) => new OpenClosedInterval<T>(Unbounded<T>.NegativeInfinity, end);

    public static OpenClosedInterval<T> LeftBounded(T start) => new OpenClosedInterval<T>(start, Unbounded<T>.PositiveInfinity);

    public override bool Contains(Unbounded<T> value)
    {
        return Start < value && value <= End;
    }

    public override bool Overlaps(Interval<T> other)
    {
        return Start < other.End && other.Start < End
            || End == other.Start && other.StartInclusive;
    }

    public override bool IsConnected(Interval<T> other)
    {
        return other.EndInclusive && Start <= other.End && other.Start <= End;
    }
}