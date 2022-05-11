using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class VisaElectron : CreditCard
    {
        /// <summary>
        /// Minimum age restriction in the use of this card
        /// </summary>
        private int ageRestrict;
        public int AgeRestrict
        {
            get { return ageRestrict; }
            private set { ageRestrict = value; }
        }

        /// <summary>
        /// Expiry date of the VisaElectron card.
        /// </summary>
        private DateOnly expiryDate;
        public DateOnly ExpiryDate
        {
            get { return expiryDate; }
            private set { expiryDate = value; }
        }

        /// <summary>
        /// Max withdrawal amount per month.
        /// </summary>
        private int monthLimit;
        public int MonthLimit
        {
            get { return monthLimit; }
            private set { monthLimit = value; }
        }


        /// <summary>
        /// Inialize an instance of the Maestro class. Sets a expiry date and age restriction.
        /// </summary>
        /// <param name="name">Name of the associated customer</param>
        /// <param name="accNumber">number of the associated account</param>
        public VisaElectron(string name, string accNumber) 
            : base(
                  name, 
                  accNumber,
                  new string[6] { "4026", "417500", "4508", "4844", "4913", "4917" }
                  )
        {
            ageRestrict = 15;
            expiryDate = new DateOnly().AddYears(5);
            monthLimit = 10000;
        }

        public override double Withdraw(double amount, double balance)
        {
            if(balance > amount)
            {
                return amount;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        //protected override string GenCardNumber()
        //{
        //    int cardNumberMax = 16;
        //    string[] prefixes = new string[6] { "4026", "417500", "4508", "4844", "4913", "4917" }; ;
        //    Random random = new Random();
        //    string cardNumber = string.Empty;
        //    cardNumber = prefixes[random.Next(0, prefixes.Length)];
        //    for (int i = 0; i < cardNumberMax; i++)
        //    {
        //        cardNumber += random.Next(0, 10).ToString();
        //    }

        //    return cardNumber;
        //}
    }
}
