using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var departures = context.Despatchers
                                    .AsNoTracking()
                                    .Where(d => d.Trucks.Count > 0)
                                    .Select(d => new ExportDespatcherDTO()
                                     {
                                         DespatcherName = d.Name,
                                         TrucksCount = d.Trucks.Count,
                                         Trucks = d.Trucks
                                                   .Select(t => new ExportTruckDTO()
                                                    {
                                                        RegistrationNumber = t.RegistrationNumber,
                                                        Make = t.MakeType.ToString()
                                                    })
                                                   .OrderBy(t => t.RegistrationNumber)
                                                   .ToArray()
                                     })
                                    .OrderByDescending(d => d.Trucks.Length)
                                    .ThenBy(d => d.DespatcherName)
                                    .ToArray();

            return Serializes(departures, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                                 .AsNoTracking()
                                 .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                                 .Select(c => new
                                  {
                                      c.Name,
                                      Trucks = c.ClientsTrucks
                                                .Where(t => t.Truck.TankCapacity >= capacity)
                                                .OrderBy(t => t.Truck.MakeType)
                                                .ThenByDescending(t => t.Truck.CargoCapacity)
                                                .Select(t => new
                                                 {
                                                     TruckRegistrationNumber = t.Truck.RegistrationNumber,
                                                     VinNumber = t.Truck.VinNumber,
                                                     TankCapacity = t.Truck.TankCapacity,
                                                     CargoCapacity = t.Truck.CargoCapacity,
                                                     CategoryType = t.Truck.CategoryType.ToString(),
                                                     MakeType = t.Truck.MakeType.ToString()
                                                 })
                                                .ToList()
                                  })
                                 .OrderByDescending(c => c.Trucks.Count)
                                 .ThenBy(c => c.Name)
                                 .Take(10)
                                 .ToList();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }

        public static string Serializes<T>(
            T[] dataTransferObjects,
            string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            var builder = new StringBuilder();

            using var writer = new StringWriter(builder);
            serializer.Serialize(writer, dataTransferObjects, GetXmlNamespaces());

            return builder.ToString();
        }

        public static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}
