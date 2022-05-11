using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class Account
    {
        private Random random = new Random();

        /// <summary>
        /// Number associated with account
        /// </summary>
        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

        /// <summary>
        /// Money currently in account
        /// </summary>
        private double balance;
        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        /// <summary>
        /// Owner of the account.
        /// </summary>
        private Customer customer;
        public Customer GetCustomer
        {
            get { return customer; }
            private set { customer = value; }
        }

        /// <summary>
        /// Credit cards linked to the account
        /// </summary>
        private List<string> knownCards;
        public List<string> KnownCards
        {
            get { return knownCards; }
            private set { knownCards = value; }
        }

        /// <summary>
        /// Inialized an instance of the account class with a random acountNumber and random account balance.
        /// </summary>
        /// <param name="regNumber">Registration number from the bank.</param>
        public Account(string regNumber, Customer owner)
        {
            balance = GenAccountBalance();

            accountNumber = regNumber + GenAccountNumber();

            customer = owner;

            knownCards = new List<string>();
        }

        /// <summary>
        /// Generates a random account balance
        /// </summary>
        /// <returns>A double</returns>
        private double GenAccountBalance()
        {
            int rngBalance = random.Next(1000, 200000);
            return Convert.ToDouble(rngBalance);

        }

        /// <summary>
        /// Generates 10 random numbers uses for account number.
        /// </summary>
        /// <returns></returns>
        private string GenAccountNumber()
        {
            string rngString = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                rngString += random.Next(0, 10).ToString();
            }
            return rngString;
        }

        /// <summary>
        /// Links a card number to known account cards
        /// </summary>
        /// <param name="cardNumber"></param>
        public void LinkCard(string cardNumber)
        {
            knownCards.Add(cardNumber);
        }

        /// <summary>
        /// Substract an amount from the account balance
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount)
        {
            balance -= amount;
        }

    }
}
