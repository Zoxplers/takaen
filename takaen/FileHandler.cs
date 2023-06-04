using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takaen
{
    internal class FileHandler
    {
        //Constants
        internal const String DICTIONARYURI = "";
        internal const String GRAMMARSURI = "";

        //Variables
        HttpClient httpClient;

        //Constructor
        internal FileHandler()
        {
            httpClient = new HttpClient();
        }

        //Functions
        internal bool InitAsync()
        {
            
            bool init = false;

            /*
            var response = httpClient.GetStreamAsync(DICTIONARYURI).GetAwaiter().GetResult();
            if(response.IsSuccessStatusCode())
            {

            }
            */

            return init;
        }
    }
}
