using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class InitButtonHandler : WinFormHandler
    {
        //Variables
        private Controller controller;
        private Button button;

        //Constructor
        internal InitButtonHandler(Controller controller)
        {
            this.controller = controller;
            button = new Button();
            button.Click += Button_Click;
        }

        //Functions
        internal Button Button => button;
        internal override Size Size { get => button.Size; set => button.Size = value; }
        internal override Point Location { get => button.Location; set => button.Location = value; }
        private void Button_Click(object? sender, EventArgs e)
        {
            controller.HidePanels();
            controller.MainPanel.Panel.Visible = true;
            controller.MainPanel.Panel.Enabled = true;
            controller.createBoxes(controller.ComboBox.ComboBox.Text[0] - '0');
        }

    }
}
