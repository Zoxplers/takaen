namespace takaen
{
    internal class Controller
    {
        //Constants
        private const float TITLEFONTSIZE = 24;

        //Variables
        internal FileHandler fileHandler;
        internal Translator? currentTranslator;
        internal Panel? mainPanel;
        internal Panel startPanel, translatePanel;
        internal Label dataLabel, appLabel;
        internal Button dataButton, appButton, startButton, menuButton;
        internal MenuStrip menuStrip;
        internal ToolStripMenuItem restartButton;
        internal bool dataExists;

        //Constructor
        internal Controller()
        {
            fileHandler = new FileHandler(this);
            startPanel = new Panel();
            translatePanel = new Panel();
            dataLabel = new Label();
            appLabel = new Label();
            dataButton = new Button();
            appButton = new Button();
            startButton = new Button();
            menuButton = new Button();
            menuStrip = new MenuStrip();
            restartButton = new ToolStripMenuItem();
            dataExists = false;
        }

        //Functions
        private void InitControls()
        {
            if (mainPanel != null)
            {
                translatePanel.Visible = false;

                dataLabel.Text = "Data Version: Unknown";
                dataLabel.TextAlign = ContentAlignment.MiddleCenter;

                appLabel.Text = "App Version: " + fileHandler.AppVersion;
                appLabel.TextAlign = ContentAlignment.MiddleCenter;

                dataButton.Text = "Download Data";
                appButton.Text = "Check for Updates";
                startButton.Text = "Start";

                menuButton.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                menuButton.AutoSize = false;
                menuButton.FlatAppearance.BorderSize = 0;
                menuButton.FlatStyle = FlatStyle.Flat;
                menuButton.Font = new Font(FontFamily.GenericSansSerif, TITLEFONTSIZE / 2f, FontStyle.Bold);
                menuButton.Size = new Size((int)(((Form1)menuButton.FindForm()!).TopBarSize*1.5), (int)(((Form1)menuButton.FindForm()!).TopBarSize * 0.75));
                menuButton.Location = new Point(0, mainPanel.Size.Height - menuButton.Size.Height);
                menuButton.Text = "Menu";

                menuStrip.AutoSize = false;
                menuStrip.Dock = DockStyle.Bottom;
                menuStrip.Items.AddRange(new ToolStripItem[] {restartButton});
                menuStrip.Visible = false;

                restartButton.Text = "Restart";

                dataButton.Click += DataButton_Click;
                appButton.Click += AppButton_Click;
                startButton.Click += StartButton_Click;
                menuButton.Click += MenuButton_Click;
                restartButton.Click += RestartButton_Click;
            }
        }

        internal void ResizeControls()
        {
            if (mainPanel != null)
            {
                startPanel.Location = new Point((int)(mainPanel.Size.Width * 0.125), 0);
                startPanel.Size = new Size((int)(mainPanel.Size.Width * 0.75), mainPanel.Size.Height);

                translatePanel.Location = new Point((int)(mainPanel.Size.Width * 0.125), 0);
                translatePanel.Size = new Size((int)(mainPanel.Size.Width * 0.75), mainPanel.Size.Height);

                dataLabel.Location = new Point(0, (int)(mainPanel.Size.Height * 0.1));
                dataLabel.Size = new Size(startPanel.Width, (int)(startPanel.Height * 0.1));

                appLabel.Location = new Point(0, (int)(mainPanel.Size.Height * 0.3));
                appLabel.Size = new Size(startPanel.Width, (int)(startPanel.Height * 0.1));

                if (mainPanel.Size.Width < 1080)
                {
                    dataButton.Location = new Point((int)(startPanel.Width * 0.3), (int)(mainPanel.Size.Height * 0.2));
                    dataButton.Size = new Size((int)(startPanel.Width * 0.4), (int)(startPanel.Height * 0.1));

                    appButton.Location = new Point((int)(startPanel.Width * 0.3), (int)(mainPanel.Size.Height * 0.4));
                    appButton.Size = new Size((int)(startPanel.Width * 0.4), (int)(startPanel.Height * 0.1));

                    startButton.Location = new Point((int)(startPanel.Width * 0.25), (int)(mainPanel.Size.Height * 0.6));
                    startButton.Size = new Size((int)(startPanel.Width * 0.5), (int)(startPanel.Height * 0.2));
                }
                else
                { 
                    dataButton.Location = new Point((int)(startPanel.Width * 0.375), (int)(mainPanel.Size.Height * 0.2));
                    dataButton.Size = new Size((int)(startPanel.Width * 0.25), (int)(startPanel.Height * 0.1));

                    appButton.Location = new Point((int)(startPanel.Width * 0.375), (int)(mainPanel.Size.Height * 0.4));
                    appButton.Size = new Size((int)(startPanel.Width * 0.25), (int)(startPanel.Height * 0.1));

                    startButton.Location = new Point((int)(startPanel.Width * 0.3), (int)(mainPanel.Size.Height * 0.6));
                    startButton.Size = new Size((int)(startPanel.Width * 0.4), (int)(startPanel.Height * 0.2));
                }

                menuStrip.Height = mainPanel.Location.X;
            }

            currentTranslator?.Resize();
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
            mainPanel.Controls.Add(translatePanel);
            mainPanel.Controls.Add(menuButton);
            
            mainPanel.FindForm()!.Controls.Add(menuStrip);

            InitControls();

            fileHandler.ClearUpdates();
            fileHandler.GetDataVersion();
        }

        internal void UpdateDataVersion(int version)
        {
            dataLabel.Text = "Data Version: " + version;
            if(dataExists)
            {
                dataButton.Text = "Up to date";
                
            }
            else
            {
                dataExists = true;
                dataButton.Enabled = true;
                dataButton.Text = "Update Data";
            }
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

        private void StartButton_Click(object? sender, EventArgs e)
        {
            startPanel.Visible = false;
            translatePanel.Visible = true;

            currentTranslator?.CleanUp();
            currentTranslator = new Translator(translatePanel, fileHandler);
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            menuStrip.Visible = !menuStrip.Visible;
        }

        private void RestartButton_Click(object? sender, EventArgs e)
        {
            startPanel.Visible = true;
            translatePanel.Visible = false;
        }
    }
}
