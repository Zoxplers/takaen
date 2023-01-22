using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krjpen
{
    internal class MenuStripHandler : WinFormHandler
    {
        //Variables
        private MenuStrip menuStrip;

        //Constructor
        public MenuStripHandler()
        {
            menuStrip = new MenuStrip();
        }

        //Functions
        public MenuStrip MenuStrip => menuStrip;
        internal override Point Location { get => menuStrip.Location; set => menuStrip.Location = value; }
        internal override Size Size { get => menuStrip.Size; set => menuStrip.Size = value; }
    }
}
