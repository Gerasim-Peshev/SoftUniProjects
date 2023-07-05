using System.Net.Http.Headers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            Console.WriteLine(GetUsersWithProducts(context));
        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var desUsers = JsonConvert.DeserializeObject<List<ImportUserDTO>>(inputJson);

            var validUsers = new List<User>();

            foreach (var desUser in desUsers!)
            {
                User user = new User()
                {
                    FirstName = desUser.FirstName,
                    LastName = desUser.LastName!,
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
            //var desProducts = JsonConvert.DeserializeObject<List<ImportProductDTO>>(inputJson);

            //var validProducts = new List<Product>();

            //foreach (var productDTO in desProducts)
            //{
            //    Product product = new Product()
            //    {
            //        Name = productDTO.Name,
            //        Price = productDTO.Price,
            //        SellerId = productDTO.SellerId,
            //        BuyerId = productDTO.BuyerId.GetValueOrDefault()
            //    };

            //    validProducts.Add(product);
            //}

            //context.AddRange(validProducts);
            //context.SaveChanges();

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            List<ImportProductDTO> desProducts = JsonConvert.DeserializeObject<List<ImportProductDTO>>(inputJson)!;
            List<Product> validProducts = mapper.Map<List<Product>>(desProducts);

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var desCategories = JsonConvert.DeserializeObject<List<ImportCategoryDTO>>(inputJson);

            var validCategories = new List<Category>();
            foreach (var desCategory in desCategories!)
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

            List<ImportCategoryProductDTO> desCategoryProduct = JsonConvert.DeserializeObject<List<ImportCategoryProductDTO>>(inputJson)!;
            List<CategoryProduct> validCategoryProduct = new List<CategoryProduct>();

            foreach (var categoryProductDto in desCategoryProduct!)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                validCategoryProduct.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validCategoryProduct);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProduct.Count}";
        }

        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var productsToExport = context.Products
                                          .Where(e => e.Price >= 500 && e.Price <= 1000)
                                          .OrderBy(e => e.Price)
                                          .AsNoTracking()
                                          .ProjectTo<ExportProductsInRangeDTO>(mapper.ConfigurationProvider)
                                          .ToArray();

            return JsonConvert.SerializeObject(productsToExport, Formatting.Indented);
        }

        //06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                               .AsNoTracking()
                               .Where(e => e.ProductsSold.Count >= 1 && e.ProductsSold.Any(u => u.BuyerId != null))
                               .OrderBy(e => e.LastName)
                               .ThenBy(e => e.FirstName)
                               .Select(e => new
                                {
                                    firstName = e.FirstName,
                                    lastName = e.LastName,
                                    soldProducts = e.ProductsSold
                                                    .Select(p => new
                                                     {
                                                         name = p.Name,
                                                         price = p.Price,
                                                         buyerFirstName = p.Buyer!.FirstName,
                                                         buyerLastName = p.Buyer.LastName
                                                     }).ToList()
                                }).ToList();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        //07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .AsNoTracking()
                                    .OrderByDescending(e => e.CategoriesProducts.Count)
                                    .Select(e => new
                                     {
                                         category = e.Name,
                                         productsCount = e.CategoriesProducts.Count,
                                         averagePrice = $"{e.CategoriesProducts.Average(p => p.Product.Price):f2}",
                                         totalRevenue = $"{e.CategoriesProducts.Sum(p => p.Product.Price):f2}"
                                     })
                                    .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                               .AsNoTracking()
                               .Where(e => e.ProductsSold.Any(u => u.BuyerId != null))
                               .Select(e => new
                                {
                                    e.LastName,
                                    e.Age,
                                    soldProducts = new
                                    {
                                        count = e.ProductsSold.Count(p => p.BuyerId != null),
                                        products = e.ProductsSold
                                                    .Where(p => p.Buyer != null)
                                                    .Select(p => new
                                        {
                                            p.Name,
                                            p.Price
                                        }).ToList()
                                    }
                                })
                               .OrderByDescending(e => e.soldProducts.count)
                               .ToList();

            var userWrapper = new
            {
                count = users.Count,
                users = users
            };

            return JsonConvert.SerializeObject(userWrapper, Formatting.Indented);
        }
    }
}