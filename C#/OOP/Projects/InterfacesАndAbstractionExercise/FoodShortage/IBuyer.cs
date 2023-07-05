using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; set; }
        void BuyFood();
    }
}
