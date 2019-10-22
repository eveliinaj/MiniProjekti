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
                case int n when n <= 10:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\1.rtf");
                    break;
                case int n when n <= 30:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\2.rtf");
                    break;
                case int n when n <= 50:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\3.rtf");
                    break;
                case int n when n <= 80:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\4.rtf");
                    break;
                case int n when n <= 100:
                    richTextBox1.LoadFile(@"..\..\Pelikuvat\5.rtf");
                    break;

                default:
                    break;
            }
        }

        private void NäytäInventoryJaHealth()
        {
            label1.Text = default;
            label2.Text = default;

            label1.Text += Environment.NewLine + lemmikki.OverAllHealth;

            foreach (var ruoka in lemmikki.ruoat)
            {
                label2.Text += Environment.NewLine + ruoka.ruoanNimi;
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
<<<<<<< HEAD

=======
        
>>>>>>> c403d34f4fb568529db4f30c507005d14d4c0242
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Tässä
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
            switch (input)
            {
                case "harjaa":
                    lemmikki.Harjaa();
                    break;
                case "pese":
                    lemmikki.Pese();
                    break;
                case "syötä":
                    lemmikki.Syötä();
                    break;
                case "leiki":
                    lemmikki.Leiki();
                    break;
                case "Paijaa":
                    lemmikki.Paijaa();
                    break;
                case "Etsi":
                    kartta.NäytäKartta();
                    break;

                default:
                    Console.WriteLine("väärä komento");
                    break;
            }

            NäytäLemmikinKuva();
            NäytäInventoryJaHealth();
            
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
            lemmikki.Mieliala -= 1;
            lemmikki.Hygiene -= 1;
            lemmikki.Hunger -= 1;
            lemmikki.LaskeOverall();
            NäytäInventoryJaHealth();
            NäytäLemmikinKuva();
        }
    }
}
