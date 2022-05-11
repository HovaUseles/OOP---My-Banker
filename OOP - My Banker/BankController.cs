using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class BankController
    {
        /// <summary>
        /// Registration number unique to the bank.
        /// </summary>
        private string regNumber;
        public string RegNumber
        {
            get { return regNumber; }
            private set { regNumber = value; }
        }

        private FileHandler fileHandler;
        private CardTypeEnum cardType;
        /// <summary>
        /// Inializes an instance of the controller.
        /// </summary>
        /// <param name="regNr">Registration number for the bank.</param>
        public BankController(string regNr)
        {
            RegNumber = regNr;
            fileHandler = new FileHandler("G:\\Mit drev\\Skole\\ZBC - Data og Kommunikation\\Hovedforløb 2\\repos\\OOP - My Banker\\OOP - My Banker\\NameFiles\\");
            cardType = new CardTypeEnum();
        }

        /// <summary>
        /// Create an new instance of the customer class with random name and age and returns it.
        /// </summary>
        /// <returns>An instance of the customer class</returns>
        public Customer CreateCustomer()
        {
            string fName = fileHandler.GetRandomFirstName();
            string lName = fileHandler.GetRandomLastName();
            Customer customer = new Customer(fName, lName);
            GenCustomerAccounts(customer);
            GenCustomerCards(customer);
            return customer;
        }

        /// <summary>
        /// Create an new instance of the customer class with set first and last name and returns it.
        /// </summary>
        /// <param name="fName">Assign a first name to the customer</param>
        /// <param name="lName">Assign a last name to the customer</param>
        /// <returns>An instance of the customer class</returns>
        public Customer CreateCustomer(string fName, string lName)
        {
            Customer customer = new Customer(fName, lName);
            return customer;
        }

        /// <summary>
        /// Creates an instance of the account class with a random account number and balance
        /// </summary>
        /// <param name="customer">Owner of the account</param>
        /// <returns>An instance of the account class</returns>
        public Account CreateAccount(Customer customer)
        {
            Account account = new Account(RegNumber, customer);
            return account;
        }

        /// <summary>
        /// Creates an instance of one of the credit card sub-classes. 
        /// </summary>
        /// <param name="cardType">Chooses which credit card type to create</param>
        /// <param name="customerName">Name of the owner of the card.</param>
        /// <param name="accNumber">Account number of the associated account</param>
        /// <returns>An intance of the chosen CreditCard sub-class</returns>
        public CreditCard CreateCard(int cardType, string customerName, string accNumber)
        {
            CreditCard creditCard;
            switch (cardType)
            {
                case 0:
                    creditCard = new DebitCard(customerName, accNumber);
                    break;
                case 1:
                    creditCard = new Maestro(customerName, accNumber);
                    break;
                case 2:
                    creditCard = new VisaElectron(customerName, accNumber);
                    break;
                case 3:
                    creditCard = new VisaDankort(customerName, accNumber);
                    break;
                case 4:
                    creditCard = new Mastercard(customerName, accNumber);
                    break;
                default:
                    return null;
            }
            return creditCard;
        }

        /// <summary>
        /// Links a card to an account.
        /// </summary>
        /// <param name="card">Card to link</param>
        /// <param name="account">Account to link to</param>
        public void LinkCardToAccount(CreditCard card, Account account)
        {
            account.LinkCard(card.CardNumber);
        }

        /// <summary>
        /// Generates 1-2 to accounts on a customer
        /// </summary>
        /// <param name="customer">The customer instance to connect the accounts to</param>
        public void GenCustomerAccounts(Customer customer)
        {
            int accountsToAdd = 0;

            Random random = new Random();
            int chance = random.Next(0, 100);
            if (chance > 49)
            {
                accountsToAdd = 2;
            }
            else
            {
                accountsToAdd = 1;
            }

            for (int i = 0; i < accountsToAdd; i++)
            {
                Account account = CreateAccount(customer);
                customer.LinkAccount(account);
            }
        }

        /// <summary>
        /// Generates 1-2 cards per accounts
        /// </summary>
        /// <param name="customer">The customer instance to connect the creditCards to</param>
        public void GenCustomerCards(Customer customer)
        {
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                int cardsToAdd = 0;

                Random random = new Random();
                int chance = random.Next(0, 100);
                if (chance > 49)
                {
                    cardsToAdd = 2;
                }
                else
                {
                    cardsToAdd = 1;
                }

                for (int j = 0; j < cardsToAdd; j++)
                {
                    int cardType = random.Next(0, 4);
                    CreditCard card = CreateCard(cardType, customer.GetFullName(), customer.Accounts[i].AccountNumber);
                    customer.Accounts[i].LinkCard(card.CardNumber);
                    customer.ReceiveCreditCard(card);
                }
            }
        }

        public double WithdrawWithCard(CreditCard card, double amount, Customer customer)
        {
            Account accToWithdraw = GetAccountWithCard(card, customer); ;
            if (accToWithdraw != null)
            {
                double withdrawen = card.Withdraw(amount, accToWithdraw.Balance);
                accToWithdraw.Withdraw(amount);
                return withdrawen;
            }
            else
            {
                throw (new Exception());
            }
        }

        /// <summary>
        /// Checks if an account is linked to the card and customer
        /// </summary>
        /// <param name="card"></param>
        /// <param name="customer"></param>
        /// <returns>The associated account</returns>
        public Account GetAccountWithCard(CreditCard card, Customer customer)
        {
            foreach (Account acc in customer.Accounts)
            {
                if (card.AccountNumber == acc.AccountNumber)
                {
                    foreach (string cardNr in acc.KnownCards)
                    {
                        if(cardNr == card.CardNumber)
                        {
                            return acc;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a string only contains digit chars
        /// </summary>
        /// <param name="str">String to test</param>
        /// <returns>True if only digits</returns>
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a char is a digit
        /// </summary>
        /// <param name="c">Char to test</param>
        /// <returns>True if the char is a digit</returns>
        public bool IsDigitsOnly(char c)
        {
            if (c < '0' || c > '9')
                return false;

            return true;
        }

        public string GetCardType(CreditCard card)
        {
            if (card is DebitCard) { return "DebitCard"; }
            else if (card is Maestro) { return "Maestro"; }
            else if (card is VisaElectron) { return "Visa Electron"; }
            else if (card is VisaDankort) { return "Visa Dankort"; }
            else if (card is Mastercard) { return "Mastercard"; }
            else { return "Unknown";  }
        }
    }
}
