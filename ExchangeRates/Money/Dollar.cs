using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Money
{
    class Dollar:IMoney
    {
        public double Price { get; set; }
        public Dollar()
        {
        
        }
        public void SetDollar(double price) 
        {
             Price = price;
        }
    }
}
