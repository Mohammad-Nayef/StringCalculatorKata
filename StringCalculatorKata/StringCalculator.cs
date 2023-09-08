namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var values = numbers.Split(',');
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