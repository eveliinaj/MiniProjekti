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

        Kartta kartta = new Kartta();
        
        List<Ruoka> löydetyt = new List<Ruoka>();

        bool vastaantulija = false;
        bool tehdäänvaihto = false;
        int vastaantulijanruoka = default;
        public List<Ruoka> randomruoat = new List<Ruoka>();
        Ruoka myrkkysieni = new Ruoka("myrkkysieni", -5);
        Ruoka karkki = new Ruoka("karkki", 10);
        
        string ohjeet = "Yleisimmät komennot:" + Environment.NewLine
            + "syötä x = syötä haluamasi ruoka (esim. syötä omena)" + Environment.NewLine
            + "harjaa harjalla = harjaa eläintä" + Environment.NewLine
            + "paijaa = paijaa eläintä" + Environment.NewLine
            + "pese x = pese eläin (esim. pese pesusieni)" + Environment.NewLine
            + "Kokeile vapaasti muitakin komentoja!";

        public Form1()
        {
            InitializeComponent();
            hWnd = GetConsoleWindow();
            randomruoat.Add(myrkkysieni);
            randomruoat.Add(karkki);
            textBox3.Text = ohjeet;
            lemmikki = lemmikki.LataaTallennettu<Lemmikki>();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Enabled = false;

            NäytäLemmikinKuva();
            NäytäInventory();
            NäytäHealth();
            
        }

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

        private void NäytäInventory()
        {
            List<string> varasto = new List<string>();
            List<int> varastonmäärä = new List<int>();
            bool löytyi = false;

            label2.Text = default;


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
            foreach (var pesu in lemmikki.pesut)
            {
                label2.Text += Environment.NewLine + pesu.Nimi;
            }
            foreach (var leikki in lemmikki.leikit)
            {
                label2.Text += Environment.NewLine + leikki.nimi;
            }

        }
        private void NäytäHealth()
        {
            label1.Text = default;
            label1.Text += Environment.NewLine + lemmikki.OverAllHealth;
            switch (lemmikki.OverAllHealth)
            {
                case 0:
                    textBox1.Text = "Lemmikkisi kuoli. Haluatko aloittaa uuden pelin? Vastaa kyllä/ei.";
                    break;
                case int n when n <= 10:
                    textBox1.Text = "Lemmikkisi on huonossa hapessa. TEE JOTAIN!!!";
                    break;
                case int n when n <= 30:
                    textBox1.Text = "Hoidokkisi sinnittelee...";
                    break;
                case int n when n <= 40:
                    textBox1.Text = "Hoidokkisi vointi voisi olla parempi.";
                    break;
                case int n when n <= 50:
                    textBox1.Text = "Lemmikkisi vointi on stabiili.";
                    break;
                case int n when n <= 60:
                    textBox1.Text = "Lemmikkisi näyttää voivan ihan ok!";
                    break;
                case int n when n <= 70:
                    textBox1.Text = "Hienoa!";
                    break;
                case int n when n <= 80:
                    textBox1.Text = "Teillä pyyhkii hyvin!";
                    break;
                case int n when n <= 90:
                    textBox1.Text= "Lemmikkisi on tyytyväinen. Erinomaista työtä!";
                    break;
                case int n when n < 100:
                    textBox1.Text = "Olet fantastinen eläintenhoitaja!";
                    break;
                case 100:
                    textBox1.Text = "Perfection";
                    break;
                default:
                    break;
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
            input = input.ToLower();
            var splitattu = input.Split(' ');

            if (tehdäänvaihto == true)
            {
                string vaihdettava = textBox2.Text;
                TeeVaihtoKauppa(vaihdettava);
                tehdäänvaihto = false;
            }

            switch (splitattu[0])
            {
                case "harjaa":
                    lemmikki.Pese(splitattu[1]);
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

                    textBox3.Text = "Jee! Löysit seuraavat asiat:" + Environment.NewLine;

                    foreach (var ruoka in löydetyt)
                    {
                        lemmikki.ruoat.Add(ruoka);
                        textBox3.Text += ruoka.ruoanNimi + Environment.NewLine;
                    }

                    for (int i = löydetyt.Count -1; i >= 0; i--)
                    {
                        löydetyt.Remove(löydetyt[i]);
                    }
                   
                    VastaanTulija();

                    break;

                case "kyllä":
                    if (lemmikki.OverAllHealth==0)
                    {
                     Lemmikki uusilemmikki = new Lemmikki();
                        lemmikki = uusilemmikki;
                    }

                    if (vastaantulija == true)
                    {
                        tehdäänvaihto = true;

                        textBox3.Text += Environment.NewLine + Environment.NewLine
                            + "Minkä ruoan haluat antaa vaihdossa?";
                        vastaantulija = false;
                    }
                    break;

                case "ei":
                    textBox3.Text = ohjeet;
                    break;

                case "poistu":
                    lemmikki.Tallenna(lemmikki);
                    break;

                default:
                    textBox1.Text+= Environment.NewLine + "Virheellinen komento!";
                    break;
            }


            NäytäLemmikinKuva();
            NäytäInventory();
            NäytäHealth();

        }

        private void VastaanTulija()
        {
            vastaantulija = true;

            Random rnd = new Random();
            vastaantulijanruoka = rnd.Next(0, randomruoat.Count);

            textBox3.Text += Environment.NewLine + "Oho! Löysit vastaantulijan." + Environment.NewLine +
                $"Hänellä on {randomruoat[vastaantulijanruoka].ruoanNimi} ja hän haluaisi tehdä kanssasi vaihtokaupan." + Environment.NewLine
                + "Haluatko vaihtaa? Vastaa kyllä/ei.";
        }

        private void TeeVaihtoKauppa(string vaihdettava)
        {
            for (int i = 0; i < lemmikki.ruoat.Count; i++)
            {
                if (lemmikki.ruoat[i].ruoanNimi.Equals(vaihdettava))
                {
                    lemmikki.ruoat.Remove(lemmikki.ruoat[i]);
                    lemmikki.ruoat.Add(randomruoat[vastaantulijanruoka]);
                    break;
                }
            }

            textBox3.Text = ohjeet;
            vastaantulija = false;
            NäytäInventory();
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
            NäytäInventory();
            NäytäLemmikinKuva();
            NäytäHealth();
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
