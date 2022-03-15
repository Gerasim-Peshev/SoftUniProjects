using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int[] start;
        private int[] end;

        public DateModifier(string start, string end)
        {
            Start = start.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            End = end.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        public int[] Start
        {
            get { return this.start; }
            set { this.start = value; }
        }
        public int[] End
        {
            get { return this.end; }
            set { this.end = value; }
        }

    }
}
