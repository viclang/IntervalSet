﻿namespace IntervalRecords.Experiment.Extensions;
public static partial class IntervalExtensions
{
    /// <summary>
    /// Determines interval overlapping relation between two intervals.
    /// </summary>
    /// <typeparam name="T">The type of the interval endpoints.</typeparam>
    /// <param name="first">The first interval to compare.</param>
    /// <param name="second">The second interval to compare.</param>
    public static IntervalRelation GetRelation<T>(this Interval<T> first, Interval<T> second)
        where T : struct, IComparable<T>, ISpanParsable<T>
        => (first.LeftEndpoint.CompareTo(second.LeftEndpoint), first.RightEndpoint.CompareTo(second.RightEndpoint)) switch
        {
            (0, 0) => IntervalRelation.Equal,
            (0, -1) => IntervalRelation.Starts,
            (1, -1) => IntervalRelation.ContainedBy,
            (1, 0) => IntervalRelation.Finishes,
            (-1, 0) => IntervalRelation.FinishedBy,
            (-1, 1) => IntervalRelation.Contains,
            (0, 1) => IntervalRelation.StartedBy,
            (-1, -1) => (IntervalRelation)first.RightEndpoint.CompareTo(second.LeftEndpoint) + (int)IntervalRelation.Meets,
            (1, 1) => (IntervalRelation)first.LeftEndpoint.CompareTo(second.RightEndpoint) + (int)IntervalRelation.MetBy,
            (_, _) => throw new NotSupportedException()
        };
}
