using System;
using System.Collections.Generic;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System.Linq;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            if (gymType == nameof(BoxingGym))
            {
                this.gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                this.gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGymType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == nameof(BoxingGloves))
            {
                this.equipment.Add(new BoxingGloves());
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                this.equipment.Add(new Kettlebell());
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidEquipmentType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (this.equipment.FindByType(equipmentType) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidEquipmentType, equipmentType));
            }

            IEquipment equipment = this.equipment.FindByType(equipmentType);
            IGym gym = gyms.First(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            string gymWhereCanTrain = athleteType == nameof(Boxer) ? nameof(BoxingGym) : nameof(WeightliftingGym);
            IGym gymToAddTo = gyms.First(x => x.Name == gymName);
            if (gymToAddTo.GetType().Name != gymWhereCanTrain)
            {
                return OutputMessages.InappropriateGym;
            }
            else
            {
                gymToAddTo.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

        }

        public string TrainAthletes(string gymName)
        {
            IGym gymToFind = this.gyms.First(x => x.Name == gymName);
            gymToFind.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gymToFind.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gymToFind = this.gyms.First(x => x.Name == gymName);
            double weightTotal = gymToFind.EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, weightTotal);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
