namespace takaen
{
    internal static class CFGEnglishToKapampangan
    {
        //Constants
        private const Languages TO = Languages.Kapampangan, FROM = Languages.English;

        //Variables
        private static List<string>? words;
        private static string? text;
        private static int index;

        internal static string Translate(List<string> words)
        {
            CFGEnglishToKapampangan.words = words;
            text = string.Empty;
            index = 0;

            while (index < words.Count)
            {
                S();
            }

            return text;
        }

        /// <summary>
        /// Returns if are or is
        /// </summary>
        private static bool AreIs(int index)
        {
            return words![index] == "are" || words[index] == "is";
        }


        /// <summary>
        /// S => *pronoun*
        /// 
        /// </summary>
        private static void S()
        {
            //IsPronoun()
            foreach (string pronoun in TranslatorLogic.Dictionary![Keys.Pronouns, Languages.English])
            {
                if (pronoun == words![index] && Pronoun())
                {
                    return;
                }
            }

            //None of the above
            text += TranslatorLogic.TranslateWord(TO, FROM, words![index]);
            index++;
        }

        /// <summary>
        /// 
        /// </summary>
        private static bool Pronoun()
        {
            //*pronoun* *are/is* *adjective* => *adjective* *pronoun*
            if (index + 4 < words!.Count && AreIs(2))
            {
                foreach (string adjective in TranslatorLogic.Dictionary![Keys.Adjectives, Languages.English])
                {
                    if (adjective == words[index + 4])
                    {
                        text += TranslatorLogic.TranslateWord(TO, FROM, words[index + 4]) + words[index + 1] + TranslatorLogic.TranslateWord(TO, FROM, words[index]);
                        index += 5;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}