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

        public Form1()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Enabled = false;

            richTextBox1.LoadFile(@"..\..\Pelikuvat\2.rtf");

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
                default:
                    Console.WriteLine("väärä komento");
                    break;
            }
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

    }
}
