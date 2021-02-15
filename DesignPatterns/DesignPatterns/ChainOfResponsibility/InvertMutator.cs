using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : StringMutator
    {
        public override string Mutate(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return base.Mutate(new string(arr));
        }
    }
}