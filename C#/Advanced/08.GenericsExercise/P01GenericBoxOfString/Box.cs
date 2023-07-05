using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace P01GenericBoxOfString
{
    public class Box<T>
    where T: IComparable
    {
        private T sentence;
        private int count;

        public List<T> List { get; set; }
        public Box(List<T> word)
        {
            this.List = word;
        }

        public int CompareAll(T word)
            => List.Count(x => x.CompareTo(word) > 0);

        public override string ToString()
        {
            return $"{typeof(T)}: {sentence}";
        }
    }
}
