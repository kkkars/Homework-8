namespace DesignPatterns.ChainOfResponsibility
{
    public class ToUpperMutator : StringMutator
    { 
        public override string Mutate(string str)
        {
            str = str.ToUpper();
            return base.Mutate(str);
        }
    }
}