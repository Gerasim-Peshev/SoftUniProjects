using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        public IReadOnlyCollection<ICar> Models { get; }
        public void Add(ICar model)
        {
            //if (model is null)
            //{
            //    throw new ArgumentException("Cannot add null in Car Repository");
            //}
            //else
            //{
                
            //}
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }

        public ICar FindBy(string property)
        {
            throw new NotImplementedException();
        }
    }
}
