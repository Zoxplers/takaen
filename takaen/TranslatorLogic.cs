namespace takaen
{
    internal static class TranslatorLogic
    {
        //Variables
        private static Dictionary? dictionary;

        internal static Dictionary? Dictionary { get => dictionary; set => dictionary = value; }

        internal static string Translate(Languages to, Languages from, string text)
        {
            string translatedText = string.Empty;
            List<string> words = Split(text);

            switch(from)
            {
                case Languages.Tagalog:
                    switch(to)
                    {
                        case Languages.English:
                            translatedText = CFGTagalogToEnglish.Translate(words);
                            break;
                        case Languages.Kapampangan:
                            translatedText = CFGTagalogToKapampangan.Translate(words);
                            break;
                    }
                    break;
                case Languages.English:
                    switch (to)
                    {
                        case Languages.Tagalog:
                            translatedText = CFGEnglishToTagalog.Translate(words);
                            break;
                        case Languages.Kapampangan:
                            translatedText = CFGEnglishToKapampangan.Translate(words);
                            break;
                    }
                    break;
                case Languages.Kapampangan:
                    switch (to)
                    {
                        case Languages.English:
                            translatedText = CFGKapampanganToEnglish.Translate(words);
                            break;
                        case Languages.Tagalog:
                            translatedText = CFGKapampanganToTagalog.Translate(words);
                            break;
                    }
                    break;
            }
            
            return translatedText;
        }

        internal static string TranslateWord(Languages to, Languages from, string word)
        {
            //Variables
            (int index, int key) = GetIndexAndKey(from, word);
            if (index == -1)
            {
                return word;
            }
            else
            {
                return GetWord(to, index, key) ?? word;
            }
        }

        private static (int, int) GetIndexAndKey(Languages language, string text)
        {
            if(dictionary != null)
            {
                foreach (int key in Enum.GetValues(typeof(Keys)))
                {
                    int index = dictionary[key][(int)language].IndexOf(text);
                    if (index != -1)
                    {
                        return (index, key);
                    }
                }
            }

            return (-1, -1);
        }

        private static string? GetWord(Languages language, int index, int key)
        {
            if (dictionary != null)
            {
                return dictionary[key][(int)language][index];
            }

            return null;
        }

        private static List<string> Split(string str)
        {
            //Variables
            List<string> list = new List<string>();
            string word = string.Empty;

            foreach(char c in str)
            {
                if (char.IsLetter(c))
                {
                    word += c;
                }
                else
                {
                    if (word != string.Empty)
                    {
                        list.Add(word);
                        word = string.Empty;
                    }
                    list.Add(string.Empty + c);       
                }
            }

            if(char.IsLetter(str.Last()))
            {
                list.Add(word);
            }

            return list;
        }
    }
}
