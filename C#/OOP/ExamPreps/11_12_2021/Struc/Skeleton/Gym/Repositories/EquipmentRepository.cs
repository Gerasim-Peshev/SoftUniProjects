using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments;

        public EquipmentRepository()
        {
            this.equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models
        {
            get => this.equipments.AsReadOnly();
        }
        public void Add(IEquipment model)
        {
            this.equipments.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.equipments.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipments.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}