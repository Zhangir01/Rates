using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Money
{
   interface  IRates
   {
        double FindDollar();
        double FindRuble();
        double FindEuro();
   }
}
