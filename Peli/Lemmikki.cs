using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Peli
{
    public class Lemmikki
    {
        public string name;
        public int overAllHealth;
        public int OverAllHealth
        {
            get { return overAllHealth; }
            set
            {
                if (value > 100)
                    value = 100;
                else if (value < 0)
                    value = 0;
                overAllHealth = value;
            }
        }
        private int mieliala = 20;
        public int Mieliala
        {
            get { return mieliala; }
            set
            {
                if (value >= 30)
                    value = 30;
                mieliala = value;
            }
        }
        private int hygiene = 20;
        public int Hygiene
        {
            get { return hygiene; }
            set
            {
                if (value >= 30)
                    value = 30;
                hygiene = value;
            }
        }
        private int hunger = 20;
        public int Hunger
        {
            get { return hunger; }
            set
            {
                if (value >= 40)
                    value = 40;
                hunger = value;
            }
        }
        public int ikä = 0;

        public List<Pesutapa> dummypesut = new List<Pesutapa>(); // luodaan dummypesut-niminen lista Pesutapa tietotyypillä
        Pesutapa pesu1 = new Pesutapa("hopeashampoo", 7); // luodaan dummypesut listaan hopeashampoo olio
        Pesutapa sieni = new Pesutapa("pesusieni", 5); // luodaan dummypesut listaan pesusieni olio
        Pesutapa kylpy1 = new Pesutapa("vaahtokylpy", 10); // luodaan dummypesut listaan vaahtokylpy olio
        Pesutapa suihku1 = new Pesutapa("suihku", 3); // luodaan dummypesut listaan suihku olio

        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Pesutapa> pesut = new List<Pesutapa>();
        public List<Leikki> leikit = new List<Leikki>();

        public Lemmikki(bool teeuusi)
        {
            LisääDummyPesut();
            this.OverAllHealth = Hygiene + Hunger + Mieliala;
            Random rnd = new Random();
            int ruoanmäärä = rnd.Next(2, 5);
            Ruoka ruoka = new Ruoka("omena", 2);
            Ruoka siemen = new Ruoka("siemen", 1);
            Ruoka salmiakki = new Ruoka("salmiakki", 3);
            for (int i = 0; i <= ruoanmäärä; i++)
            {
                ruoat.Add(ruoka);
                ruoat.Add(siemen);
                ruoat.Add(salmiakki);
            }
            int arvotutpesut;
            for (int i = 0; i < 2; i++)
            {
                arvotutpesut = rnd.Next(0, dummypesut.Count);
                pesut.Add(dummypesut[arvotutpesut]);
                dummypesut.Remove(dummypesut[arvotutpesut]);
            }

            Pesutapa pesu1 = new Pesutapa("silvershampoo", 7);
            Pesutapa sieni = new Pesutapa("pesusieni", 5);
            pesut.Add(sieni);
            pesut.Add(pesu1);
            Leikki pallo = new Leikki("pallonpotkiminen", 8);
            Leikki kutitus = new Leikki("kutitus", 7);
            Leikki pelaa = new Leikki("miinaharava", -5);
            Leikki tyyny = new Leikki("tyynysota", 5);
            leikit.Add(kutitus);
            leikit.Add(pallo);
            leikit.Add(pelaa);
            leikit.Add(tyyny);
        }

        public Lemmikki()
        {

        }
        public void LisääDummyPesut()
        {
            dummypesut.Add(sieni);
            dummypesut.Add(pesu1);
            dummypesut.Add(kylpy1);
            dummypesut.Add(suihku1);
        }

        public int LaskeOverall()
        {
            OverAllHealth = hygiene + mieliala + hunger; //laskee lemmikin healthit yhteen kolmelta eri osa-alueelta
            return OverAllHealth;
        }
        public bool Pese(string pesu)
        {
            bool löytyykö = true;

            for (int i = 0; i < pesut.Count; i++)
            {
                if (pesut[i].Nimi.Equals(pesu))
                {

                    löytyykö = true;
                    Hygiene += pesut[i].Pisteet;
                    LaskeOverall();
                    break;
                }
                else
                    löytyykö = false;
            }
            return löytyykö;
        }
        public bool Syötä(string ruoka)
        {
            bool löytyykö = true;
            for (int i = 0; i < ruoat.Count; i++)
            {
                if (ruoat[i].ruoanNimi.Equals(ruoka))
                {
                    Hunger += ruoat[i].pisteet;
                    ruoat.Remove(ruoat[i]);
                    LaskeOverall();
                    löytyykö = true;
                    break;
                }
                else
                    löytyykö = false;
            }
            return löytyykö;
        }
        public bool Leiki(string leikki)
        {
            bool löytyykö = true;
            for (int i = 0; i < leikit.Count; i++)
            {
                if (leikit[i].nimi.Equals(leikki))
                {
                    Mieliala += leikit[i].pisteet;
                    LaskeOverall();
                    löytyykö = true;
                    break;
                }
                else
                    löytyykö = false;
            }
            return löytyykö;
        }
        internal void Paijaa()
        {
            Mieliala += 3;
            LaskeOverall();
        }
        internal void Harjaa()
        {
            Mieliala += 2;
            hygiene += 3;
            LaskeOverall();
        }
        public void Tallenna(Lemmikki tallennettava)
        {
            XmlSerializer serializerTallenna = new XmlSerializer(typeof(Lemmikki));
            using (StreamWriter myWriter = new StreamWriter(@"..\..\TallennusXML\Tallennus.xml", false))
            {
                serializerTallenna.Serialize(myWriter, tallennettava);
            }
        }
        public Lemmikki LataaTallennettu<Lemmikki>()
        {
            XmlSerializer serializerLataa = new XmlSerializer(typeof(Lemmikki));

            Lemmikki luettu = default(Lemmikki);

            if (string.IsNullOrEmpty(@"..\..\TallennusXML\Tallennus.xml")) return default(Lemmikki);
            try
            {
                StreamReader xmlStream = new StreamReader(@"..\..\TallennusXML\Tallennus.xml");
                luettu = (Lemmikki)serializerLataa.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return luettu;
        }
    }
}