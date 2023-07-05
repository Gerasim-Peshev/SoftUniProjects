﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }

        public abstract string CastAbility();
    }
}
