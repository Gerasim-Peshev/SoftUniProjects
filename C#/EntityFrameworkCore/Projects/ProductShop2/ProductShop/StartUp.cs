using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopProfile context = new ProductShopProfile();


        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var desUsers = JsonConvert.DeserializeObject<List<ImportUsersDTO>>(inputJson);

            var validUsers = new List<User>();

            foreach (var desUser in desUsers)
            {
                User user = new User()
                {
                    FirstName = desUser.FirstName,
                    LastName = desUser.LastName,
                    Age = desUser.Age
                };

                validUsers.Add(user);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var desProducts = JsonConvert.DeserializeObject<List<ImportProductsDTO>>(inputJson);

            var validProducts = new List<Product>();

            foreach (var productDTO in desProducts)
            {
                Product product = new Product()
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    SellerId = productDTO.SellerId,
                    BuyerId = productDTO.BuyerId.GetValueOrDefault()
                };

                validProducts.Add(product);
            }

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var desCategories = JsonConvert.DeserializeObject<List<ImportCategoriesDTO>>(inputJson);

            var validCategories = new List<Category>();
            foreach (var desCategory in desCategories)
            {
                if (desCategory.Name != null)
                {
                    Category category = new Category()
                    {
                        Name = desCategory.Name
                    };

                    validCategories.Add(category);
                }
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04
        static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var desCatProd = JsonConvert.DeserializeObject<List<ImportCategoriesProductsDTO>>(inputJson);

            var validCategoryProducts = new List<CategoryProduct>();
            foreach (var categoriesProductsDto in desCatProd)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoriesProductsDto.CategoryId,
                    ProductId = categoriesProductsDto.ProductId
                };

                validCategoryProducts.Add(categoryProduct);
            }

            context.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsToExport = context.Products
                                          .AsNoTracking()
                                          .Where(e => e.Price >= 500 && e.Price <= 1000)
                                          .OrderBy(e => e.Price)
                                          .Select(e => new
                                          {
                                              name = e.Name,
                                              price = e.Price,
                                              seller = e.Seller.FirstName + " " + e.Seller.LastName
                                          })
                                          .ToList();

            return JsonConvert.SerializeObject(productsToExport, Formatting.Indented);
        }
    }
}