using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value;
                if (this.power < 0)
                {
                    this.power = 0;
                }
            }
        }
        public void Use()
        {
            this.Power -= 10;
        }

        public bool IsFinished()
        {
            if (this.power == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
