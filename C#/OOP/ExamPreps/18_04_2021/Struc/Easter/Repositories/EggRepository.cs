using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models
        {
            get => this.eggs.AsReadOnly();
        }
        public void Add(IEgg model)
        {
            if (this.eggs.Any(x=>x.Name == model.Name) == false)
            {
                this.eggs.Add(model);
            }
        }

        public bool Remove(IEgg model)
        {
            return this.eggs.Remove(model);
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(x => x.Name == name);
        }
    }
}
