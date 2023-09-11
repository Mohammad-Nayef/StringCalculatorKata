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

            var intNumbers = GetIntegers(values);

            if (HasNegatives(intNumbers))
            {
                throw new NegativesNotAllowedException(GetNegatives(intNumbers));
            }

            return SumOfIntegers(intNumbers);
        }

        private static List<int> GetIntegers(List<string> values)
        {
            var intNumbers = new List<int>();
            int tempInteger;

            for (int i = 0; i < values.Count; i++)
            {
                int.TryParse(values[i], out tempInteger);
                intNumbers.Add(tempInteger);
            }

            return intNumbers;
        }

        private static bool HasNegatives(List<int> intNumbers)
        {
            foreach (var number in intNumbers)
            {
                if (number < 0)
                    return true;
            }

            return false;
        }

        private static List<int> GetNegatives(List<int> intNumbers)
        {
            var listOfNegatives = new List<int>();

            foreach (var number in intNumbers)
            {
                if (number < 0)
                    listOfNegatives.Add(number);
            }

            return listOfNegatives;
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
            var sum = 0;

            foreach (var number in numbers)
            {
                if (number <= 1000)
                    sum += number;
            }

            return sum;
        }
    }
}