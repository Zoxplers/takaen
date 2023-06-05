using static System.Environment;
using System.IO.Compression;

namespace takaen
{
    internal class FileHandler
    {
        //Constants
        private const string DATAURI = "", GRAMMARSURI = "", DICTIONARYFOLDER = "dictionary", GRAMMARSFOLDER = "grammars";

        //Variables
        Controller controller;
        HttpClient httpClient;
        String dataPath;

        //Constructor
        internal FileHandler(Controller controller)
        {
            this.controller = controller;
            httpClient = new HttpClient();
            dataPath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), Form1.TITLE, "data");
        }

        //Functions
        internal void LoadData()
        {
            if (Directory.Exists(dataPath))
            {
                controller.UpdateDataVersion(Int32.Parse(File.ReadAllText(Path.Combine(dataPath, "version"))));
            }
            else
            {
                MessageBox.Show("Data folder does not exist.");
            }
        }

        internal async void UpdateData()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Stream data = await httpClient.GetStreamAsync(DATAURI);

            Directory.CreateDirectory(dataPath);
            ZipFileExtensions.ExtractToDirectory(new ZipArchive(data), dataPath);

            LoadData();
        }
    }
}
