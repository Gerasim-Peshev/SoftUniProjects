using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            IDye dye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);
            while (egg.IsDone() == false && bunny.Energy > 0 && dye != null)
            {
                egg.GetColored();
                dye.Use();
                bunny.Work();
                if (dye.IsFinished() == true)
                {
                    dye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);
                }
            }
        }
    }
}
