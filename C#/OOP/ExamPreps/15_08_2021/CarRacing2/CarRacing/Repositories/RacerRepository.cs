using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models = new List<IRacer>();
        public IReadOnlyCollection<IRacer> Models
        {
            get => this.models.AsReadOnly();
        }
        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.Username == property);
        }
    }
}
