namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : StringMutator
    {
        public override string Mutate(string str)
        {
            str = str.Trim();
            return base.Mutate(str);
        }
    }
}