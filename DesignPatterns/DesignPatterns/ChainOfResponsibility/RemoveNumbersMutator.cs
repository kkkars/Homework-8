using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : StringMutator
    {
        public override string Mutate(string str)
        {
            var strWithoutNumbers = str.Where(ch => !char.IsDigit(ch)).Select(ch => ch).ToArray();
            return base.Mutate(new string(strWithoutNumbers));
        }
    }
}