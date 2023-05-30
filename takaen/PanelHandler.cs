using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takaen
{
    internal class PanelHandler : WinFormHandler
    {
        //Variables
        private Panel panel;

        //Constructor
        public PanelHandler()
        {
            panel = new Panel();
        }

        //Functions
        public Panel Panel => panel;
        internal override Point Location { get => panel.Location; set => panel.Location = value; }
        internal override Size Size { get => panel.Size; set => panel.Size = value; }
    }
}
