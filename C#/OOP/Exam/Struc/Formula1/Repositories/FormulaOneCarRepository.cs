using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get { return this.cars; }
        }
        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.cars.Remove(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar car = null;
            foreach (var formulaOneCar in this.cars)
            {
                if (formulaOneCar.Model == name)
                {
                    car = formulaOneCar;
                    break;
                }
            }

            return car;
        }
    }
}
