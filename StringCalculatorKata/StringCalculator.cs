namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            string[] values;

            if (numbers.StartsWith("//"))
            {
                values = GetValuesWithCustomDelimiter(numbers);
            }
            else
            {
                values = numbers.Split(',', '\n');
            }

            var intNumbers = GetIntegers(values);

            if (HasNegatives(intNumbers))
            {
                throw new NegativesNotAllowed(GetNegatives(intNumbers));
            }

            return SumOfIntegers(intNumbers);
        }

        private static int[] GetIntegers(string[] values)
        {
            int[] intNumbers = new int[values.Length];

            for (int i = 0; i < intNumbers.Length; i++)
            {
                int.TryParse(values[i], out intNumbers[i]);
            }

            return intNumbers;
        }

        private static bool HasNegatives(int[] intNumbers)
        {
            foreach (var number in intNumbers)
            {
                if (number < 0)
                    return true;
            }

            return false;
        }

        private static int[] GetNegatives(int[] intNumbers)
        {
            var listOfNegatives = new List<int>();

            foreach (var number in intNumbers)
            {
                if (number < 0)
                    listOfNegatives.Add(number);
            }

            return listOfNegatives.ToArray();
        }

        private static string[] GetValuesWithCustomDelimiter(string numbers)
        {
            var numbersWithoutSlashes = numbers.Substring(2);
            var delimiter = numbersWithoutSlashes.First();
            var values = numbersWithoutSlashes.Split(',', '\n', delimiter);

            return values;
        }

        private static int SumOfIntegers(int[] numbers)
        {
            var sum = 0;

            foreach (var number in numbers)
                {
                if (number <= 1000)
                    sum += number;
                }
            }

            return sum;
        }
    }
}