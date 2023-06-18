namespace takaen
{
    internal static class CFGTagalogToKapampangan
    {
        //Constants
        private const Languages TO = Languages.Kapampangan, FROM = Languages.Tagalog;

        //Variables
        private static List<string>? words;
        private static string? text;
        private static int index;

        internal static string Translate(List<string> words)
        {
            CFGTagalogToKapampangan.words = words;
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
