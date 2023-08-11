namespace takaen
{
    internal class Translator
    {
        //Variables
        private Panel translatePanel;
        private TextBox[] textBoxes;

        //Constructor
        public Translator(Panel translatePanel, FileHandler fileHandler)
        {
            this.translatePanel = translatePanel;
            textBoxes = new TextBox[3];
            TranslatorLogic.Dictionary = new Dictionary(fileHandler);
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
            textBoxes[2].Parent!.Dock = DockStyle.Right;

            Resize();
        }

        private void Translator_TextChanged(object? sender, EventArgs e)
        {
            if (((TextBox)sender!).Modified)//User input
            {
                //Variables
                int language = Array.IndexOf(textBoxes, sender);

                //Catch
                if(((TextBox)sender!).Text == string.Empty)
                {
                    foreach(var textBox in textBoxes) 
                    {
                        textBox.Text = string.Empty;
                    }
                    return;
                }

                //Function
                foreach (int i in Enum.GetValues(typeof(Languages)))
                {
                    if (i == language)
                    {

                    }
                    else
                    {
                        textBoxes[i].Text = TranslatorLogic.Translate((Languages)i, (Languages)language, textBoxes[language].Text);
                    }
                }
            }
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
