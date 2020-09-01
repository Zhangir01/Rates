using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Money
{
    class Euro : IMoney
    {
        public double Price { get ; set ; }
        public Euro()
        {
          
        }
        public void SetPrice(double price) 
        {
             Price = price;
        }
    }
}
