using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models
        {
            get { return this.races; }
        }
        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = null;
            foreach (var race1 in this.races)
            {
                if (race1.RaceName == name)
                {
                    race = race1;
                    break;
                }
            }

            return race;
        }
    }
}
