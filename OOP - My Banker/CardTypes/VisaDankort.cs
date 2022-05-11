using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class VisaDankort : CreditCard
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
        /// Expiry date of the VisaDankort card.
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
        /// Amount the account balance can go under max
        /// </summary>
        private int overCharge;
        public int OverCharge
        {
            get { return overCharge; }
            private set { overCharge = value; }
        }

        /// <summary>
        /// Inializes an instance of teh class
        /// </summary>
        /// <param name="name">Name of the associated customer</param>
        /// <param name="accNumber">number of the associated account</param>
        public VisaDankort(string name, string accNumber) 
            : base(
                  name, 
                  accNumber, 
                  new string[1] { "4" }
                  )
        {
            ageRestrict = 18;
            expiryDate = new DateOnly().AddYears(5);
            monthLimit = 25000;
            overCharge = 20000;
        }

        //protected override string GenCardNumber()
        //{
        //    int cardNumberMax = 16;
        //    string[] prefixes = new string[1] { "4" };
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
