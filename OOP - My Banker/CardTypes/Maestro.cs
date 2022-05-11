using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class Maestro : CreditCard
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
        /// Expiry date of the Maestro card.
        /// </summary>
        private DateOnly expiryDate;
        public DateOnly ExpiryDate
        {
            get { return expiryDate; }
            private set { expiryDate = value; }
        }

        /// <summary>
        /// Inialize an instance of the Maestro class. Sets a expiry date and age restriction.
        /// </summary>
        /// <param name="name">Name of the associated customer</param>
        /// <param name="accNumber">number of the associated account</param>
        public Maestro(string name, string accNumber) 
            : base(
                  name, 
                  accNumber, 
                  new string[9] { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" }, 
                  19
                  )
        {
            ageRestrict = 18;
            expiryDate = new DateOnly().AddYears(5).AddMonths(8);
        }

        //protected override string GenCardNumber()
        //{
        //    int cardNumberMax = 19;
        //    string[] prefixes = new string[9] { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
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
