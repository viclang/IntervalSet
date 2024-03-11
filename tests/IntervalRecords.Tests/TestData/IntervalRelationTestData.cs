﻿using IntervalRecords.Extensions;

namespace IntervalRecords.Tests.TestData;
public record IntervalRelationTestData<T>(Interval<T> Left, Interval<T> Right, IntervalRelation Relation)
    where T : struct, IEquatable<T>, IComparable<T>, ISpanParsable<T>;
