using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Bank : IBank, IEnumerable
    {
        public string Name { get; }
        public string Address { get; }
        public int CustomerCount { get; }
        private List<Account> accounts;
        private List<Customer> customers;
        private Dictionary<int, Customer> _customerByID;//[customersID]
        private Dictionary<int, Customer> _customerByCustomerNumber;//[customerNumber]
        private Dictionary<int, Account> _accountByAccountNumber;//[accountNumber]
        private Dictionary<Customer, List<Account>> _accountsByCustomer;
        private int totalMoneyInBank;
        private int profits;
        public Bank()
        {
            _customerByID = new Dictionary<int, Customer>();
            _customerByCustomerNumber = new Dictionary<int, Customer>();
            _accountByAccountNumber = new Dictionary<int, Account>();
            _accountsByCustomer = new Dictionary<Customer, List<Account>>();
            accounts = new List<Account>();
            customers = new List<Customer>();
        }

        public Bank(string name, string address, int customerCount)
        {
            Name = name;
            Address = address;
            CustomerCount = customerCount;
        }

        internal Customer GetCustomerByID(int customerId)
        {
            if (!_customerByID.ContainsKey(customerId))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            return _customerByID[customerId];
        }
        internal Customer GetCustomerByNumber(int customerNumber)

        {
            if (!_customerByCustomerNumber.ContainsKey(customerNumber))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            return _customerByCustomerNumber[customerNumber];
        }
        internal Account GetAccountByNumber(int accountNumber)
        {
            if (!_accountByAccountNumber.ContainsKey(accountNumber))
            {
                throw new AccountNotFountExecption("account not found");
            }
            return _accountByAccountNumber[accountNumber];
        }
        internal List<Account> GetAccountByCustomer(Customer customer)
        {
            if (!_accountsByCustomer.ContainsKey(customer))
            {
                throw new AccountNotFountExecption("account not found");
            }
            return _accountsByCustomer[customer];
        }
        internal void AddNewCustomer(Customer customer)
        {
            if (customers.Contains(customer))
            {
                throw new CustomerAlreadyExistExecption("customer already in the system");
            }
            customers.Add(customer);
        }
        internal void OpenNewAcoount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistExecption("account already in the system");
            }
            AddNewCustomer(customer);
            accounts.Add(account);
            _customerByID.Add(customer.CustomerID, customer);
            _customerByCustomerNumber.Add(customer.CustomerNumber, customer);
            _accountByAccountNumber.Add(account.AccountNumber, account);
            _accountsByCustomer.Add(account.AccountOwner, accounts);
        }
        internal int Deposit(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            account.Add(amount);
            totalMoneyInBank += amount;
            return totalMoneyInBank;

        }
        internal int Withdraw(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            if (account.MaxMinusAllowed < amount)
            {
                throw new BalanceException("out of limit");
            }
            account.Substract(amount);
            totalMoneyInBank -= amount;
            return totalMoneyInBank;

        }

        internal int GetCustomerTotalBalance(Customer customer)
        {
            int sum = 0;
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            foreach (Account account in _accountsByCustomer[customer])
            {
                sum += account.Balance;
            }
            return sum;
        }
        internal void CloseAcount(Account account, Customer customer)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFountExecption("account not found");
            }
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("customer not in the system");
            }
            foreach (Account acc in _accountsByCustomer[customer])
            {
                if (acc == account)
                {
                    _accountsByCustomer[customer].Remove(acc);
                }
                accounts.Remove(account);
                _accountByAccountNumber.Remove(account.AccountNumber);
            }
        }
        internal void ChargeAnnualCommission(float percentage)
        {
            float commission = 0;
            foreach (Account account in accounts)
            {
                if (account.Balance > 0)
                {
                    commission = (account.Balance * percentage) / 100;
                }
                else
                {
                    commission = (2 * account.Balance * percentage) / 100;
                }
                int intcomission = Convert.ToInt32(commission);
                profits += intcomission;
                account.Balance -= intcomission;
            }

        }
        public void JoinAccounts(Account account1, Account account2)
        {
            if (!(account1.AccountOwner == account2.AccountOwner))
            {
                throw new NotSameCustomerExecption("the accounts are not join accounts");
            }
            Account account3 = account1 + account2;
            accounts.Remove(account1);
            accounts.Remove(account2);
            _accountByAccountNumber.Remove(account1.AccountNumber);
            _accountByAccountNumber.Remove(account2.AccountNumber);
            accounts.Add(account3);
            _accountByAccountNumber.Add(account3.AccountNumber, account3);
        }

        public IEnumerator GetEnumerator()
        {
            return customers.GetEnumerator();
        }

        public override string ToString()
        {
            string result = $"customers {customers} ";
            foreach (Customer x in customers)
            {
                result =   $"{x}\n";
            }
            return result;
        }
    }
}
