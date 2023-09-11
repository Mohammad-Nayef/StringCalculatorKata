using FluentAssertions;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,1", 2)]
        public void Add_ShouldReturnTheSumOfNumbers_WhenAddingUpToTwoNumbers(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
        }

        [Theory]
        [InlineData("1,1,1,1,1,1", 6)]

        public void Add_ShouldReturnTheSumOfNumbers_WhenAddingMoreThanTwoNumbers(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
        }

        [Theory]
        [InlineData("1\n1\n1", 3)]
        [InlineData("1\n1,1", 3)]
        public void Add_ShouldReturnTheSumOfNumbers_WhenAddingNumbersSeparatedWithNewLines(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
        }

        [Theory]
        [InlineData("//;\n1;1,1", 3)]
        public void Add_ShouldReturnTheSumOfNumbers_WhenAddingNumbersSeparatedWithCustomDelimiters(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("1, -1, -2")]
        public void Add_ShouldThrowNegativesNotAllowedException_WhenAddingNegativeNumbers(string numbers)
        {
            // Act
            Action addingNegativeNumbers = () => StringCalculator.Add(numbers);

            // Assert
            Assert.Throws<NegativesNotAllowedException>(addingNegativeNumbers);
        }

        [Theory]
        [InlineData("1001", 0)]
        [InlineData("1001, 1", 1)]
        public void Add_ShouldIgnoreNumbers_WhenTheyAreBiggerThanOneThousand(string numbers, int actualSum)
        {
            AssertHelper(numbers, actualSum);
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