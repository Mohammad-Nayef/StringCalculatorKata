namespace StringCalculatorKata
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(List<int> negatives) : base(GetErrorMessage(negatives)) { }

        private static string GetErrorMessage(List<int> negatives)
        {
            var errorMessage = "negatives not allowed: ";
            AppendNegativesToErrorMessage(ref errorMessage, negatives);

            return errorMessage;
        }

        private static void AppendNegativesToErrorMessage(ref string errorMessage, List<int> negatives)
        {
            foreach (var negative in negatives)
            {
                errorMessage += $"{negative}, ";
            }

            errorMessage.TrimEnd(',', ' ');
        }
    }
}