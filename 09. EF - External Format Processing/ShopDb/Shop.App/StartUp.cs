namespace Shop.App
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    using System.ComponentModel.DataAnnotations;


    using Shop.Data;
    using Shop.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Shop.App.Dto.Export;
    using Shop.App.Dto.Import;
    using ProductDto = Dto.Export.ProductDto;
    using System.Xml.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            ShopDbContext db = new ShopDbContext();
            db.Database.EnsureCreated();

            var config = new MapperConfiguration(x => {
                x.AddProfile<ShopProfile>();
            });
            IMapper mapper = config.CreateMapper();

            using (db)
            {
                //ImportUsers(db, mapper);
                //ImportProducts(db, mapper);
                //ImportCategories(db, mapper);
                //GetProductsInRange(db, mapper);
                // GetSoldProducts(db, mapper);
                // GetCategoriesByProductCount(db, mapper);
                GetUsersAndProducts(db, mapper);


            }


        }


        public static void GetUsersAndProducts(ShopDbContext db, IMapper mapper)
        {
            var user = new UserExportDto
            {
                Count = db.Users.Count(),
                Users = db.Users.Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new UsersAndProductsDto() {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age.ToString(),
                    SoldProducts = new ProductSoldRootDto() {
                        Count = x.ProductsSold.Count,
                        ProductSoldDtos = x.ProductsSold.Select(s => new ProductsSoldDto() {
                            Name = s.Name,
                            Price = s.Price
                        }).ToArray()
                    }
                }).ToArray()
            };
               
            
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(UserExportDto), new XmlRootAttribute($"users"));
            serializer.Serialize(new StringWriter(sb),user);
            File.WriteAllText("users-and-products.xml", sb.ToString());
            Console.WriteLine();
        }

        public static void GetCategoriesByProductCount(ShopDbContext db, IMapper map)
        {
            var categories = db.Categories.Select(x => new CategoriesByProductDto {
                Name = x.Name,
                TotalRevenue = x.Products.Select(ap => ap.Product.Price).Sum(),
                AveragePrice = x.Products.Select(ap => ap.Product.Price).DefaultIfEmpty(0).Average() ,

            })
                .ToArray();


            StringBuilder sb = new StringBuilder();
            XmlSerializer serialzier = new XmlSerializer(typeof(CategoriesByProductDto[]), new XmlRootAttribute("categories"));
            serialzier.Serialize(new StringWriter(sb),categories);
            File.WriteAllText("categories-by-product.xml",sb.ToString());

        }

        public static void GetSoldProducts(ShopDbContext db, IMapper map)
        {
            var products = db.Users.Where(x => x.ProductsSold.Count > 1)
                                      .Select(x => new SoldProductsDto()
                                      {
                                          FirstName = x.FirstName,
                                          LastName = x.LastName,
                                          SoldProducts = x.ProductsSold
                                          .Select(p => new ProductDto()
                                          {
                                              Name = p.Name,
                                              Price = p.Price,
                                          }).ToArray()

                                      })
                                      .OrderBy(x => x.LastName)
                                      .ThenBy(x => x.FirstName)
                                      .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SoldProductsDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products);
            File.WriteAllText("sold-products.xml", sb.ToString());
            
        }

        public static void GetProductsInRange(ShopDbContext db, IMapper mpper)
        {
            var products = db.Products.Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Buyer != null)
                .Select(x => new ProductsRangeDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName}  {x.Buyer.LastName}" ?? x.Buyer.LastName,
                })
                .OrderBy(x => x.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsRangeDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products);

            File.WriteAllText("products-in-range.xml", sb.ToString());

        }

        public static void ImportCategories(ShopDbContext db, IMapper mapper)
        {
            String xmlString = File.ReadAllText("categories.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            CategoryDto[] deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Category> categories = new List<Category>();
            foreach (CategoryDto categoryDto in deserializedCategories)
            {
                if(!IsValid(categoryDto))
                {
                    continue;
                }

                var category = mapper.Map<Category>(categoryDto);
                categories.Add(category);

            }

            db.Categories.AddRange(categories);
            db.SaveChanges();

            List<CategoryProducts> categoriesProducts = new List<CategoryProducts>();

            for (int productId = 1; productId < 201; productId++)
            {
                var categoryId = new Random().Next(1, 11);

                var categoryProduct = new CategoryProducts() {
                    ProductId = productId,
                    CategoryId = categoryId
                };

                categoriesProducts.Add(categoryProduct);
            }
            Console.WriteLine();
            db.CategorieProducts.AddRange(categoriesProducts);
            db.SaveChanges();

        }

        public static void ImportProducts(ShopDbContext db, IMapper mapper)
        {
            String xmlString = File.ReadAllText("products.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]),new XmlRootAttribute("products"));
            ImportProductDto[] deserializedProducts = (ImportProductDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Product> products = new List<Product>();
            int counter = 1;

            foreach (ImportProductDto productDto in deserializedProducts)
            {

                if (!IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 30);
                var sellerId = new Random().Next(31, 56);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if(counter == 4)
                {
                    product.BuyerId = null;
                    counter = 0;
                }
                counter++;

                products.Add(product);
                
            }
            Console.WriteLine();
            db.Products.AddRange(products);
            db.SaveChanges();
        }

        public static void ImportUsers(ShopDbContext db, IMapper mapper)
        {
            String xmlString = File.ReadAllText("users.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            UserDto[] deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlString));

            List<User> users = new List<User>();
            foreach (UserDto userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            db.Users.AddRange(users);
            db.SaveChanges();
        }

        public static bool IsValid(object obj)
        {

            var validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
         }
    }
}
