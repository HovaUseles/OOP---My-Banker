using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class ATM
    {
        /// <summary>
        /// The active customer on 
        /// </summary>
        private Customer activeCustomer;

        private BankController myBanker;

        public ATM()
        {
            myBanker = new BankController("3520");
        }

        /// <summary>
        /// Generates 10 random customers and displays them making the user choose q customer to "play" as
        /// </summary>
        public void ChooseCustomer()
        {
            bool looper = true;
            while (looper)
            {

                Console.Clear();
                Customer[] customers = new Customer[10];
                for (int i = 0; i < customers.Length; i++)
                {
                    Customer customer = myBanker.CreateCustomer();
                    Console.Write("{0}. ", i);
                    DisplayCustomer(customer);
                    customers[i] = customer;
                }
                Console.WriteLine();

                int chosenNumber = KeyChoice();
                if (chosenNumber != -1)
                {
                    looper = false;
                    activeCustomer = customers[chosenNumber];
                }

            }

        }

        /// <summary>
        /// Menu with the main actions of the program
        /// </summary>
        public void MainMenu()
        {
            bool looper = true;
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("1. Withdraw money");
                Console.WriteLine("2. Manage accounts");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        ChooseCard();
                        break;
                    case '2':
                        AccountMenu();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays all cards linked to the active customer.
        /// </summary>
        private void ChooseCard()
        {
            bool looper = true;
            while (looper)
            {
                Console.Clear();
                CreditCard[] cardsList = new CreditCard[activeCustomer.Cards.Count];
                for (int i = 0; i < activeCustomer.Cards.Count; i++)
                {
                    Console.WriteLine($"{i}.");
                    CreditCard card = activeCustomer.Cards[i];
                    DisplayCard(card);
                    cardsList[i] = card;
                }
                int chosenNumber = KeyChoice();
                if (chosenNumber != -1 && chosenNumber < activeCustomer.Cards.Count)
                {
                    looper = false;
                    CreditCard cardToWithdraw = cardsList[chosenNumber];
                    WithdrawMenu(cardToWithdraw);

                }
            }
        }

        /// <summary>
        /// Menu to choose how much to withdraw from an Account linked to a Credit Card
        /// </summary>
        /// <param name="card"></param>
        private void WithdrawMenu(CreditCard card)
        {
            bool looper = true;
            while (looper)
            {
                Console.Clear();

                Console.WriteLine("Inserted card:");
                DisplayCard(card);

                Console.WriteLine("\nAccount:");
                Account account = myBanker.GetAccountWithCard(card, activeCustomer);
                if (account != null)
                {
                    DisplayAccount(account);
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }

                Console.WriteLine("\nAmount to withdraw?");
                string amount = Console.ReadLine();
                if (myBanker.IsDigitsOnly(amount) && amount != "")
                {
                    double amountWithdraw = Convert.ToDouble(amount);
                    double withdrawenAmount = myBanker.WithdrawWithCard(card, amountWithdraw, activeCustomer);
                    Console.WriteLine($"\nAmount withdrawen: {withdrawenAmount}");
                    PressToContinue();
                    looper = false;
                }
                else
                {
                    WrongInput();
                }
            }
        }

        /// <summary>
        /// Displays the accounts linked to the customer
        /// </summary>
        private void AccountMenu()
        {
            Console.Clear();
            bool looper = true;
            while (looper)
            {

                for (int i = 0; i < activeCustomer.Accounts.Count; i++)
                {
                    Account acc = activeCustomer.Accounts[i];
                    Console.WriteLine($"\n{i}. ");
                    DisplayAccount(acc);
                }
                PressToContinue();
                looper = false;
            }

        }

        /// <summary>
        /// Display customer to the console
        /// </summary>
        /// <param name="customer"></param>
        private void DisplayCustomer(Customer customer)
        {
            Console.Write("{0}, Age: {1}, Accounts: {2}, Cards: {3}\n",
                customer.GetFullName(),
                customer.Age,
                customer.Accounts.Count,
                customer.Cards.Count
                );
        }

        /// <summary>
        /// Display card to the console
        /// </summary>
        /// <param name="card"></param>
        private void DisplayCard(CreditCard card)
        {
            Console.Write(
                $"  Card type: {myBanker.GetCardType(card)}\n" +
                $"  Card number: {card.CardNumber}\n" +
                $"  Acount number: {card.AccountNumber}\n" +
                $"  Card holder: {card.CardHolderName}\n"
                );
        }

        /// <summary>
        /// Display account to the console
        /// </summary>
        /// <param name="account"></param>
        private void DisplayAccount(Account account)
        {
            Console.Write(
                $"  Owner: {account.GetCustomer.GetFullName()}\n" +
                $"  Account number: {account.AccountNumber}\n" +
                $"  Balance: {account.Balance}\n" +
                $"  Cards: {account.KnownCards.Count}\n");
        }

        /// <summary>
        /// Checks if the input was a digit and returns it if was
        /// </summary>
        /// <returns>A 16-bit signed integer if the input is a number</returns>
        private int KeyChoice()
        {
            ConsoleKeyInfo chosen = Console.ReadKey(true);
            char chosenChar = chosen.KeyChar;
            if (myBanker.IsDigitsOnly(chosenChar))
            {
                string chosenString = string.Empty + chosen.KeyChar;
                int chosenNumber = Convert.ToInt16(chosenString);
                return chosenNumber;
            }
            else
            {
                WrongInput();
                return -1;
            }
        }

        /// <summary>
        /// Informs the console user the input was wrong
        /// </summary>
        private void WrongInput()
        {
            Console.Clear();
            Console.WriteLine("Wrong input.");
            PressToContinue();
        }

        /// <summary>
        /// Prompts the user to press any button to continue.
        /// </summary>
        private void PressToContinue()
        {
            Console.WriteLine("\nPress any button to continue..");
            Console.ReadKey(true);
        }

    }
}
