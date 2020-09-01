using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeRates.Money;

namespace ExchangeRates
{
    class Program
    {      
        public static void Timer()
        {
            int count = 0;
            while (1 == 1) 
            {
                if (count == 4)
                    break;
                count++;
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("==   ==  ==  ==  ==  ==  ==  ==  ==  ==  == ");
            Console.WriteLine("Курс валют национального банка Казахстана ");
            Console.WriteLine("\t\t\t"+DateTime.Now.ToString());
            Console.WriteLine("USD   -   EUR   -   RUB");
            Rates rates = new Rates();
            double dollar = rates.FindDollar();
            double euro = rates.FindEuro();
            double ruble = rates.FindRuble();
            Console.WriteLine();
            Console.WriteLine(dollar.ToString() + "   " + euro.ToString() + "    " + ruble.ToString()) ;
            Console.ReadLine();
        }
    }
}
