using FluentAssertions;
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
            // Arrange
            int sum;

            // Act
            sum = StringCalculator.Add(numbers);

            // Assert
            sum.Should().Be(actualSum);
        }

        [Fact]
        public void AddingUnknownAmountOfNumbers()
        {
            // Arrange
            var fixture = new Fixture();
            var randomNumberOfOnes = fixture.Create<int>();
            var onesString = string.Empty;
            int sum;

            // Act 
            for (var i = 0; i < randomNumberOfOnes; i++)
            {
                onesString = string.Concat(onesString, "1,");
            }

            sum = StringCalculator.Add(onesString);

            // Assert
            sum.Should().Be(randomNumberOfOnes);
        }
    }
}