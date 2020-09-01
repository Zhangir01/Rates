using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ExchangeRates.HtmlConvert;
namespace ExchangeRates.Money
{
    class Rates: IRates
    {
        private static string site = "https://nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut/";
        private static Dollar dollar;
        private static Ruble ruble;
        private static Euro euro;
        /// <summary>
        /// This class is presented for finding the rate and converting to tenge from the site as seen below
        /// </summary>
        private static List<string>allHtmlCode;
        public Rates() 
        {
            CorrectionHtmlText();
            CreateTextFile();
        }
        private static void CorrectionHtmlText()
        {
            
            allHtmlCode = new List<string>();
            WebRequest request = WebRequest.Create(site);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("\t"))
                        {
                            line = line.Replace("\t", "");
                        }
                        line = line.Replace(" ", "");
                        allHtmlCode.Add(line);
                    }
                }
            }
            response.Close();
        }
        public static void CreateTextFile() 
        {
            using (StreamWriter sw = new StreamWriter("htmlCodeRates.txt", false, Encoding.UTF8))
            {
                foreach (var item in allHtmlCode) 
                {
                    sw.WriteLine(item);
                }
            }
        }
        private double FindMoney(object currancy, string htmlElement) 
        {
            double priceKz = 0;
            int element = allHtmlCode.IndexOf(htmlElement);

            string price = Html.HtmlToText(allHtmlCode[element + 1]);
            price = price.Replace(".", ",");
            if (currancy is Dollar)
            {
               
                priceKz = Convert.ToDouble(price);
                return priceKz;
            }
            else if (currancy is Euro)
            {
               
                priceKz = Convert.ToDouble(price);
                return priceKz;
            }
            else if (currancy is Ruble) 
            {
                priceKz = Convert.ToDouble(price);
                return priceKz;
            }
            return 0;
        }
        public double FindDollar()
        {
            dollar = new Dollar();
            dollar.Price =  FindMoney(dollar, "<td>USD/KZT</td>");
            return dollar.Price;
        }
        public double FindEuro()
        {
            euro = new Euro();
            euro.Price =  FindMoney(euro, "<td>EUR/KZT</td>");
            return euro.Price;
        }

        public double FindRuble()
        {
            ruble = new Ruble();
            ruble.Price = FindMoney(ruble, "<td>RUB/KZT</td>");
            return ruble.Price;
        }
        public void ShowResult() 
        {
            Console.WriteLine("========================================");
            Console.Write("+[Курс доллара к тенге :]:"); Console.WriteLine(dollar.Price.ToString());
            Console.Write("+[Курс рубля к тенге :]:"); Console.WriteLine(ruble.Price.ToString());
            Console.Write("+[Курс евро к тенге :]:"); Console.WriteLine(euro.Price.ToString());
            Console.WriteLine("========================================");
        }
    }
}
