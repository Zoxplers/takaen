namespace takaen
{
    internal static class CFGKapampanganToEnglish
    {
        //Constants
        private const Languages TO = Languages.English, FROM = Languages.Kapampangan;

        //Variables
        private static List<string>? words;
        private static string? text;
        private static int index;

        internal static string Translate(List<string> words)
        {
            CFGKapampanganToEnglish.words = words;
            text = string.Empty;
            index = 0;

            S();

            return text;
        }

        private static void S()
        {
            if (index == words!.Count)
            {
                return;
            }

            text += TranslatorLogic.TranslateWord(TO, FROM, words[index]);
            index++;

            S();
        }
    }
}
