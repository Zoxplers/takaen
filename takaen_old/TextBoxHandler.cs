using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class TextBoxHandler : WinFormHandler
    {
        //Variables
        private Controller controller;
        private TextBox textBox;

        //Constructor
        internal TextBoxHandler(Controller controller)
        {
            this.controller = controller;
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.TextChanged += TextBox_TextChanged;
        }

        //Functions
        internal TextBox TextBox => textBox;
        internal override Size Size { get => textBox.Size; set => textBox.Size = value; }
        internal override Point Location { get => textBox.Location; set => textBox.Location = value; }
        internal void Dispose()
        {
            textBox.TextChanged -= TextBox_TextChanged;
            textBox.Parent?.Controls.Remove(textBox);
            textBox.Dispose();
        }
        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
