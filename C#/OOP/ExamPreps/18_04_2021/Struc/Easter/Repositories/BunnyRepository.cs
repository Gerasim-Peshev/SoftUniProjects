using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models
        {
            get => this.bunnies.AsReadOnly();
        }
        public void Add(IBunny model)
        {
            if (this.bunnies.Any(x=>x.Name == model.Name) == false)
            {
                this.bunnies.Add(model);
            }
        }

        public bool Remove(IBunny model)
        {
            return this.bunnies.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return this.bunnies.FirstOrDefault(x => x.Name == name);
        }
    }
}
