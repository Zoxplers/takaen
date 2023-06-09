namespace takaen
{
    internal class Translator
    {
        //Variables
        private Panel translatePanel;
        private TextBox[] textBoxes;
        private Dictionary dictionary;

        //Constructor
        public Translator(Panel translatePanel, FileHandler fileHandler)
        {
            this.translatePanel = translatePanel;
            textBoxes = new TextBox[3];
            dictionary = new Dictionary(fileHandler);
            Init();
        }

        //Functions
        private void Init()
        {
            for(int i = 0; i < textBoxes.Length; i++)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = ((Languages)i).ToString();
                translatePanel.Controls.Add(groupBox);
                
                TextBox textBox = new TextBox();
                textBox.AutoSize = false;
                //textBox.BackColor = Color.FromArgb(100, Color.White);
                textBox.Font = new Font(FontFamily.GenericSansSerif, 12f);
                textBox.TextChanged += Translator_TextChanged;
                textBoxes[i] = textBox;
                groupBox.Controls.Add(textBox);
            }

            
            textBoxes[0].Parent!.Dock = DockStyle.Left;
            textBoxes[1].Parent!.Dock = DockStyle.Top;
            textBoxes[1].Parent!.BringToFront();
            textBoxes[1].Parent!.MouseHover += Translator_MouseHover;
            textBoxes[2].Parent!.Dock = DockStyle.Right;

            Resize();
        }

        private void Translator_TextChanged(object? sender, EventArgs e)
        {
            int language = Array.IndexOf(textBoxes, sender);
            foreach(int i in Enum.GetValues(typeof(Languages)))
            {
                if(i == language)
                {

                }
                else
                {
                    textBoxes[i].Text = Translate((Languages)i, textBoxes[language].Text);
                }
            }
        }

        private string Translate(Languages languages, string str)
        {
            return str;
        }

        /// <summary>
        /// Small patch because winforms sucks.
        /// </summary>
        private void Translator_MouseHover(object? sender, EventArgs e)
        {
            Resize();
            textBoxes[1].Parent!.MouseHover -= Translator_MouseHover;
        }

        internal void Resize()
        {
            textBoxes[1].Parent!.Height = translatePanel.Height;
            foreach (TextBox textBox in textBoxes)
            {
                GroupBox groupBox = (GroupBox)textBox.Parent!;
                groupBox.Width = translatePanel.Width / 3;
                groupBox.Controls[0].Size = new Size((int)(groupBox.Width * 0.9), (int)(groupBox.Height * 0.5));
                groupBox.Controls[0].Location = new Point((int)(groupBox.Width * 0.05), (int)(groupBox.Height * 0.1));
            }
        }

        internal void CleanUp()
        {
            foreach(Control control in translatePanel.Controls)
            {
                control.Dispose();
            }
            translatePanel.Controls.Clear();
        }
    }
}
