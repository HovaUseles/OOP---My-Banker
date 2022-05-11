using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    abstract internal class CreditCard
    {
        /// <summary>
        /// Name of the customer registrered to the card
        /// </summary>
        private string cardHolderName;
        public string CardHolderName
        {
            get { return cardHolderName; }
            private set { cardHolderName = value; }
        }

        /// <summary>
        /// ID number of the account the credit card is connected to
        /// </summary>
        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

        /// <summary>
        /// Unique card number.
        /// </summary>
        private string cardNumber;
        public string CardNumber
        {
            get { return cardNumber; }
            private set { cardNumber = value; }
        }

        /// <summary>
        /// Prefix to card number.
        /// </summary>
        private string[] prefixes;
        public string[] Prefixes
        {
            get { return prefixes; }
            protected set { prefixes = value; }
        }

        /// <summary>
        /// Max number of chars in cardnumber
        /// </summary>
        private int cardNumberMax;
        public int CardNumberMax
        {
            get { return cardNumberMax; }
            protected set { cardNumberMax = value; }
        }

        /// <summary>
        /// Base constructor of the superclass.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accNumber"></param>
        public CreditCard(string name, string accNumber)
        {
            CardHolderName = name;
            AccountNumber = accNumber;
        }

        /// <summary>
        /// Base constructor of the superclass with prefixes and max cardnumber characters overloads
        /// </summary>
        /// <param name="name">Fullname of the owner of the card</param>
        /// <param name="accNumber">Account number of the associated card</param>
        /// <param name="cardPrefix">String to add as a prefix for the card number</param>
        /// <param name="maxCardChar">Max char in the card number. Default 16</param>
        public CreditCard(string name, string accNumber, string[] cardPrefix, int maxCardChar = 16)
        {
            CardHolderName = name;
            AccountNumber = accNumber;
            prefixes = cardPrefix;
            cardNumberMax = maxCardChar;
            cardNumber = GenCardNumber();
        }

        /// <summary>
        /// Attemps to withdraw an amount from an account
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="balance"></param>
        /// <returns>If successful returns amount withdrawed.</returns>
        /// <exception cref="Exception"></exception>
        public virtual double Withdraw(double amount, double balance)
        {
            if (amount < balance)
            {
                return amount;
            }
            else
            {
                throw new Exception("");
            }
        }

        
        /// <summary>
        /// Generates a card number based on cardtype prefixes and max number char length.
        /// </summary>
        /// <returns>Returns a string of the generated card number</returns>
        private string GenCardNumber()
        {
            Random random = new Random();
            string cardNumber = string.Empty;
            cardNumber = prefixes[random.Next(0, prefixes.Length)];
            for (int i = cardNumber.Length; i < cardNumberMax; i++)
            {
                cardNumber += random.Next(0, 10).ToString();
            }

            return cardNumber;
        }
    }
}
