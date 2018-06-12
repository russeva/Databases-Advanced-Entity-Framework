namespace BookShopSys.App
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using BookShopSys.Data;
    using BookShopSys.Data.Models;
    using BookShopSys.Data.Initializer;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (BookShopSysDbContext db = new BookShopSysDbContext())
            {
                DbInitializer.ResetDatabase(db);

                string command = Console.ReadLine().ToLower();
                var titlesByAgeRestrict = GetBooksByAgeRestriction(db, command); ;
                Console.WriteLine(titlesByAgeRestrict);

                var getGoldenCopies = GetGoldenBooks(db);
                Console.WriteLine(getGoldenCopies);

                var getbookPrice = GetBookPrice(db);
                Console.WriteLine(getbookPrice);

                int yearInput = int.Parse(Console.ReadLine());
                var notReleasedBooks = GetBooksNotReleasedIn(db, yearInput);
                Console.WriteLine(notReleasedBooks);

                var categoryList = Console.ReadLine();
                var result = GetBooksByCategory(db, categoryList);
                Console.WriteLine(result);

                var dateTimeInpout = Console.ReadLine();
                var booksReleasedBefore = GetBooksReleasedBefore(db, dateTimeInpout);
                Console.WriteLine(booksReleasedBefore);

                var authorSearch = Console.ReadLine();
                var authorByLetterEnding = GetAuthorNamesEndingIn(db, authorSearch);
                Console.WriteLine(authorByLetterEnding);

                var controlString = Console.ReadLine().ToLower();
                var outoutTitles = GetBookTitlesContaining(db, controlString);
                Console.WriteLine(outoutTitles);

                var input = Console.ReadLine();
                var authorResult = GetBooksByAuthor(db, input);
                Console.WriteLine(authorResult);

                int lengthCheck = int.Parse(Console.ReadLine());
                var outputBooks = CountBooks(db, lengthCheck);
                Console.WriteLine($"There are {outputBooks} books with title longer than {lengthCheck} symbols");

                var booksPerAuthor = CountCopiesByAuthor(db);
                Console.WriteLine(booksPerAuthor);

                var result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);

                var result = GetMostRecentBooks(db);
                Console.WriteLine(result);

                IncreasePrices(db);

                RemoveBooks(db);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopSysDbContext context, string command)
        {

            var output = context.Books
                .Where(x => x.AgeRestriction.ToString().ToLower() == command)
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, output);
            
        }

        public static string GetGoldenBooks(BookShopSysDbContext context) 
        {
            var goldenCopies = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenCopies);
        }

        public static string GetBookPrice(BookShopSysDbContext context)
        {
            var output = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Title} - ${x.Price:f2}")
                .ToList();


            return string.Join(Environment.NewLine, output);

        }

        public static string GetBooksNotReleasedIn(BookShopSysDbContext context, int year)
        {
            var output = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        public static string GetBooksByCategory(BookShopSysDbContext context, string input)
        {
            var listCategories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var output = context.BookCategories
                .Where(x => x.Category.Name == listCategories[0]
                || x.Category.Name == listCategories[1]
                || x.Category.Name == listCategories[2])
                .OrderBy(x => x.Book.Title)
                .Select(x => x.Book.Title)
                .ToList();
            

            return string.Join(Environment.NewLine,output);
        }

        public static string GetBooksReleasedBefore(BookShopSysDbContext context, string date)
        {
            var controlDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var output = context.Books
                .Where(x => x.ReleaseDate.Value.Month < controlDate.Month && x.ReleaseDate.Value.Date < controlDate.Date)
                .OrderByDescending(x => x.ReleaseDate.Value.Date)
                .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        public static string GetAuthorNamesEndingIn(BookShopSysDbContext context, string input)
        {
            var output = context.Books
                .Where(x => x.Author.FirstName.Substring(x.Author.FirstName.Length - 1, input.Length) == input)
                .OrderBy(x => x.Author.FirstName)
                .Select(x => $"{x.Author.FirstName} {x.Author.LastName}")
                .ToHashSet();

            return string.Join(Environment.NewLine,output);
        }

        public static string GetBookTitlesContaining(BookShopSysDbContext context, string input)
        {
            var output = context.Books
                .Where(x => x.Title.ToLower().Contains(input))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        public static string GetBooksByAuthor(BookShopSysDbContext context, string input)
        {
            var output = context.Books
                .Where(x => x.Author.LastName.ToLower().Substring(0, input.Length) == input.ToLower())
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        public static int CountBooks(BookShopSysDbContext context, int lengthCheck)
        {
            var output = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return output;
        }

        public static string CountCopiesByAuthor(BookShopSysDbContext context)
        {
            var outout = context.Authors
                .Select(x => new
                {
                    Author = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Select(y => y.Copies).Sum()
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            StringBuilder orderedResult = new StringBuilder();

            foreach (var entry in outout)
            {
                var line = $"{entry.Author} - {entry.Copies}{Environment.NewLine}";
                orderedResult.Append(line);
            }
               
            return orderedResult.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopSysDbContext context)
        {
            var output = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                   
                    TotalProfit = x.BookCategories.Sum(y => y.Book.Price * y.Book.Copies)
                })
                .OrderByDescending(y => y.TotalProfit)
                .OrderBy(z => z.CategoryName)
                .ToList();


            StringBuilder result = new StringBuilder();

            foreach (var entry in output)
            {
                var line = $"{entry.CategoryName} ${entry.TotalProfit} {Environment.NewLine}";
                result.Append(line);
            }

            return result.ToString().TrimEnd();

        }

        public static string GetMostRecentBooks(BookShopSysDbContext context)
        {
            var output = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Category = x.Name,

                    BookList = x.BookCategories
                                .Select(z => z.Book)
                                .OrderByDescending(z => z.ReleaseDate)
                                .Take(3)
                })
                .ToList();

            StringBuilder orderedOutput = new StringBuilder();

            foreach (var entry in output)
            {
                orderedOutput.Append($"--{entry.Category}{Environment.NewLine}");

                foreach (var book in entry.BookList)
                {
                   orderedOutput.Append($"{book.Title} ({book.ReleaseDate}){Environment.NewLine}");
                }
            }

            return orderedOutput.ToString();
        }

        public static void IncreasePrices(BookShopSysDbContext db)
        {
            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5m;
            }

            db.SaveChanges();
        }

        public static int RemoveBooks(BookShopSysDbContext db)
        {
            var books = db.Books
                .Where(b => b.Copies < 4200);
            int result = books.Count();

            db.Books.RemoveRange(books);
            db.SaveChanges();

            return result;
        }
    }
}
