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
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Lemmikki lemmikki = new Lemmikki();

            //string[] taulukko = lemmikki.NäytäEläin();


            //foreach (var rivi in taulukko)
            //{
            //    textBox1.Text += rivi + Environment.NewLine;
            //}

            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Enabled = false;

            richTextBox1.LoadFile(@"..\..\Pelikuvat\2.rtf");

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
            switch (input)
            {
                case "harjaa":
                    Harjaa();
                    break;
                case "pese":
                    Pese();
                    break;
                case "syötä":
                    Syötä();
                    break;
                case "leiki":
                    Leiki();
                    break;
                case "Paijaa":
                    Paijaa();
                    break;
                default:
                    Console.WriteLine("väärä komento");
                    break;
            }
        }
    }
}
