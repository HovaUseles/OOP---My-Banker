using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class DebitCard : CreditCard
    {

        /// <summary>
        /// Inializes an instance of the DebitCard class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accNumber"></param>
        public DebitCard(string name, string accNumber) 
            : base(
                  name, 
                  accNumber, 
                  new string[1] { "2400" }
                  )
        {

        }

        //protected override string GenCardNumber()
        //{
        //    int cardNumberMax = 16;
        //    string[] prefixes = new string[1] { "2400" };
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
