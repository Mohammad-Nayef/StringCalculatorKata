namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.StartsWith("//"))
                return SumOfIntegersWithCustomDelimiter(numbers);

            var values = numbers.Split(',', '\n');

            return SumOfIntegers(values);
        }

        private static int SumOfIntegersWithCustomDelimiter(string numbers)
        {
            var numbersWithoutSlashes = numbers.Substring(2);
            var delimiter = numbersWithoutSlashes.First();
            var values = numbersWithoutSlashes.Split(',', '\n', delimiter);

            return SumOfIntegers(values);
        }

        private static int SumOfIntegers(string[] values)
        {
            var sum = 0;

            foreach (var value in values)
            {
                if (int.TryParse(value, out var number))
                {
                    sum += number;
                }
            }

            return sum;
        }
    }
}