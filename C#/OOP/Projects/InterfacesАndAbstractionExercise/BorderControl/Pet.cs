using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IPet
    {
        public Pet(string name, string date)
        {
            this.Name = name;
            this.Date = date;
        }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
