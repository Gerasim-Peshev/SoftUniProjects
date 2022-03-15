using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01ListyIterator
{
    public class ListyIterator<T> : IEnumerable
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
            => this.index < elements.Count -1;

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.elements[this.index]);
            }
        }

        public void PrintAll()
        {
            foreach (var element in elements)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
