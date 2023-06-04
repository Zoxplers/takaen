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

        //Variables
        internal FileHandler fileHandler;
        internal Translator translator;

        //Constructor
        internal Controller()
        {
            fileHandler = new FileHandler();
            translator = new Translator();
        }

        //Functions
        internal void Init(Form1 form)
        {
            if(fileHandler.InitAsync())
            {

            }
        }
    }
}
