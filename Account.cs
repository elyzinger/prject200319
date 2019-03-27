using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Account
    {
        private static int numberOfAcount = 0;
        public readonly int accountNumber;
        public readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber
        {
            get;
        }
        public int Balance { get; set; }
        public Customer AccountOwner
        {
            get { return this.accountOwner; }
        }
        public int MaxMinusAllowed
        {
            get;

        }
        public int MonthlyIncome { get; set; }
        public Account()
        {

        }
        public Account(Customer customer, int monthlyincome)
        {
            this.accountOwner = customer;
            this.MonthlyIncome = monthlyincome;
            this.maxMinusAllowed = monthlyincome * 3;
            numberOfAcount++;
            accountNumber++;
        }
        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Substract(int amount)
        {
            Balance -= amount;
        }
        public static bool operator ==(Account a, Account b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                throw new NullReferenceException("account cant be null");
            }

            if (a.accountNumber == b.accountNumber)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Account a, Account b)
        {
            return !(a.accountNumber == b.accountNumber);
        }
        public static Account operator +(Account a, Account b)
        {
            Account c = new Account(new Customer(a.AccountOwner.CustomerID, a.AccountOwner.Name, a.AccountOwner.PhNumber), a.MonthlyIncome + b.MonthlyIncome);
            c.Add(a.Balance + b.Balance);
            return c;
        }
        public override bool Equals(object obj)
        {
            Account account = obj as Account;
            return this.accountNumber == account.accountNumber;
        }

        public override int GetHashCode()
        {
            return this.accountNumber;
        }
        public static Account operator +(Account account, int amount)
        {
            account.Balance += amount;
            return account;
        }
        public static Account operator -(Account account, int amount)
        {
            account.Balance -= amount;
            return account;
        }

        public override string ToString()
        {
            return $"number of acccounts: {numberOfAcount}inside info: accountNumber: { accountNumber} accountOwner: {AccountOwner} maxMinusAllowed: {maxMinusAllowed} Balance: {Balance} MonthlyIncome: {MonthlyIncome}";

        }
    }
}
