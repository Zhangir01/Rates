using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ExchangeRates.HtmlConvert
{
   static class  Html
   {
        public static string HtmlToText(string htmlText) 
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
            var textString = doc.DocumentNode.InnerText;
            string code = Regex.Replace(textString, @"<(.|n)*?>", string.Empty).Replace("&nbsp", "");
            return code;
        }
   }
}
