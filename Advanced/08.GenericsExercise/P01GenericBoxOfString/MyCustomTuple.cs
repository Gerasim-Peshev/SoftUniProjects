﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01GenericBoxOfString
{
    public class MyCustomTuple<T1, T2, T3>
    {
        public MyCustomTuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }


        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
