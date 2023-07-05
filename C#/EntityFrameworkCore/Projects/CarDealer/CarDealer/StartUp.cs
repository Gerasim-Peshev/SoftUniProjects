using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var inputJson1 = File.ReadAllText("../../../Datasets/suppliers.json");
            //var inputJson2 = File.ReadAllText("../../../Datasets/parts.json");
            //var inputJson3 = File.ReadAllText("../../../Datasets/cars.json");
            //var inputJson4 = File.ReadAllText("../../../Datasets/customers.json");
            //var inputJson5 = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, inputJson1));
            //Console.WriteLine(ImportParts(context, inputJson2));
            //Console.WriteLine(ImportCars(context, inputJson3));
            //Console.WriteLine(ImportCustomers(context, inputJson4));
            //Console.WriteLine(ImportSales(context, inputJson5));
            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<ImportSuppliersDTO>>(inputJson);

            var validSuppliers = new List<Supplier>();
            foreach (var importSuppliersDto in suppliers)
            {
                Supplier supplier = new Supplier()
                {
                    Name = importSuppliersDto.Name,
                    IsImporter = importSuppliersDto.IsImporter
                };

                validSuppliers.Add(supplier);
            }

            context.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<ImportPartsDTO>>(inputJson);

            var validParts = new List<Part>();
            foreach (var importPartsDto in parts)
            {
                if (importPartsDto.SupplierId <= 31)
                {
                    Part part = new Part()
                    {
                        Name = importPartsDto.Name,
                        Price = importPartsDto.Price,
                        Quantity = importPartsDto.Qualnity,
                        SupplierId = importPartsDto.SupplierId
                    };

                    validParts.Add(part);
                }
            }

            context.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<ImportCarsDTO>>(inputJson);

            var validCars = new List<Car>();
            foreach (var carDto in cars)
            {
                Car carToAdd = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                validCars.Add(carToAdd);

                var parts = carDto.PartsId.Distinct().ToList();

                if (parts == null)
                {
                    continue;
                }

                foreach (var artId in parts)
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = carToAdd,
                        PartId = artId
                    };

                    carToAdd.PartsCars.Add(partCar);
                }

            }

            context.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<ImportCustomersDTO>>(inputJson);

            var validCustomers = new List<Customer>();
            foreach (var customersDto in customers)
            {
                Customer customer = new Customer()
                {
                    Name = customersDto.Name,
                    BirthDate = customersDto.BirthDate,
                    IsYoungDriver = customersDto.IsYoungDriver
                };

                validCustomers.Add(customer);
            }

            context.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<ImportSalesDTO>>(inputJson);

            var validSales = new List<Sale>();
            foreach (var salesDto in sales)
            {
                if (salesDto.CarId <= 358 && salesDto.CustomerId <= 30)
                {
                    Sale sale = new Sale()
                    {
                        CarId = salesDto.CarId,
                        CustomerId = salesDto.CustomerId,
                        Discount = salesDto.Discount
                    };

                    validSales.Add(sale);
                }
            }

            context.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        //14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                                   .OrderBy(c => c.BirthDate)
                                   .ThenBy(c => c.IsYoungDriver)
                                   .Select(c => new
                                   {
                                       Name = c.Name,
                                       BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                                       IsYoungDriver = c.IsYoungDriver
                                   })
                                   .AsNoTracking()
                                   .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(c => c.Make == "Toyota")
                              .OrderBy(c => c.Model)
                              .ThenByDescending(c => c.TraveledDistance)
                              .Select(c => new
                              {
                                  c.Id,
                                  c.Make,
                                  c.Model,
                                  c.TraveledDistance
                              })
                              .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(s => s.IsImporter == false)
                                   .Select(s => new
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       PartsCount = s.Parts.Count
                                   })
                                   .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                              .Include(c => c.PartsCars)
                              .ThenInclude(c => c.Part)
                              .Select(c => new
                              {
                                  c.Id,
                                  c.Make,
                                  c.Model,
                                  c.TraveledDistance,
                              })
                              .ToList();

            var validPairs = new List<ExportCarsAndPartsDTO>();
            foreach (var car in cars)
            {
                var parts = context.PartsCars
                                   .Where(p => p.Car.Id == car.Id)
                                   .Select(p => new ExportPartsDTO()
                                   {
                                       Name = p.Part.Name,
                                       Price = $"{p.Part.Price:f2}"
                                   })
                                   .ToList();

                ExportCarsAndPartsDTO exportCarsAndParts = new ExportCarsAndPartsDTO()
                {
                    Car = new ExportCarDTO()
                    {
                        Make = car.Make,
                        Model = car.Model,
                        TravalledDistance = car.TraveledDistance
                    },
                    Parts = parts
                };

                validPairs.Add(exportCarsAndParts);
            }

            //File.WriteAllText("../../../Exported2.txt", JsonConvert.SerializeObject(cars, Formatting.Indented));
            return JsonConvert.SerializeObject(validPairs, Formatting.Indented);
        }

        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Count >= 1)
                                   .Select(c => new
                                   {
                                       fullName = c.Name,
                                       boughtCars = c.Sales.Count,
                                       spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))
                                   })
                                   .OrderByDescending(c => c.spentMoney)
                                   .ThenByDescending(c => c.boughtCars)
                                   .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                               .Take(10)
                               .Select(s => new
                                {
                                    car = new
                                    {
                                        s.Car.Make,
                                        s.Car.Model,
                                        s.Car.TraveledDistance
                                    },
                                    customerName = s.Customer.Name,
                                    discount = $"{s.Discount:f2}",
                                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) - (s.Car.PartsCars.Sum(p => p.Part.Price) * (s.Discount / 100)):f2}"
                                })
                               .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}