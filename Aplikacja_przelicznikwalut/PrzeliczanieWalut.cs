using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Aplikacja_przelicznikwalut
{
    public class PrzeliczanieWalut
    {
        protected List<string> files = new List<string>();

        private WebClient pobierzP = new WebClient();

        private StreamReader r = new StreamReader("dir.txt");

        private string linia = "";
        private double waluta;

        public PrzeliczanieWalut()
        {
            while (linia != null)
            {
                linia = r.ReadLine();

                if (linia != null)
                {
                    if (linia.StartsWith("a"))
                    {
                        files.Add(linia);
                    }
                }
            }

            r.Close();
            pobierzP.DownloadFile("http://www.nbp.pl/Kursy/xml/dir.txt", "dir.txt");
            dokument = new XPathDocument("http://www.nbp.pl/kursy/xml/" + files[files.Count - 1] + ".xml");
            nawigator = dokument.CreateNavigator();
            iterator = nawigator.Select("tabela_kursow");
            Data = iterator;
            iterator = nawigator.Select("tabela_kursow/pozycja");
        }

        private XPathDocument dokument;
        private XPathNavigator nawigator;
        private XPathNodeIterator iterator;
        public XPathNodeIterator Data { get; private set; }

        public double pobierzDolar()
        {
            foreach (XPathNavigator dolar in iterator)
            {
                if (dolar.SelectSingleNode("kod_waluty").Value == "USD")
                {
                    waluta = Convert.ToDouble(dolar.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }

        public double pobierzEuro()
        {
            foreach (XPathNavigator euro in iterator)
            {
                if (euro.SelectSingleNode("kod_waluty").Value == "EUR")
                {
                    waluta = Convert.ToDouble(euro.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }

        public double pobierzFunt()
        {
            foreach (XPathNavigator funt in iterator)
            {
                if (funt.SelectSingleNode("kod_waluty").Value == "GBP")
                {
                    waluta = Convert.ToDouble(funt.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }

        public double pobierzFrank()
        {
            foreach (XPathNavigator frank in iterator)
            {
                if (frank.SelectSingleNode("kod_waluty").Value == "CHF")
                {
                    waluta = Convert.ToDouble(frank.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }

        public double pobierzRubel()
        {
            foreach (XPathNavigator rubel in iterator)
            {
                if (rubel.SelectSingleNode("kod_waluty").Value == "RUB")
                {
                    waluta = Convert.ToDouble(rubel.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }

        public double pobierzHrywne()
        {
            foreach (XPathNavigator hrywna in iterator)
            {
                if (hrywna.SelectSingleNode("kod_waluty").Value == "UAH")
                {
                    waluta = Convert.ToDouble(hrywna.SelectSingleNode("kurs_sredni").Value);
                    return waluta;
                }
            }
            return 0;
        }
    }
}