namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var values = new List<string>();

            if (numbers.StartsWith("//"))
            {
                values = GetValuesWithCustomDelimiter(numbers);
            }
            else
            {
                values = numbers.Split(',', '\n')
                                .ToList();
            }

            var intNumbers = ParseIntoIntegers(values);

            if (HasNegatives(intNumbers))
            {
                throw new NegativesNotAllowedException(GetNegatives(intNumbers));
            }

            return SumOfIntegers(intNumbers);
        }

        private static List<int> ParseIntoIntegers(List<string> values)
        {
            return values.Select(value => GetIntegerValue(value))
                         .ToList();
        }

        private static int GetIntegerValue(string value)
        {
            if (int.TryParse(value, out var number))
                return number;

            return 0;
        }

        private static bool HasNegatives(List<int> intNumbers) => intNumbers.Any(number => number < 0);

        private static List<int> GetNegatives(List<int> intNumbers)
        {
            return intNumbers.Where(number => number < 0)
                             .ToList();
        }

        private static List<string> GetValuesWithCustomDelimiter(string numbers)
        {
            var numbersWithoutSlashes = numbers.Substring(2);
            var delimiter = numbersWithoutSlashes.First();
            var values = numbersWithoutSlashes.Split(',', '\n', delimiter)
                                              .ToList();

            return values;
        }

        private static int SumOfIntegers(List<int> numbers)
        {
            return numbers.Where(number => number <= 1000)
                          .Sum();
        }
    }
}