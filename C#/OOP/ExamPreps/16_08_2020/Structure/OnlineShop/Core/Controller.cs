using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.peripherals = new List<IPeripheral>();
            this.components = new List<IComponent>();
        }
        //NoCheck
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException($"Computer with this id already exists.");
            }
            else
            {
                if (computerType == nameof(DesktopComputer))
                {
                    this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
                }
                else if (computerType == nameof(Laptop))
                {
                    this.computers.Add(new Laptop(id, manufacturer, model, price));
                }
                else
                {
                    throw new ArgumentException("Computer type is invalid.");
                }
            }

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (this.computers.Any(x => x.Id != computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                IComputer computerToAddTo = computers.FirstOrDefault(x => x.Id == computerId);
                if (this.peripherals.Any(x => x.Id == id))
                {
                    throw new ArgumentException("Peripheral with this id already exists.");
                }
                else
                {
                    IPeripheral peripheralTOAdd = null;
                    if (peripheralType == nameof(Headset))
                    {
                        peripheralTOAdd = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    }
                    else if (peripheralType == nameof(Mouse))
                    {
                        peripheralTOAdd = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    }
                    else if (peripheralType == nameof(Keyboard))
                    {
                        peripheralTOAdd = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    }
                    else if (peripheralType == nameof(Monitor))
                    {
                        peripheralTOAdd = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    }
                    else
                    {
                        throw new ArgumentException("Peripheral type is invalid.");
                    }
                    this.peripherals.Add(peripheralTOAdd);
                    computerToAddTo.AddPeripheral(peripheralTOAdd);

                    return
                        $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
                }
            }
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (this.computers.Any(x => x.Id != computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                IComputer computerToFind = this.computers.FirstOrDefault(x => x.Id == computerId);
                IPeripheral peripheralToFind = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
                computerToFind.RemovePeripheral(peripheralType);
                this.peripherals.Remove(peripheralToFind);
                return $"Successfully removed {peripheralType} with id { peripheralToFind.Id}.";
            }
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.computers.Any(x => x.Id != computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                if (this.components.Any(x=>x.Id == id))
                {
                    throw new ArgumentException("Component with this id already exists.");
                }
                else
                {
                    IComputer computerToFind = this.computers.FirstOrDefault(x => x.Id == computerId);
                    IComponent componentToAdd = null;
                    if (componentType == nameof(CentralProcessingUnit))
                    {
                        componentToAdd =
                            new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else if (componentType == nameof(Motherboard))
                    {
                        componentToAdd =
                            new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else if (componentType == nameof(PowerSupply))
                    {
                        componentToAdd =
                            new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else if (componentType == nameof(RandomAccessMemory))
                    {
                        componentToAdd =
                            new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else if (componentType == nameof(SolidStateDrive))
                    {
                        componentToAdd =
                            new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else if (componentType == nameof(VideoCard))
                    {
                        componentToAdd = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    }
                    else
                    {
                        throw new ArgumentException("Component type is invalid.");
                    }

                    this.components.Add(componentToAdd);
                    computerToFind.AddComponent(componentToAdd);
                    return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
                }
            }
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (this.computers.Any(x => x.Id != computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                IComputer computerToFind = this.computers.FirstOrDefault(x => x.Id == computerId);
                IComponent componentToFind = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
                computerToFind.RemovePeripheral(componentType);
                this.components.Remove(componentToFind);
                return $"Successfully removed {componentType} with id { componentToFind.Id}.";
            }
        }

        public string BuyComputer(int id)
        {
            if (this.computers.Any(x => x.Id != id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                IComputer computerToFind = this.computers.FirstOrDefault(x => x.Id == id);
                this.computers.Remove(computerToFind);
                return computerToFind.ToString();
            }
        }

        //NoCheck
        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            else
            {
                IComputer computerToFind = this.computers.Where(x => x.Price <= budget)
                                               .OrderByDescending(x => x.OverallPerformance).First();
                if (computerToFind == null)
                {
                    throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
                }
                else
                {
                    this.computers.Remove(computerToFind);
                    return computerToFind.ToString();
                }
            }
        }

        public string GetComputerData(int id)
        {
            if (this.computers.Any(x => x.Id != id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            else
            {
                IComputer computerToFind = this.computers.Find(x => x.Id == id);
                return computerToFind.ToString();
            }
        }
    }
}
