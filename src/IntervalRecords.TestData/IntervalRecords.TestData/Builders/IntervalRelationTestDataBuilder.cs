﻿using IntervalRecords.Extensions;
using IntervalRecords.TestData.Builders;
using System.Numerics;

namespace IntervalRecords.TestData;
public sealed class IntervalRelationTestDataBuilder<T> : IIntervalTestDataBuilder
    where T : struct, IEquatable<T>, IComparable<T>, ISpanParsable<T>, INumber<T>
{
    private readonly Interval<T> _reference;
    private readonly T _offset;

    private readonly List<IntervalRelationTestData<T>> _testData;

    public IntervalRelationTestDataBuilder(Interval<T> reference, T offset)
    {
        _reference = reference;
        _offset = offset;
        _testData = new List<IntervalRelationTestData<T>>();
    }

    private void AddBounded(Interval<T> first, IntervalRelation overlap)
    {
        _testData.Add(new IntervalRelationTestData<T>(first, _reference, overlap));
    }

    private void AddLeftBounded(Interval<T> first, IntervalRelation overlap)
    {
        _testData.Add(new IntervalRelationTestData<T>(
            first,
            IntervalRelationFactory<T>.LeftBoundedEqual(_reference),
            overlap));
    }

    private void AddRightBounded(Interval<T> first, IntervalRelation overlap)
    {
        _testData.Add(new IntervalRelationTestData<T>(
            first,
            IntervalRelationFactory<T>.RightBoundedEqual(_reference),
            overlap));
    }

    private void AddUnBounded(Interval<T> first, IntervalRelation overlap)
    {
        _testData.Add(new IntervalRelationTestData<T>(
            first,
            IntervalRelationFactory<T>.UnBoundedEqual(_reference),
            overlap));
    }

    public IIntervalTestDataBuilder WithBefore()
    {
        AddBounded(
            IntervalRelationFactory<T>.Before(_reference, _offset),
            IntervalRelation.Before);
        return this;
    }

    public IIntervalTestDataBuilder WithMeets()
    {
        var overlap = _reference.GetIntervalType() == IntervalType.Closed
                ? IntervalRelation.Meets
                : IntervalRelation.Before;

        AddBounded(
            IntervalRelationFactory<T>.Meets(_reference),
            overlap);
        return this;
    }

    public IIntervalTestDataBuilder WithOverlaps()
    {
        AddBounded(
            IntervalRelationFactory<T>.Overlaps(_reference, _offset),
            IntervalRelation.Overlaps);
        return this;
    }

    public IIntervalTestDataBuilder WithStarts()
    {
        AddBounded(
            IntervalRelationFactory<T>.Starts(_reference, _offset),
            IntervalRelation.Starts);
        return this;
    }

    public IIntervalTestDataBuilder WithRightboundedStarts()
    {
        AddRightBounded(
            IntervalRelationFactory<T>.RightboundedStarts(_reference, _offset),
            IntervalRelation.Starts);
        return this;
    }

    public IIntervalTestDataBuilder WithContainedBy()
    {
        AddBounded(
            IntervalRelationFactory<T>.ContainedBy(_reference, _offset),
            IntervalRelation.ContainedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithFinishes()
    {
        AddBounded(
            IntervalRelationFactory<T>.Finishes(_reference, _offset),
            IntervalRelation.Finishes);
        return this;
    }

    public IIntervalTestDataBuilder WithLeftboundedFinishes()
    {
        AddLeftBounded(
            IntervalRelationFactory<T>.LeftboundedFinishes(_reference, _offset),
            IntervalRelation.Finishes);
        return this;
    }

    public IIntervalTestDataBuilder WithEqual()
    {
        AddBounded(_reference, IntervalRelation.Equal);
        return this;
    }
    public IIntervalTestDataBuilder WithLeftBoundedEqual()
    {
        AddLeftBounded(
            IntervalRelationFactory<T>.LeftBoundedEqual(_reference),
            IntervalRelation.Equal);
        return this;
    }

    public IIntervalTestDataBuilder WithRightBoundedEqual()
    {
        AddRightBounded(
            IntervalRelationFactory<T>.RightBoundedEqual(_reference),
            IntervalRelation.Equal);
        return this;
    }
    public IIntervalTestDataBuilder WithUnBoundedEqual()
    {
        AddUnBounded(
            IntervalRelationFactory<T>.UnBoundedEqual(_reference),
            IntervalRelation.Equal);
        return this;
    }

    public IIntervalTestDataBuilder WithFinishedBy()
    {
        AddBounded(
            IntervalRelationFactory<T>.FinishedBy(_reference, _offset),
            IntervalRelation.FinishedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithLeftBoundedFinishedBy()
    {
        AddLeftBounded(
            IntervalRelationFactory<T>.LeftBoundedFinishedBy(_reference, _offset),
            IntervalRelation.FinishedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithContains()
    {
        AddBounded(
            IntervalRelationFactory<T>.Contains(_reference, _offset),
            IntervalRelation.Contains);
        return this;
    }

    public IIntervalTestDataBuilder WithStartedBy()
    {
        AddBounded(
            IntervalRelationFactory<T>.StartedBy(_reference, _offset),
            IntervalRelation.StartedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithRightboundedStartedBy()
    {
        AddRightBounded(
            IntervalRelationFactory<T>.RightboundedStartedBy(_reference, _offset),
            IntervalRelation.StartedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithOverlappedBy()
    {
        AddBounded(
            IntervalRelationFactory<T>.OverlappedBy(_reference, _offset),
            IntervalRelation.OverlappedBy);
        return this;
    }

    public IIntervalTestDataBuilder WithMetBy()
    {
        var overlap = _reference.GetIntervalType() == IntervalType.Closed
            ? IntervalRelation.MetBy
            : IntervalRelation.After;

        AddBounded(
            IntervalRelationFactory<T>.MetBy(_reference),
            overlap);
        return this;
    }

    public IIntervalTestDataBuilder WithAfter()
    {
        AddBounded(
            IntervalRelationFactory<T>.After(_reference, _offset),
            IntervalRelation.After);
        return this;
    }

    public static implicit operator List<IntervalRelationTestData<T>>(IntervalRelationTestDataBuilder<T> builder)
        => builder._testData;

    public static implicit operator List<object[]>(IntervalRelationTestDataBuilder<T> builder)
        => builder._testData.Select(data => new object[] { data }).ToList();
}
