using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers.AsReadOnly();
        }

        public void Add(IDriver model)
        {
            this.drivers.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
