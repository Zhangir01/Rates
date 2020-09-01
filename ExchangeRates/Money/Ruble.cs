using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Money
{
    class Ruble:IMoney
    {
       public double Price { get; set; }
        public Ruble() 
        {
        }
       public void SetRuble(double price) 
       {
             Price = price;
       }

    }
}
