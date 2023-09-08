using FluentAssertions;

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
            // Arrange
            int sum;

            // Act
            sum = StringCalculator.Add(numbers);

            // Assert
            sum.Should().Be(actualSum);
        }
    }
}