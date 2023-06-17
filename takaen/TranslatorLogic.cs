using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal static class TranslatorLogic
    {
        //Variables
        private static Dictionary? dictionary;

        internal static string Translate(Languages to, Languages from, string text)
        {
            string translatedText = "";
            List<string> words = Split(text);

            words.ForEach(word =>
            {
                Console.WriteLine(word);
                translatedText += TranslateWord(to, from, word);
            });

            
            return translatedText;
        }

        internal static void SetDictionary(Dictionary dictionary)
        {
            TranslatorLogic.dictionary = dictionary;
        }

        private static string TranslateWord(Languages to, Languages from, string text)
        {
            //Variables
            (int index, int key) = GetIndexAndKey(from, text);
            if (index == -1)
            {
                return text;
            }
            else
            {
                return GetWord(to, index, key) ?? text;
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
                return dictionary[(int)key][(int)language][index];
            }

            return null;
        }

        private static List<string> Split(string str)
        {
            //Variables
            List<string> list = new List<string>();
            string word = "";

            foreach(char c in str)
            {
                if (char.IsLetter(c))
                {
                    word += c;
                }
                else
                {
                    if (word != "")
                    {
                        list.Add(word);
                        word = "";
                    }
                    list.Add("" + c);       
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
