using System;
using System.Collections.Generic;

namespace _01.DB_Advanced_OOP_Defining_Classes_Lab
{
    class StartUp
    {
        public static int amount;

        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;
            acc.Deposit(15);
            acc.Withdraw(5);

            Console.WriteLine($"Account: {acc.ID}, Balance: {acc.Balance}");

            var accounts = new Dictionary<int, BankAccount>();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                string action = input[0];
                int id = int.Parse(input[1]);

                switch (action)
                {
                    case "Create":
                        Create(id, accounts);    
                        break;
                    case "Deposit":
                        amount = int.Parse(input[2]);
                        Deposit(id, amount, accounts);
                        break;
                    case "Withdraw":
                        amount = int.Parse(input[2]);
                        Withdraw(id, amount, accounts);
                        break;
                    case "Print":
                        Print(id,accounts);
                        break;
                }

            }

            

        }

        private static void Print(int id, Dictionary<int, BankAccount> accounts)
        {
            var balance = accounts[id].Balance;
            Console.WriteLine($"Account ID {id}, balance = {balance}");
        }

        private static void Withdraw(int id, int amount, Dictionary<int, BankAccount> accounts)
        {

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist!");
            }
            else if(amount > accounts[id].Balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                accounts[id].Balance -= amount;
            }
        }

        private static void Deposit(int id, int amount, Dictionary<int, BankAccount> accounts)
        {
            if(!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist!");
            }
            else
            {
                accounts[id].Balance += amount;
            }
        }

        private static void Create(int id, Dictionary<int, BankAccount> accounts)
        {
            if(accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exist!");
            }
            else
            {
                accounts[id] = new BankAccount();
            }
        }
    }
}
