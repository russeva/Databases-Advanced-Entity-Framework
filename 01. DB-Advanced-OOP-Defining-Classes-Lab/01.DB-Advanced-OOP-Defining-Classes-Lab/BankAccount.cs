using System;
using System.Collections.Generic;
using System.Text;

class BankAccount
{
    public int ID { get; set; }
    public decimal Balance { get; set; }

    public BankAccount()
    { }

    public BankAccount(int id, decimal balance)
    {
        this.ID = id;
        this.Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }
}

