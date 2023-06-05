using static System.Environment;

namespace takaen
{
    internal class FileHandler
    {
        //Constants
        internal const string DICTIONARYURI = "", GRAMMARSURI = "", DICTIONARYFOLDER = "dictionary", GRAMMARSFOLDER = "grammars";

        //Variables
        HttpClient httpClient;

        //Constructor
        internal FileHandler()
        {
            httpClient = new HttpClient();
        }

        //Functions

        /// <summary>
        /// Checks if local data folder exists with dictionary and grammar.
        /// </summary>
        /// <returns>True if local all folders exist.</returns>
        internal bool Init()
        {
            string appdataPath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), Form1.TITLE);

            return Directory.Exists(appdataPath) && Directory.Exists(Path.Combine(appdataPath, DICTIONARYFOLDER)) && Directory.Exists(Path.Combine(appdataPath, GRAMMARSFOLDER));
        }

    }
}
