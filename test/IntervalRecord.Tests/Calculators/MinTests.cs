﻿using System.Linq;

namespace IntervalRecord.Tests.Calculators
{
    public class MinTests
    {
        [Theory]
        [InlineData(1, 2, 2, 3)]
        [InlineData(2, 3, 1, 2)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, 2, 1, 3)]
        [InlineData(1, 3, 2, 3)]
        public void MinBy_ShouldBeEnumerableMinBy(int startA, int endA, int startB, int endB)
        {
            // Arrange
            var a = new Interval<int>(startA, endA, true, true);
            var b = new Interval<int>(startB, endB, true, true);

            // Act
            var actualMinByStart = Interval.MinBy(a, b, x => x.Start);
            var actualMinByEnd = Interval.MinBy(a, b, x => x.End);

            // Assert
            actualMinByStart.Should().Be(new[] { a, b }.MinBy(x => x.Start));
            actualMinByEnd.Should().Be(new[] { a, b }.MinBy(x => x.End));
        }

        [Theory]
        [InlineData(1, 2, 2, 3)]
        [InlineData(2, 3, 1, 2)]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, 2, 1, 3)]
        [InlineData(1, 3, 2, 3)]
        public void Min_ShouldBeEnumerableMin(int startA, int endA, int startB, int endB)
        {
            // Arrange
            var a = new Interval<int>(startA, endA, true, true);
            var b = new Interval<int>(startB, endB, true, true);

            // Act
            var actualMinByStart = Interval.Min(a, b);
            var actualMinByEnd = Interval.Min(a, b);

            // Assert
            actualMinByStart.Should().Be(new[] { a, b }.Min());
            actualMinByEnd.Should().Be(new[] { a, b }.Min());
        }
    }
}