namespace takaen
{
    internal static class CFGKapampanganToTagalog
    {
        //Constants
        private const Languages TO = Languages.Tagalog, FROM = Languages.Kapampangan;

        //Variables
        private static List<string>? words;
        private static string? text;
        private static int index;

        internal static string Translate(List<string> words)
        {
            CFGKapampanganToTagalog.words = words;
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
