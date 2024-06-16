﻿namespace IntervalSets.Types;
public static class IntervalTypeExtensions
{
    private const int ExtractBound = 3;

    public static bool IsBounded(this IntervalType intervalType)
        => intervalType.StartBound().IsBounded() && intervalType.EndBound().IsBounded();


    public static Bound StartBound(this IntervalType intervalType)
        => (Bound)(DecodeStartBound(intervalType) & ExtractBound);

    public static Bound EndBound(this IntervalType intervalType)
        => (Bound)((byte)intervalType & ExtractBound);

    public static (Bound startBound, Bound endBound) Bounds(this IntervalType intervalType)
        => (intervalType.StartBound(), intervalType.EndBound());

    private static int DecodeStartBound(IntervalType intervalType) => (byte)intervalType >> 2;
}
