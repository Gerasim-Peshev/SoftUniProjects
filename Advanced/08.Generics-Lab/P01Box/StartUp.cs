using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }

    public class Box<T>
    {
        private List<T> internalList = new List<T>(); 
        
        public int Count => this.internalList.Count;
        

        public void Add(T element)
        {
            this.internalList.Add(element);
        }

        public T Remove()
        {
            var element = this.internalList[this.internalList.Count - 1];
            this.internalList.Remove(element);
            return element;
        }
    }
}
