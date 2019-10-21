using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            string[] taulukko = lemmikki.NäytäEläin();

            //string unicodeString = char.ConvertFromUtf32(0x1F967);

            //textBox1.Text = unicodeString;

            foreach (var rivi in taulukko)
            {
                textBox1.Text += rivi + Environment.NewLine;
            }

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
