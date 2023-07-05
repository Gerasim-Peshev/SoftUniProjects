using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01ListyIterator
{
    public class CustomStack<T> : IEnumerable
    {
        public List<T> Stack { get; set; }
        public CustomStack(List<T> stack)
        {
            this.Stack = new List<T>();
            for (int i = 0; i < stack.Count; i++)
            {
                this.Stack.Insert(0,stack[i]);
            }
        }
        public void Push(List<T> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                this.Stack.Insert(0,elements[i]);
            }
        }

        public void Pop()
        {
            if (this.Stack.Count == 0)
            {
                throw new Exception("No elements");
            }
            this.Stack.RemoveAt(0);
        }

        public void ForEach()
        {
            foreach (var element in Stack)
            {
                Console.WriteLine(element);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
