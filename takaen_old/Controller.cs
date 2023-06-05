using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class Controller
    {
        //Constants
        private const int MAX_LANGUAGES = 3;

        //Variables
        private Form form;
        private MenuStripHandler menuStrip;
        private ResetButtonHandler resetButton;
        private PanelHandler initPanel, mainPanel, examplesPanel;
        private ComboBoxHandler comboBox;
        private InitButtonHandler initButton;
        private TextBoxHandler? currentTextBox;
        private List<TextBoxHandler> textBoxes;

        //Constructor
        public Controller(Form form)
        {
            this.form = form;
            menuStrip = new MenuStripHandler();
            initPanel = new PanelHandler();
            mainPanel = new PanelHandler();
            examplesPanel = new PanelHandler();
            resetButton = new ResetButtonHandler(this);
            comboBox = new ComboBoxHandler();
            initButton = new InitButtonHandler(this);
            textBoxes = new List<TextBoxHandler>();

            form.Controls.Add(menuStrip.MenuStrip);
            form.Controls.Add(initPanel.Panel);
            form.Controls.Add(mainPanel.Panel);
            form.Controls.Add(examplesPanel.Panel);
            menuStrip.MenuStrip.Items.Add(resetButton.ToolStripMenuItem);
            initPanel.Panel.Controls.Add(comboBox.ComboBox);
            initPanel.Panel.Controls.Add(initButton.Button);
            Init();
        }

        //Functions
        internal PanelHandler InitPanel => initPanel;
        internal PanelHandler MainPanel => mainPanel;
        internal ComboBoxHandler ComboBox => comboBox;

        private void Init()
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            resetButton.ToolStripMenuItem.Text = "Reset";
            Resize();
            resetButton.ToolStripMenuItem.PerformClick();
            //comboBox.Size = new Size(121, 23);
            for (int i = 2; i <= MAX_LANGUAGES; i++)
            {
                comboBox.ComboBox.Items.Add(i);
            }
            initButton.Button.Text = "Start";
        }

        public void Resize()
        {
            //Size
            initPanel.Panel.Size = new Size(form.ClientRectangle.Width, form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height);
            mainPanel.Panel.Size = new Size(form.ClientRectangle.Width, (form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height) * 2 / 3);
            examplesPanel.Panel.Size = new Size(form.ClientRectangle.Width, (form.ClientRectangle.Height - menuStrip.MenuStrip.Size.Height) / 3);
            foreach(TextBoxHandler textBox in textBoxes)
            {
                textBox.Size = new Size(mainPanel.Size.Width / textBoxes.Count(), mainPanel.Size.Height / 2); ;
                textBox.Location = new Point(textBoxes.IndexOf(textBox) * (mainPanel.Size.Width / textBoxes.Count()), 0);
            }
            //Location
            initPanel.Panel.Location = new Point(0, menuStrip.MenuStrip.Size.Height);
            mainPanel.Panel.Location = new Point(0, menuStrip.MenuStrip.Size.Height);
            examplesPanel.Panel.Location = new Point(0, mainPanel.Panel.Location.Y + mainPanel.Panel.Size.Height);
            comboBox.Location = new Point(initPanel.Panel.Width / 2 - (comboBox.Size.Width + initButton.Size.Width)/2, initPanel.Panel.Height / 2);
            initButton.Location = new Point(comboBox.Location.X + comboBox.Size.Width, comboBox.Location.Y);
        }

        internal void HidePanels()
        {
            foreach(Control control in form.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    control.Enabled = false;
                }
            }
        }

        internal void clearBoxes()
        {
            foreach(TextBoxHandler textBox in textBoxes)
            {
                textBox.Dispose();
            }
            textBoxes.Clear();
        }

        internal void createBoxes(int amount)
        {
            foreach(int i in Enumerable.Range(0, amount))
            {
                currentTextBox = new TextBoxHandler(this);
                textBoxes.Add(currentTextBox);
                mainPanel.Panel.Controls.Add(currentTextBox.TextBox);
            }
            Resize();
        }
    }
}
