namespace takaen
{
    internal class Scanner
    {
        //Constants
        private readonly char[] WHITESPACE = new char[] {' ', '\n', '\t', '\r'};

        //Variables
        private StreamReader reader;
        private string? token;
        

        //Constructor
        internal Scanner(string path)
        {
            if(File.Exists(path))
            {
                reader = new StreamReader(path);
                token = string.Empty;
                SkipWhitespace();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        //Functions
        private void SkipWhitespace()
        {
            while(WHITESPACE.Contains((char)reader.Peek()))
            {
                reader.Read();
            }
        }
        private void SkipWhitespace(char sep)
        {
            while (WHITESPACE.Contains((char)reader.Peek()) || reader.Peek() == sep)
            {
                reader.Read();
            }
        }


        internal bool HasNext()
        {
            return !reader.EndOfStream;
        }

        internal string? Next()
        {
            if(reader.EndOfStream)
            {
                return null;
            }
            else
            {
                token = string.Empty;
                while(!(WHITESPACE.Contains((char)reader.Peek()) || reader.EndOfStream))
                {
                    token += (char)reader.Read();
                }
                SkipWhitespace();
                return token!;
            }
        }

        internal string? Next(char sep)
        {
            if (reader.EndOfStream)
            {
                return null;
            }
            else
            {
                token = string.Empty;
                while (!(WHITESPACE.Contains((char)reader.Peek()) || reader.EndOfStream || reader.Peek() == sep))
                {
                    token += (char)reader.Read();
                }
                SkipWhitespace(sep);
                return token!;
            }
        }

        internal void Close()
        {
            reader.Close();
        }
    }
}