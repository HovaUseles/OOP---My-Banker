using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class Customer
    {
        /// <summary>
        /// First name of the customer
        /// </summary>
        private string fName;
        public string FName
        {
            get { return fName; }
            private set { fName = value; }
        }

        /// <summary>
        /// Lastname of the customer
        /// </summary>
        private string lName;
        public string LName
        {
            get { return lName; }
            private set { lName = value; }
        }

        /// <summary>
        /// Age of the customer
        /// </summary>
        private int age;
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        /// <summary>
        /// Accounts associtated with the customer
        /// </summary>
        private List<Account> accounts;
        public List<Account> Accounts
        {
            get { return accounts; }
            private set { accounts = value; }
        }

        /// <summary>
        /// The customers credit cards
        /// </summary>
        private List<CreditCard> cards;
        public List<CreditCard> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }

        /// <summary>
        /// Inializes an instance of the customer class with a random age
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Customer(string firstName, string lastName)
        {
            Random random = new Random();
            age = random.Next(13, 71);
            fName = firstName;
            lName = lastName;
            accounts = new List<Account>();
            cards = new List<CreditCard>();
        }

        public string GetFullName()
        {
            return fName + " " + lName;
        }

        /// <summary>
        /// Connects a credit card instance to the customer
        /// </summary>
        /// <param name="card">Card to be given</param>
        public void ReceiveCreditCard(CreditCard card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Connects an account instance to the customer
        /// </summary>
        /// <param name="account">Account to be given</param>
        public void LinkAccount(Account account)
        {
            accounts.Add(account);
        }

    }
}
