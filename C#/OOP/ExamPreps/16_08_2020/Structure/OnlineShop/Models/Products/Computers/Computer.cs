using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private decimal price;
        private double overallPerformance;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count <= 0)
                {
                    return this.overallPerformance;
                }
                else
                {
                    List<double> sumAllPerf = new List<double>();
                    foreach (var component in components)
                    {
                        sumAllPerf.Add(component.OverallPerformance);
                    }

                    double averafePerf = sumAllPerf.Average();
                    return this.overallPerformance + averafePerf;
                }

                
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                this.overallPerformance = value;
            }
        }

        public override decimal Price
        {
            get
            {
                return this.price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                this.price = value;
            }
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get => this.components.AsReadOnly();
        }
        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get => this.peripherals.AsReadOnly();
        }
        public void AddComponent(IComponent component)
        {
            if (this.components.Contains(component))
            {
                throw new ArgumentException(
                    $"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            else
            {
                this.components.Add(component);
            }
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            else
            {
                IComponent componentToFind = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
                this.components.Remove(componentToFind);
                return componentToFind;
            }
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException(
                    $"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            else
            {
                this.peripherals.Add(peripheral);
            }
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || peripherals.Any(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(
                    $"Component {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            else
            {
                IPeripheral peripheralToFind = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
                this.peripherals.Remove(peripheralToFind);
                return peripheralToFind;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                $" Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            sb.AppendLine($"Components ({Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            if (peripherals.Count <= 0)
            {
                double averageOverPerf1 = 0;
                sb.AppendLine(
                    $" Peripherals ({Peripherals.Count}); Average Overall Performance ({averageOverPerf1:f2}):");
            }
            else
            {
                List<double> sumOverallPerformancePeriferal = new List<double>();
                foreach (var peripheral in peripherals)
                {
                    sumOverallPerformancePeriferal.Add(peripheral.OverallPerformance);
                }

                double averageOverPerf2 = sumOverallPerformancePeriferal.Average();

                sb.AppendLine(
                    $" Peripherals ({Peripherals.Count}); Average Overall Performance ({averageOverPerf2:f2}):");
                foreach (var peripheral in Peripherals)
                {
                    sb.AppendLine($"  {peripheral:f2}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
