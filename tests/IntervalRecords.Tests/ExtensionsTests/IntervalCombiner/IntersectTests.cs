﻿using FluentAssertions.Execution;
using IntervalRecords.Extensions;
using IntervalRecords.Tests.TestData;
using System.Linq;

namespace IntervalRecords.Tests.ExtensionsTests.IntervalCombiner
{
    public class IntersectTests
    {
        [Theory]
        [ClassData(typeof(Int32OverlappingClassData))]
        public void Intersect_ShouldBeExpectedOrNull(IntervalRelationTestData<int> testData)
        {
            // Act
            var actual = testData.Right.Intersect(testData.Left);

            // Assert
            var array = new Interval<int>[] { testData.Left, testData.Right };
            var maxByStart = array.MaxBy(i => i.Start)!;
            var minByEnd = array.MinBy(i => i.End)!;


            var expectedStartInclusive = testData.Left.Start == testData.Right.Start
                ? testData.Left.StartInclusive && testData.Right.StartInclusive
                : maxByStart.StartInclusive;

            var expectedEndInclusive = testData.Left.End == testData.Right.End
                ? testData.Left.EndInclusive && testData.Right.EndInclusive
                : minByEnd.EndInclusive;

            using (new AssertionScope())
            {
                actual!.Start.Should().Be(maxByStart.Start);
                actual!.End.Should().Be(minByEnd.End);
                actual!.StartInclusive.Should().Be(expectedStartInclusive);
                actual!.EndInclusive.Should().Be(expectedEndInclusive);
            }
        }

        //[Theory]
        //[MemberData(nameof(IntervalPairsWithOverlappingState), true)]
        //public void Intersect_ShouldBeExpectedOrEmpty(Interval<int> a, Interval<int> b, IntervalOverlapping overlappingState)
        //{
        //    // Act
        //    var actual = a.IntersectOrEmpty(b);

        //    // Assert
        //    var array = new Interval<int>[] { a, b };
        //    var maxByStart = array.MaxBy(i => i.Start)!;
        //    var minByEnd = array.MinBy(i => i.End)!;


        //    var expectedStartInclusive = a.Start == b.Start
        //        ? a.StartInclusive && b.StartInclusive
        //        : maxByStart.StartInclusive;

        //    var expectedEndInclusive = a.End == b.End
        //        ? a.EndInclusive && b.EndInclusive
        //        : minByEnd.EndInclusive;

        //    using (new AssertionScope())
        //    {
        //        if (overlappingState != IntervalOverlapping.Before && overlappingState != IntervalOverlapping.After)
        //        {
        //            actual.Start.Should().Be(maxByStart.Start);
        //            actual.End.Should().Be(minByEnd.End);
        //            actual.StartInclusive.Should().Be(!actual.Start.IsNegativeInfinity && expectedStartInclusive);
        //            actual.EndInclusive.Should().Be(!actual.End.IsPositiveInfinity && expectedEndInclusive);
        //        }
        //        else
        //        {
        //            actual.Should().Be(Interval<int>.Empty(a.IntervalType));
        //        }
        //    }
        //}

        //[Theory]
        //[InlineData(IntervalType.Closed, 6)]
        //[InlineData(IntervalType.ClosedOpen, 5)]
        //[InlineData(IntervalType.OpenClosed, 5)]
        //[InlineData(IntervalType.Open, 5)]
        //public void IntersectAll_ShouldBeExpected(IntervalType intervalType, int expectedCount)
        //{
        //    // Arrange
        //    var list = OverlapList(startingPoint, length, offset, intervalType).ToList();

        //    // Act
        //    var actual = list.IntersectAll().ToList();

        //    // Assert
        //    actual.Should().HaveCount(expectedCount);
        //}
    }
}
