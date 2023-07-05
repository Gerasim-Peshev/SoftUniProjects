using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Data;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var departures = Deserializers<ImportDespatchersDTO>(xmlString, "Despatchers");

            var validDepartures = new List<Despatcher>();
            foreach (var despatcherDto in departures)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validTrucks = new HashSet<Truck>();
                foreach (var despatcherDtoTruck in despatcherDto.Trucks)
                {
                    if (!IsValid(despatcherDtoTruck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = despatcherDtoTruck.RegistrationNumber,
                        VinNumber = despatcherDtoTruck.VinNumber,
                        TankCapacity = despatcherDtoTruck.TankCapacity,
                        CargoCapacity = despatcherDtoTruck.CargoCapacity,
                        CategoryType = (CategoryType)despatcherDtoTruck.CategoryType,
                        MakeType = (MakeType)despatcherDtoTruck.MakeType
                    };

                    validTrucks.Add(truck);
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };

                validDepartures.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDepartures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var clients = JsonConvert.DeserializeObject<ImportClientDTO[]>(jsonString);

            var validClients = new HashSet<Client>();
            foreach (var clientDto in clients)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == null || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                    ClientsTrucks = new List<ClientTruck>()
                };

                var validTrucks = new HashSet<ClientTruck>();
                foreach (var clientDtoTruck in clientDto.Trucks.Distinct())
                {
                    var truckToFind = context.Trucks.FirstOrDefault(t => t.Id == clientDtoTruck);
                    if (truckToFind == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = clientDtoTruck
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                validClients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name,client.ClientsTrucks.Count));
            }
            
            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static T[] Deserializers<T>(
            string xmlObjectsAsString,
            string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            var dataTransferObjects = serializer.Deserialize(new StringReader(xmlObjectsAsString)) as T[];

            return dataTransferObjects;
        }
    }
}