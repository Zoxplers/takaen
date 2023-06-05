using System.Reflection;

namespace takaen
{
    internal class Controller
    {
        //Constants
        const float TITLEFONTSIZE = 24;

        //Variables
        internal FileHandler fileHandler;
        internal Translator translator;
        internal Panel mainPanel, startingPanel;
        internal Label title, dataLabel, appLabel;
        internal Button startButton, downloadButton;

        //Constructor
        internal Controller()
        {
            fileHandler = new FileHandler();
            translator = new Translator();
            mainPanel = new Panel();
            startingPanel = new Panel();
            title = new Label();
            dataLabel = new Label();
            appLabel = new Label();
            startButton = new Button();
            downloadButton = new Button();

        }

        //Functions
        private void fixLayout(Form1 form)
        {
            startingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startingPanel.BackColor = Color.Azure;
            startingPanel.Location = new Point(0, 60);
            startingPanel.Size = new Size(800, 740);

            title.Anchor = AnchorStyles.None;
            title.Dock = DockStyle.Top;
            title.Font = new Font(FontFamily.GenericSansSerif, TITLEFONTSIZE, FontStyle.Regular);
            title.Location = new Point(0, 475);
            title.Size = new Size(0, 60);
            title.Text = "     " + Form1.TITLE;
            title.TextAlign = ContentAlignment.MiddleLeft;

            //dataLabel.Dock = DockStyle.Fill;
            dataLabel.Anchor = AnchorStyles.Top;
            dataLabel.Font = new Font(FontFamily.GenericSansSerif, TITLEFONTSIZE / 2, FontStyle.Regular);
            dataLabel.Location = new Point(100, 0);
            dataLabel.Size = new Size(600, 370);
            dataLabel.Text = "Data Version: Unknown";
            dataLabel.TextAlign = ContentAlignment.TopCenter;
            dataLabel.BackColor = Color.Black;

            //appLabel.Dock = DockStyle.Fill;
            appLabel.Anchor = AnchorStyles.Bottom;
            appLabel.Font = new Font(FontFamily.GenericSansSerif, TITLEFONTSIZE / 2, FontStyle.Regular);
            appLabel.Location = new Point(100, 370);
            appLabel.Size = new Size(600, 370);
            appLabel.Text = "App Version: " + Assembly.GetExecutingAssembly().GetName().Version?.ToString().Remove(3);
            appLabel.TextAlign = ContentAlignment.TopCenter;
            appLabel.BackColor = Color.Orange;

 
        }

        internal void Init(Form1 form)
        {

        }

        /*
        internal void Init(Form1 form)
        {
            
            startingPanel.Controls.Add(dataLabel);
            startingPanel.Controls.Add(appLabel);
            startingPanel.Controls.Add(startButton);
            startingPanel.Controls.Add(downloadButton);
            mainPanel.Controls.Add(startingPanel);
            form.Controls.Add(mainPanel);

            fixLayout(form);
            
            if(fileHandler.Init())
            {

            }
            
        }
        */
    }
}
