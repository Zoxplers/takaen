using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace takaen
{
    internal class Controller
    {
        //Constants
        const float TITLEFONTSIZE = 24;

        //Variables
        internal FileHandler fileHandler;
        internal Translator translator;
        internal Panel? mainPanel;
        internal Panel startPanel, translatePanel;
        internal Label dataLabel, appLabel;
        internal Button dataButton, appButton, startButton;
        internal bool dataExists;

        //Constructor
        internal Controller()
        {
            fileHandler = new FileHandler(this);
            translator = new Translator();
            startPanel = new Panel();
            translatePanel = new Panel();
            dataLabel = new Label();
            appLabel = new Label();
            dataButton = new Button();
            appButton = new Button();
            startButton = new Button();
            dataExists = false;
        }

        //Functions
        private void InitControls()
        {
            if (mainPanel != null)
            {
                dataLabel.Text = "Data Version: Unknown";
                dataLabel.TextAlign = ContentAlignment.MiddleCenter;

                appLabel.Text = "App Version: " + fileHandler.AppVersion;
                appLabel.TextAlign = ContentAlignment.MiddleCenter;

                dataButton.Text = "Download Data";
                appButton.Text = "Check for Updates";
                startButton.Text = "Start";

                dataButton.Click += DataButton_Click;
                appButton.Click += AppButton_Click;
            }
        }

        internal void ResizeControls()
        {
            if (mainPanel != null)
            {
                startPanel.Location = new Point((int)(mainPanel.Size.Width * 0.125), 0);
                startPanel.Size = new Size((int)(mainPanel.Size.Width * 0.75), mainPanel.Size.Height);

                dataLabel.Location = new Point(0, (int)(mainPanel.Size.Height * 0.1));
                dataLabel.Size = new Size(startPanel.Width, (int)(startPanel.Height * 0.1));

                appLabel.Location = new Point(0, (int)(mainPanel.Size.Height * 0.3));
                appLabel.Size = new Size(startPanel.Width, (int)(startPanel.Height * 0.1));

                dataButton.Location = new Point((int)(startPanel.Width * 0.375), (int)(mainPanel.Size.Height * 0.2));
                dataButton.Size = new Size((int)(startPanel.Width * 0.25), (int)(startPanel.Height * 0.1));

                appButton.Location = new Point((int)(startPanel.Width * 0.375), (int)(mainPanel.Size.Height * 0.4));
                appButton.Size = new Size((int)(startPanel.Width * 0.25), (int)(startPanel.Height * 0.1));

                startButton.Location = new Point((int)(startPanel.Width * 0.3), (int)(mainPanel.Size.Height * 0.6));
                startButton.Size = new Size((int)(startPanel.Width * 0.4), (int)(startPanel.Height * 0.2));
            }
        }

        internal void Init(Panel mainPanel)
        {
            this.mainPanel = mainPanel;

            startPanel.Controls.Add(dataLabel);
            startPanel.Controls.Add(appLabel);
            startPanel.Controls.Add(dataButton);
            startPanel.Controls.Add(appButton);
            startPanel.Controls.Add(startButton);

            mainPanel.Controls.Add(startPanel);

            InitControls();

            fileHandler.ClearUpdates();
            fileHandler.LoadData();
        }

        internal void UpdateDataVersion(int version)
        {
            dataExists = true;
            dataLabel.Text = "Data Version: " + version;
            dataButton.Text = "Update Data";
            dataButton.Enabled = true;
        }

        private void DataButton_Click(object? sender, EventArgs e)
        {
            dataButton.Text = "Downloading Data";
            dataButton.Enabled = false;
            fileHandler.UpdateData();
        }
        private void AppButton_Click(object? sender, EventArgs e)
        {
            appButton.Text = "Attempting to Update";
            appButton.Enabled = false;
            fileHandler.CheckAppUpdates(appButton);
        }
    }
}
