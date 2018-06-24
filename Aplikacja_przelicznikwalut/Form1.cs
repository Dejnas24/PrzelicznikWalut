using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Aplikacja_przelicznikwalut
{
    public partial class Form1 : Form
    {
        private PrzeliczanieWalut waluty = new PrzeliczanieWalut();

        public Form1()
        {
            InitializeComponent();
        }

        private void Przeliczanie()
        {
            DataKursu();

            double kurs;
            string name;
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Nie wprowadzono wartości liczbowej...");
                }
                else
                {
                    name = textBox1.Text;
                }

                double kursliczba = Double.Parse(textBox1.Text);

                //dolar na PLN
                if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 0)
                {
                    kurs = kursliczba * waluty.pobierzDolar();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                //PLN na dolar
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 0)
                {
                    kurs = kursliczba / waluty.pobierzDolar();
                    waluta.Text = kurs.ToString() + " $";
                }
                //euro na PLN
                else if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 1)
                {
                    kurs = kursliczba * waluty.pobierzEuro();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                // PLN na euro
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 1)
                {
                    kurs = kursliczba / waluty.pobierzEuro();
                    waluta.Text = kurs.ToString() + " \u20AC";
                }
                //funt na PLN
                else if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 5)
                {
                    kurs = kursliczba * waluty.pobierzFunt();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                //PLN na funt
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 5)
                {
                    kurs = kursliczba / waluty.pobierzFunt();
                    waluta.Text = kurs.ToString() + " GBP";
                }
                //frank na PLN
                else if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 3)
                {
                    kurs = kursliczba * waluty.pobierzFrank();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                //PLN na frank
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 3)
                {
                    kurs = kursliczba / waluty.pobierzFrank();
                    waluta.Text = kurs.ToString() + " CHF";
                }

                //rubel na PLN
                else if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 4)
                {
                    kurs = kursliczba * waluty.pobierzRubel();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                //PLN na rubel
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 4)
                {
                    kurs = kursliczba / waluty.pobierzRubel();
                    waluta.Text = kurs.ToString() + " RUB";
                }
                //hrywna na PLN
                else if (radioButtonNaPLN.Checked && comboBox2.SelectedIndex == 2)
                {
                    kurs = kursliczba * waluty.pobierzHrywne();
                    waluta.Text = kurs.ToString() + " PLN";
                }
                //PLN na hrywna
                else if (radioButtonPLNna.Checked && comboBox2.SelectedIndex == 2)
                {
                    kurs = kursliczba / waluty.pobierzHrywne();
                    waluta.Text = kurs.ToString() + " UAH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieprawidłowa liczba!!!");
            }
        }

        private void DataKursu()
        {
            try
            {
                foreach (XPathNavigator data in waluty.Data)
                {
                    datalabel.Text = data.SelectSingleNode("data_publikacji").Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd daty...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Przeliczanie();
        }

        private void aktualizujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Przeliczanie();
        }

        private void zamknijOknoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.Text = "";
            datalabel.Text = "";
            waluta.Text = "";
        }

        private void wyczyśćWszyskoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.Text = "";
            datalabel.Text = "";
            waluta.Text = "";
        }

        private void oMnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OProgramie p = new OProgramie();
            p.Show();
        }
    }
}