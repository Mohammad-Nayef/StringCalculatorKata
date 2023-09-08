namespace StringCalculatorKata
{
    public class NegativesNotAllowed : Exception
    {
        public NegativesNotAllowed(int[] negatives)
        {
            var errorMessage = "negatives not allowed: ";
            AppendNegativesToErrorMessage(ref errorMessage, negatives);

            throw new Exception(errorMessage);
        }

        private void AppendNegativesToErrorMessage(ref string errorMessage, int[] negatives)
        {
            foreach (var negative in negatives)
            {
                errorMessage += $"{negative}, ";
            }

            errorMessage.TrimEnd(',', ' ');
        }
    }
}