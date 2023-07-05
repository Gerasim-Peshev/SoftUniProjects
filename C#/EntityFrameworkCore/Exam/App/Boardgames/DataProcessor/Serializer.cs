using Boardgames.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                                  .Where(c => c.Boardgames.Count > 0)
                                  .Select(c => new ExportCreatorDTO()
                                   {
                                       CreatorName = c.FirstName + " " + c.LastName,
                                       BoardgamesCount = c.Boardgames.Count,
                                       Boardgames = c.Boardgames
                                                     .Select(b => new ExportBoardergameDTO()
                                                      {
                                                          BoardgameName = b.Name,
                                                          BoardgameYearPublished = b.YearPublished
                                                      })
                                                     .OrderBy(b => b.BoardgameName)
                                                     .ToArray()
                                   })
                                  .OrderByDescending(c => c.BoardgamesCount)
                                  .ThenBy(c => c.CreatorName)
                                  .ToArray();

            return Serializes(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                                 .Where(s => s.BoardgamesSellers.Any(
                                            b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
                                 .Select(s => new
                                  {
                                      Name = s.Name,
                                      Website = s.Website,
                                      Boardgames = s.BoardgamesSellers
                                                    .Where(b => b.Boardgame.YearPublished >= year &&
                                                                b.Boardgame.Rating <= rating)
                                                    .Select(b => new
                                                     {
                                                         Name = b.Boardgame.Name,
                                                         Rating = b.Boardgame.Rating,
                                                         Mechanics = b.Boardgame.Mechanics,
                                                         Category = b.Boardgame.CategoryType.ToString()
                                                     })
                                                    .OrderByDescending(b => b.Rating)
                                                    .ThenBy(b => b.Name)
                                                    .ToList()
                                  })
                                 .OrderByDescending(s => s.Boardgames.Count)
                                 .ThenBy(s => s.Name)
                                 .Take(5)
                                 .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
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