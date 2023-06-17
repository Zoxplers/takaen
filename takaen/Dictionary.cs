namespace takaen
{
    internal class Dictionary : List<List<List<string>>>
    {
        //Constructor
        internal Dictionary(FileHandler fileHandler)
        {
            foreach (int key in Enum.GetValues(typeof(Keys)))
            {
                List<List<string>> i = new List<List<string>>();
                this.Add(i);
                foreach (int language in Enum.GetValues(typeof(Languages)))
                {
                    List<string> j = new List<string>();
                    i.Add(j);
                }
            }

            fileHandler.GetKeyData(this);
        }

        public override string ToString()
        {
            string print = "";
            foreach (List<List<string>> i in this)
            {
                foreach (List<string> j in i)
                {
                    foreach(string s in j)
                    {
                        print += s + " ";
                    }
                    print += "\n";
                }
                print += "\n";
            }
            return print;
        }
    }
}