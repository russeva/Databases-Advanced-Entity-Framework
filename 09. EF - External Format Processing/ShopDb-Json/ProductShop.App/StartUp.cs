namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;
    using Newtonsoft.Json;
    using ProductShop.App.Dto;
    using ProductShop.App.Dto.Export;
    using ProductShop.App.Dto.Import;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();
            context.Database.EnsureCreated();

            using (context)
            {
                //ImportUsers(context, mapper);
                //ImportProducts(context, mapper);
                // ImportCategories(context,mapper);
                //ImportCategoriesProducts(context, mapper);
                // GetProductInRange(context, mapper);
                //GetSuccessfullySoldProdutcs(context, mapper);
                //GetCategoriesByProductCount(context, mapper);
                GetUsersAndProducts(context, mapper);
            }

        }

        

        private static void ImportCategories(ProductShopContext context, IMapper mapper)
        {
            string jsonString = File.ReadAllText("../../../Json/categories.json");
            CategoriesDto[] categoriesDto = JsonConvert.DeserializeObject<CategoriesDto[]>(jsonString);
            Category[] categories = mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public static void ImportUsers(ProductShopContext context, IMapper mapper)
        {
            string jsonString = File.ReadAllText("../../../Json/users.json");
            Dto.Import.UserDto[] userDtos = JsonConvert.DeserializeObject<Dto.Import.UserDto[]>(jsonString);
            User[] users = mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();
            
        }

        public static void ImportProducts(ProductShopContext context, IMapper mapper)
        {
            string jsonString = File.ReadAllText("../../../Json/products.json");
            ProductDto[] productDtos = JsonConvert.DeserializeObject<ProductDto[]>(jsonString);
            Product[] products = mapper.Map<Product[]>(productDtos);

            List<Product> listProducts = new List<Product>();
            int counter = 0;
            foreach (Product product in products)
            {
                var randomBuyer = new Random().Next(1, 57);
                var randomSeller = new Random().Next(1, 57);
                counter++;

                if(counter == 4)
                {
                    product.BuyerId = null;
                    counter = 0;
                }
                else
                {
                    product.BuyerId = randomBuyer;
                }
                product.SellerId = randomSeller;

                listProducts.Add(product);
            }

            Console.WriteLine();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void ImportCategoriesProducts(ProductShopContext context, IMapper mapper)
        {
            int[] productIds = context
               .Products
               .Select(p => p.Id)
               .ToArray();

            int[] categoryIds = context
                .Categories
                .Select(c => c.Id)
                .ToArray();

            Random random = new Random();
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (int product in productIds)
            {
                int index = random.Next(0, categoryIds.Length);
                    while (categoryProducts.Any(cp => cp.ProductId == product && cp.CategoryId == categoryIds[index]))
                    {
                        index = random.Next(0, categoryIds.Length);
                    }

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        ProductId = product,
                        CategoryId = categoryIds[index]
                    };

                    categoryProducts.Add(categoryProduct);
                
            }
            Console.WriteLine();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        public static void GetProductInRange(ProductShopContext context, IMapper mapper)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 || x.Price <= 1000)
                .Select(p => new ProductInRangeDto() {
                    Name = p.Name,
                    Price = p.Price,
                    FullNameSeller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();


            string jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText($"../../../Dto/Export/products-in-range.json", jsonString);
        }

        private static void GetSuccessfullySoldProdutcs(ProductShopContext context, IMapper mapper)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count() >= 1)
                .Select(p => new UserExportDto()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    SoldProducts = p.ProductsSold.Select(sp => new SoldProductsDto() {
                        Name = sp.Name,
                        Price = sp.Price,
                        BuyerFirstName = sp.Buyer.FirstName,
                        BuyerLastName = sp.Buyer.LastName
                    }).ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("../../../Dto/Export/sold-products.json", jsonString);
        }

       private static void GetCategoriesByProductCount(ProductShopContext context, IMapper mapper)
        {
            var categories = context.Categories
                 .Select(c => new CategoriesByProductDto() {
                     Category = c.Name,
                     ProductsCount = c.CategoryProducts.Select(x => x.Product).Count(),
                      AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                      TotalRevenue = c.CategoryProducts.Select(x => x.Product.Price).Sum()
                 })
                 .OrderBy(o => o.ProductsCount)
                 .ToArray();

            string jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("../../../Dto/Export/categories-by-product.json",jsonString);
        }

        private static void GetUsersAndProducts(ProductShopContext context, IMapper mapper)
        {
            UserRootDto users = new UserRootDto()
            {
                UserCount = context.Users.Count(u => u.ProductsSold.Count >= 1),
                UserDetails = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new UserDetailsDto() {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = x.ProductsSold
                    .Select(ps => new SoldProductsByUserDto() {
                        Count = x.ProductsSold.Count(),
                        ProductsList = x.ProductsSold
                        .Select(p => new ProductsListDto() {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                    }).ToArray()
                }).ToArray()
            };

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("../../../Dto/Export/users-and-products.json", jsonString);
            Console.WriteLine();
        }
    }
}
