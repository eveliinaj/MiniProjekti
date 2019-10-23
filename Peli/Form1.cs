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
using System.Runtime.InteropServices;

namespace Peli
{
    
    public partial class Form1 : Form
    {
        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        const int offsetX = 100;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);


        const int offsetY = 100;

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        bool isVisible = true;
        IntPtr hWnd;


        Lemmikki lemmikki = new Lemmikki();

        Lemmikki uusilemmikki = new Lemmikki();
        Kartta kartta = new Kartta();
        
        List<Ruoka> löydetyt = new List<Ruoka>();

        bool vastaantulija = false;
        int vastaantulijanruoka = default;
        public List<Ruoka> randomruoat = new List<Ruoka>();
        Ruoka myrkkysieni = new Ruoka("myrkkysieni", -5);
        Ruoka karkki = new Ruoka("karkki", 10);

        public Form1()
        {
            InitializeComponent();
            hWnd = GetConsoleWindow();
            randomruoat.Add(myrkkysieni);
            randomruoat.Add(karkki);
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Enabled = false;

            NäytäLemmikinKuva();
            NäytäInventoryJaHealth();
        }

        //public Lemmikki LuoLemmikki()
        //{
        //Lemmikki lemmikki = new Lemmikki();
        //    return lemmikki;
        //}

        public void NäytäLemmikinKuva()
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
                    varastonmäärä.Add(1);
                }
                löytyi = false;
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
            textBox1.Text = default;
            if (lemmikki.OverAllHealth<100&& lemmikki.OverAllHealth > 70)
            {
                textBox1.Text += Environment.NewLine + "Lemmikkisi näyttää voivan hyvin. Hyvää työtä!";
            }
            else if (lemmikki.OverAllHealth>0 && lemmikki.OverAllHealth< 10)
            {
                textBox1.Text += Environment.NewLine + "Lemmikkisi on hädänalainen. TEE JOTAIN!!!";
            }
            else if(lemmikki.OverAllHealth == 0)
            {
                textBox1.Text += Environment.NewLine + "Lemmikki kuoli.";
                textBox1.Text += Environment.NewLine + "Haluatko aloittaa uuden pelin? Vastaa Kyllä/Ei.";
               
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
            Button2Klikattu(input);
        }

        public void Button2Klikattu(string input)
        {
            var splitattu = input.Split(' ');

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
                    SetWindowPos(hWnd, IntPtr.Zero.ToInt32(), 100, 100, 0, 0, SWP_NOZORDER | SWP_NOSIZE | (isVisible ? SW_SHOW : SW_HIDE));
                    ShowWindow(hWnd, isVisible ? SW_SHOW : SW_HIDE);
                    isVisible = !isVisible;
                    löydetyt = kartta.NäytäKartta();
                    SetWindowPos(hWnd, IntPtr.Zero.ToInt32(), 100, 100, 0, 0, SWP_NOZORDER | SWP_NOSIZE | (isVisible ? SW_HIDE : SW_SHOW));
                    ShowWindow(hWnd, isVisible ? SW_SHOW : SW_HIDE);
                    isVisible = !isVisible;
                    foreach (var ruoka in löydetyt)
                    {
                        lemmikki.ruoat.Add(ruoka);
                    }

                    VastaanTulija();

                    break;

                case "Kyllä":
                    if (lemmikki.OverAllHealth==0)
                    {
                        lemmikki = uusilemmikki;
                    }

                    if (vastaantulija == true)
                    {
                        textBox3.Text += Environment.NewLine
                            + "Minkä ruoan haluat antaa vaihdossa?";
                        TeeVaihtoKauppa();
                    }
                    break;

                default:
                    textBox1.Text+= "Virheellinen komento!";
                    break;
            }

            NäytäLemmikinKuva();
            NäytäInventoryJaHealth();

        }

        private void VastaanTulija()
        {
            vastaantulija = true;

            Random rnd = new Random();
            vastaantulijanruoka = rnd.Next(0, randomruoat.Count);

            textBox3.Text = "Oho! Löysit vastaantulijan." + Environment.NewLine +
                $"Hänellä on {randomruoat[vastaantulijanruoka].ruoanNimi} ja hän haluaisi tehdä kanssasi vaihtokaupan." + Environment.NewLine
                + "Haluatko vaihtaa? Vastaa kyllä/ei.";
        }

        private void TeeVaihtoKauppa()
        {
            string vaihdettava = textBox2.Text;
            for (int i = 0; i < lemmikki.ruoat.Count; i++)
            {
                if (lemmikki.ruoat[i].ruoanNimi.Equals(vaihdettava))
                {
                    lemmikki.ruoat.Remove(lemmikki.ruoat[i]);
                    lemmikki.ruoat.Add(randomruoat[vastaantulijanruoka]);
                    break;
                }
            }

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
     

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
