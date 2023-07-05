using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var sb = new StringBuilder();

            ImportCreatorDTO[] creators = Deserializers<ImportCreatorDTO>(xmlString, "Creators");

            var validCreators = new List<Creator>();
            foreach (var creatorDto in creators)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var creatorDtoBoardgame in creatorDto.Boardgames)
                {
                    if (!IsValid(creatorDtoBoardgame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = creatorDtoBoardgame.Name,
                        Rating = creatorDtoBoardgame.Rating,
                        YearPublished = creatorDtoBoardgame.YearPublished,
                        CategoryType = (CategoryType) creatorDtoBoardgame.CategoryType,
                        Mechanics = creatorDtoBoardgame.Mechanics
                    };

                    creator.Boardgames.Add(boardgame);
                }

                validCreators.Add(creator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                                            creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var sellers = JsonConvert.DeserializeObject<ImportSellerDTO[]>(jsonString);

            var validSellers = new List<Seller>();
            foreach (var sellerDto in sellers)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var sellerDtoBoardgame in sellerDto.Boardgames.Distinct())
                {
                    var boarderGameToFind = context.Boardgames.FirstOrDefault(b => b.Id == sellerDtoBoardgame);

                    if (boarderGameToFind == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = sellerDtoBoardgame
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                validSellers.Add(seller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
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
