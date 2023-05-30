using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class ComboBoxHandler : WinFormHandler
    {
        //Variables
        private ComboBox comboBox;

        //Constructor
        internal ComboBoxHandler()
        {
            comboBox = new ComboBox();
        }

        //Functions
        internal ComboBox ComboBox => comboBox;
        internal override Size Size { get => comboBox.Size; set => comboBox.Size = value; }
        internal override Point Location { get => comboBox.Location; set => comboBox.Location = value; }
    }
}
