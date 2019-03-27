using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Customer
    {
        static int numberOfCust = 0;
        public readonly int customerId;
        public readonly int customerNumber;
        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerID
        {
            get { return this.customerId; }
        }
        public int CustomerNumber
        {
            get { return this.customerNumber; }
        }

        public Customer(int id, string name, int phNumber)
        {
            this.customerNumber = numberOfCust;
            this.customerId = id;
            Name = name;
            PhNumber = phNumber;
            numberOfCust++;

        }
        public static bool operator ==(Customer a, Customer b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                throw new NullReferenceException("customer cant be null");
            }

            if (a.CustomerNumber == b.CustomerNumber)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Customer a, Customer b)
        {
            return !(a.CustomerNumber == b.CustomerNumber);
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            return this.CustomerNumber == customer.CustomerNumber;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"customer details: {Name}  {CustomerID}  {PhNumber} {CustomerNumber}";
        }
    }
}
