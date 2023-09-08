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
            var sum = StringCalculator.Add(numbers);

            sum.Should().Be(actualSum);
        }
    }
}