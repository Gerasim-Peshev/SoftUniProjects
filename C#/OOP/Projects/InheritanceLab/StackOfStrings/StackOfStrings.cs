using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count < 0)
            {
                return true;
            }

            return false;
        }

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (var element in elements)
            {
                Push(element);
            }

            return this;
        }
    }
}
