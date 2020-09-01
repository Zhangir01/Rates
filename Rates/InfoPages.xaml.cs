using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rates
{
    /// <summary>
    /// Логика взаимодействия для InfoPages.xaml
    /// </summary>
    public partial class InfoPages : Window
    {
        private static string site = "https://nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut/";

        public InfoPages()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(site);
            StreamReader sr = new StreamReader(stream);
            string newLine;
            while ((newLine = sr.ReadLine()) != null)
                xamlCode.Text += newLine;

            stream.Close();
        }
    }
}
