using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models
        {
            get { return this.pilots; }
        }
        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public bool Remove(IPilot model)
        {
            return this.pilots.Remove(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = null;
            foreach (var pilot1 in this.pilots)
            {
                if (pilot1.FullName == name)
                {
                    pilot = pilot1;
                    break;
                }
            }

            return pilot;
        }
    }
}
