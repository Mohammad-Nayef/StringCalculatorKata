namespace StringCalculatorKata
{
    public class NegativesNotAllowed : Exception
    {
        public NegativesNotAllowed(int[] negatives) : base(GetErrorMessage(negatives)) { }

        private static string GetErrorMessage(int[] negatives)
        {
            var errorMessage = "negatives not allowed: ";
            AppendNegativesToErrorMessage(ref errorMessage, negatives);

            return errorMessage;
        }

        private static void AppendNegativesToErrorMessage(ref string errorMessage, int[] negatives)
        {
            foreach (var negative in negatives)
            {
                errorMessage += $"{negative}, ";
            }

            errorMessage.TrimEnd(',', ' ');
        }
    }
}