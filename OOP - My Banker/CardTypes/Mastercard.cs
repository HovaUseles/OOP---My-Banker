using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class Mastercard : CreditCard
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
        /// Expiry date of the Mastercard card.
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
        private int dayLimit;
        public int DayLimit
        {
            get { return dayLimit; }
            private set { dayLimit = value; }
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
        /// Amount the account balance can go under max
        /// </summary>
        private int overCharge;
        public int OverCharge
        {
            get { return overCharge; }
            private set { overCharge = value; }
        }

        /// <summary>
        /// Inializes an instance of the class.
        /// </summary>
        /// <param name="name">Name of the associated customer</param>
        /// <param name="accNumber">number of the associated account</param>
        public Mastercard(string name, string accNumber) 
            : base(
                  name, 
                  accNumber, 
                  new string[5] { "51", "52", "53", "54", "55" }
                  )
        {
            ageRestrict = 0;
            expiryDate = new DateOnly().AddYears(5);
            dayLimit = 5000;
            monthLimit = 30000;
            overCharge = 40000;
        }

        //protected override string GenCardNumber()
        //{
        //    int cardNumberMax = 16;
        //    string[] prefixes = new string[5] { "51", "52", "53", "54", "55" };
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
