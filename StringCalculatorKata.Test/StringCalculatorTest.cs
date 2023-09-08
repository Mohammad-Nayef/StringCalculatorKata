﻿using FluentAssertions;
using AutoFixture;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,1", 2)]
        public void AddingUpToTwoNumbers(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
        }

        [Fact]
        public void AddingUnknownAmountOfNumbers()
        {
            // Arrange
            var fixture = new Fixture();
            var randomNumberOfOnes = fixture.Create<int>();
            var onesString = string.Empty;

            // Act 
            for (var i = 0; i < randomNumberOfOnes; i++)
            {
                onesString = string.Concat(onesString, "1,");
            }

            // Assert
            AssertHelper(numbers: onesString, actualSum: randomNumberOfOnes);
        }

        private void AssertHelper(string numbers, int actualSum)
        {
            // Act
            var sum = StringCalculator.Add(numbers);

            // Assert
            sum.Should().Be(actualSum);
        }
    }
}