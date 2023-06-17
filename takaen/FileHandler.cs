using static System.Environment;
using System.IO.Compression;
using System.Diagnostics;
using System.Reflection;

namespace takaen
{
    internal class FileHandler
    {
        //Constants
        private const string DATAURI = "https://github.com/Zoxplers/takaen/raw/main/data.zip", APPURI = "https://github.com/Zoxplers/takaen/releases/download/windows/takaen.zip", VERSIONURI = "https://github.com/Zoxplers/takaen/releases/download/windows/version", UPDATESDIR = "Updates";

        //Variables
        private Controller controller;
        private HttpClient httpClient;
        private Scanner? scanner;
        private string dataPath, appVersion;


        //Constructor
        internal FileHandler(Controller controller)
        {
            this.controller = controller;
            httpClient = new HttpClient();
            dataPath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), Form1.TITLE, "data");
            appVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString().Remove(3);
        }

        //Functions
        public string? AppVersion { get => appVersion; }

        private void LoadApp()
        {
            Process.Start("Updates\\run.bat");
            Application.Exit();
        }

        private string? GetNextToken()
        {
            const char sep = ',';
            if(scanner != null)
            {
                string? token = scanner.Next(sep);
                if (token!.EndsWith(sep))
                {
                    token = token.Remove(token.Length-1);
                }
                
                return token;
            }
            return null;
        }

        internal void ClearUpdates()
        {
            if (Directory.Exists(UPDATESDIR))
            {
                Directory.Delete(UPDATESDIR, true);
            }
        }

        internal void GetDataVersion()
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
            try
            {
                Stream data = await httpClient.GetStreamAsync(DATAURI);
                Directory.CreateDirectory(dataPath);
                ZipFileExtensions.ExtractToDirectory(new ZipArchive(data), dataPath, true);
                GetDataVersion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal async void CheckAppUpdates(Button appButton)
        {
            try
            {
                if (!appVersion.Equals(await httpClient.GetStringAsync(VERSIONURI)))
                {
                    UpdateApp();
                    return;
                }
                appButton.Text = "Up to date.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        internal void GetKeyData(Dictionary dictionary)
        {
            foreach(int key in Enum.GetValues(typeof(Keys)))
            {
                scanner = new Scanner(Path.Combine(dataPath, "dictionary\\" + (Keys)key + ".csv"));

                foreach(string languageName in Enum.GetNames(typeof(Languages)))
                {
                    if (!(scanner.HasNext() && GetNextToken()!.Equals(languageName)))
                    {
                        
                        MessageBox.Show("Unable to read data.");
                        throw new Exception();
                    }
                }

                while (scanner.HasNext())
                {
                    foreach (int language in Enum.GetValues(typeof(Languages)))
                    {
                        dictionary[key][language].Add(GetNextToken()!.ToLower());
                    }
                }

                scanner.Close();
            }
        }
    }
}
