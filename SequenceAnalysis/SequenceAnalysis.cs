namespace SequenceAnalysisLibrary
{
    public class SequenceAnalysis
    {
        public static string Analyze(string input)
        {
            if (input.Length == 0)
                return string.Empty;

            var uppercaseLetters = input.Where(x => char.IsUpper(x)).ToArray<char>();
            if (uppercaseLetters.Length == 0)
                return string.Empty;

            Array.Sort(uppercaseLetters);
            return new string(uppercaseLetters);

        }
    }
}
