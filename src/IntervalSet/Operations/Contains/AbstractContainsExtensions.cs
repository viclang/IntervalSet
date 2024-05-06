﻿using Intervals.Types;

namespace Intervals.Operations;
public static class AbstractContainsExtensions
{
    public static bool Contains<T>(this IAbstractInterval<T> interval, T other)
        where T : notnull, IComparable<T>, ISpanParsable<T>
        => interval switch
        {
            IBoundedInterval<T> boundedInterval => boundedInterval.Contains(other),
            IComplementInterval<T> complementInterval => complementInterval.Contains(other),
            ILeftBoundedInterval<T> leftBoundedInterval => leftBoundedInterval.Contains(other),
            IRightBoundedInterval<T> rightBoundedInterval => rightBoundedInterval.Contains(other),
            _ => throw new NotImplementedException(),
        };
}