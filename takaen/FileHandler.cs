using static System.Environment;
using System.IO.Compression;
using System.Diagnostics;

namespace takaen
{
    internal class FileHandler
    {
        //Constants
        private const string DATAURI = "https://github.com/Zoxplers/takaen/raw/main/data.zip", APPURI = "https://github.com/Zoxplers/takaen/releases/download/windows/takaen.zip", UPDATESDIR = "Updates";

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
        internal void ClearUpdates()
        {
            if(Directory.Exists(UPDATESDIR))
            {
                Directory.Delete(UPDATESDIR, true);
            }
        }

        private void LoadApp()
        {
            Process.Start("Updates\\run.bat");
            Application.Exit();
        }

        internal void LoadData()
        {
            if(Directory.Exists(dataPath))
            {
                controller.UpdateDataVersion(Int32.Parse(File.ReadAllText(Path.Combine(dataPath, "version"))));
            }
            else
            {
                MessageBox.Show("Data folder does not exist.");
            }
        }

        internal async void UpdateApp()
        {
            Stream data = await httpClient.GetStreamAsync(APPURI);
            Directory.CreateDirectory(UPDATESDIR);
            ZipFileExtensions.ExtractToDirectory(new ZipArchive(data), UPDATESDIR, true);
            LoadApp();
        }

        internal async void UpdateData()
        {
            Stream data = await httpClient.GetStreamAsync(DATAURI);
            Directory.CreateDirectory(dataPath);
            ZipFileExtensions.ExtractToDirectory(new ZipArchive(data), dataPath, true);
            LoadData();
        }
    }
}
