using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
    }
}
