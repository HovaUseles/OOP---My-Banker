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

        private void DisplayCustomer(Customer customer)
        {
            Console.Write("{0}, Age: {1}, Accounts: {2}, Cards: {3}\n",
                customer.GetFullName(),
                customer.Age,
                customer.Accounts.Count,
                customer.Cards.Count
                );
        }

        private void DisplayCard(CreditCard card)
        {
            Console.Write(
                $"  Card type: {myBanker.GetCardType(card)}\n" +
                $"  Card number: {card.CardNumber}\n" +
                $"  Acount number: {card.AccountNumber}\n" +
                $"  Card holder: {card.CardHolderName}\n"
                );
        }

        private void DisplayAccount(Account account)
        {
            Console.Write(
                $"  Owner: {account.GetCustomer.GetFullName()}\n" +
                $"  Account number: {account.AccountNumber}\n" +
                $"  Balance: {account.Balance}\n" +
                $"  Cards: {account.KnownCards.Count}\n");
        }

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

        private void WrongInput()
        {
            Console.Clear();
            Console.WriteLine("Wrong input.");
            PressToContinue();
        }

        private void PressToContinue()
        {
            Console.WriteLine("\nPress any button to continue..");
            Console.ReadKey(true);
        }

    }
}
