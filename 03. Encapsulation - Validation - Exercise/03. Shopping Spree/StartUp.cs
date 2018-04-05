using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shopping_Spree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> allPeople = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> allProducts = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<Person> people = new List<Person>();
            List<Product> productsDB = new List<Product>();

            for (int i = 0; i < allPeople.Count; i+=2)
            {
                string name = allPeople[i];
                double money = double.Parse(allPeople[i + 1]);

                Person currentPerson = new Person(name, money);
                people.Add(currentPerson);
            }

            for (int i = 0; i < allProducts.Count; i += 2)
            {
                string name = allProducts[i];
                double price = double.Parse(allProducts[i + 1]);

                Product currentProduct = new Product(name, price);
                productsDB.Add(currentProduct);
            }

            string input;

            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();
                string currentName = inputArgs[0];
                string currentProduct = inputArgs[1];

                Person currentPerson = people.Find(x => x.Name == currentName);
                Product product = productsDB.Find(x => x.Name == currentProduct);

                currentPerson.BuyProduct(product);
              
            }

            foreach (var person in people)
            {
                Console.Write($"{person.Name} - {String.Join(", ", person.Bag.Select(x => x.Name))}");
                Console.WriteLine();

                
            }


        }
    }
}
