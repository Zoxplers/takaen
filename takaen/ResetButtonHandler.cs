using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class ResetButtonHandler : WinFormHandler
    {
        //Variables
        private Controller controller;
        private ToolStripMenuItem toolStripMenuItem;
        private Point point;

        //Constructor
        internal ResetButtonHandler(Controller controller)
        {
            this.controller = controller;
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Click += ButtonClick;
            point = new Point();
        }

        //Functions
        internal ToolStripMenuItem ToolStripMenuItem => toolStripMenuItem;
        internal override Point Location { get => point; set => point = value; }
        internal override Size Size { get => toolStripMenuItem.Size; set => toolStripMenuItem.Size = value; }

        private void ButtonClick(object? sender, EventArgs e)
        {
            controller.HidePanels();
            controller.clearBoxes();
            controller.InitPanel.Panel.Enabled = true;
            controller.InitPanel.Panel.Visible = true;
            controller.ComboBox.ComboBox.DroppedDown = true;
        }
    }
}
