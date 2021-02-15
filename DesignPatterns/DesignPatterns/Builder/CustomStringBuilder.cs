namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private static string _text;

        public CustomStringBuilder()
        {
            _text = "";
        }

        public CustomStringBuilder(string text)
        {
            _text = text;
        }

        public ICustomStringBuilder Append(string str)
        {
            _text += str;
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            _text += ch;
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            _text += "\n";
            return this;
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            _text += $"\n{str}";
            return this;
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            _text += $"\n{ch}";
            return this;
        }

        public string Build()
        {
            return _text;
        }
    }
}