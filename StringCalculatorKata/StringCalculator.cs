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
                sum += number;
            }

            return sum;
        }

        private static int[] GetIntegers(string[] numbers)
        {
            int[] intNumbers = new int[numbers.Length];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int.TryParse(numbers[i], out intNumbers[i]);
            }

            return intNumbers;
        }
    }
}