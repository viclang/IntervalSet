﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IntervalRecords.Types;

namespace IntervalRecords.Tests.TestData;

public class Int32OverlapClassData : IEnumerable<object[]>
{
    private const int _offset = 1;
    private readonly static Interval<int> _reference = new ClosedInterval<int>(5, 9);

    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new List<object[]>();
        foreach (var intervalType in (IntervalType[])Enum.GetValues(typeof(IntervalType)))
        {
            var builder = new Int32OverlapTestDataBuilder(_reference.Canonicalize(intervalType, 0), _offset);
            UnboundedSetDirector<int>.WithUnBoundedSet(builder);
            BoundedSetDirector<int>.WithBoundedSet(builder);
            testData.AddRange((List<object[]>)builder);
        }
        return testData.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
