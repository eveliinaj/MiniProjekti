using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Peli
{
    public partial class Form1 : Form
    {
        Lemmikki lemmikki = new Lemmikki();
        Kartta kartta = new Kartta();
        List<Ruoka> löydetyt = new List<Ruoka>();
        

        public Form1()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Enabled = false;

            NäytäLemmikinKuva();

            NäytäInventoryJaHealth();
            
        }

        private void NäytäLemmikinKuva()
        {
            switch (lemmikki.OverAllHealth)
            {
                case 0:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\0.rtf");
                    break;
                case int n when n <= 10:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\1.rtf");
                    break;
                case int n when n <= 20:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\2.rtf");
                    break;
                case int n when n <= 30:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\3.rtf");
                    break;
                case int n when n <= 40:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\4.rtf");
                    break;
                case int n when n <= 50:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\5.rtf");
                    break;
                case int n when n <= 60:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\6.rtf");
                    break;
                case int n when n <= 70:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\7.rtf");
                    break;
                case int n when n <= 80:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\8.rtf");
                    break;
                case int n when n <= 90:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\9.rtf");
                    break;
                case int n when n < 100:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\10.rtf");
                    break;
                case 100:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\11.rtf");
                    break;
                default:
                    break;
            }
        }

        private void NäytäInventoryJaHealth()
        {
            List<string> varasto = new List<string>();
            List<int> varastonmäärä = new List<int>();
            bool löytyi = false;

            label1.Text = default;
            label2.Text = default;

            label1.Text += Environment.NewLine + lemmikki.OverAllHealth;

            foreach (var r in lemmikki.ruoat)
            {
                for (int i = 0; i < varasto.Count; i++)
                {
                    if (varasto[i] == r.ruoanNimi)
                    {
                        varastonmäärä[i]++;
                        löytyi = true;
                    }
                }

                if (löytyi != true)
                {
                    varasto.Add(r.ruoanNimi);
                    varastonmäärä.Add(0);
                    löytyi = false;
                }
            }

            for (int i = 0; i < varasto.Count; i++)
            {
                varasto[i] += " x" + varastonmäärä[i].ToString();
            }

            foreach (var ruoka in varasto)
            {
                label2.Text += Environment.NewLine + ruoka;
            }

            foreach (var harja in lemmikki.harjat)
            {
            label2.Text += Environment.NewLine + harja.harja;
            }
            foreach (var pesu in lemmikki.pesut)
            {
                label2.Text += Environment.NewLine + pesu.Nimi;
            }
            foreach (var leikki in lemmikki.leikit)
            {
                label2.Text += Environment.NewLine + leikki.nimi;
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var input = textBox2.Text;
            var splitattu=input.Split(' ');

            switch (splitattu[0])
            {
                case "harjaa":
                    lemmikki.Harjaa(splitattu[1]);
                    break;
                case "pese":
                    lemmikki.Pese(splitattu[1]);
                    break;
                case "syötä":
                    lemmikki.Syötä(splitattu[1]);
                    break;
                case "leiki":
                    lemmikki.Leiki();
                    break;
                case "paijaa":
                    lemmikki.Paijaa();
                    break;
                case "etsi":
                    löydetyt = kartta.NäytäKartta();
                    foreach (var ruoka in löydetyt)
                    {
                        lemmikki.ruoat.Add(ruoka);
                    }
                    break;

                default:
                    Console.WriteLine("väärä komento");
                    break;
            }

            NäytäLemmikinKuva();
            NäytäInventoryJaHealth();
            
        }

        private void LaskeMieliAlaa()
        {
            if (lemmikki.Mieliala > 0)
            lemmikki.Mieliala = lemmikki.Mieliala - 1;

            if(lemmikki.Hygiene > 0)
            lemmikki.Hygiene = lemmikki.Hygiene - 1;

            if(lemmikki.Hunger > 0)
            lemmikki.Hunger = lemmikki.Hunger - 1;

            lemmikki.OverAllHealth = lemmikki.Mieliala + lemmikki.Hygiene + lemmikki.Hunger;
            NäytäInventoryJaHealth();
            NäytäLemmikinKuva();
        }
        private void Label1_Click_1(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }


        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LaskeMieliAlaa();
            //timer1.Stop();
            //timer1.Start();
        }
    }
}
