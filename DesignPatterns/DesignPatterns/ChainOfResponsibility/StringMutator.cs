namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class StringMutator : IStringMutator
    {
        private IStringMutator _nextInLine;

        public IStringMutator SetNext(IStringMutator next)
        {
            _nextInLine = next;
            return next;
        }

        public virtual string Mutate(string str)
        {
            if (_nextInLine != null)
            {
                return _nextInLine.Mutate(str);
            }
            else
            {
                return str;
            }
        }
    }
}
