using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___My_Banker
{
    internal class CardTypeEnum
    {
        enum cardType : byte
        {
            DebitCard = 0,
            Maestro = 1,
            VisaElectron = 2,
            VisaDankort = 3,
            Mastercard = 4
        }
    }
}
