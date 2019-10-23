using System;
using System.Collections.Generic;

namespace Peli
{
    public class Lemmikki
    {
        public string name;
        private int overAllHealth;
        public int OverAllHealth
        {
            get { return overAllHealth; }
            set
            {
                if (value > 100)
                    value = 100;

                overAllHealth = value;
                
            }
        }

        

        private int mieliala=5;
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
        private int hygiene=5;
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
        private int hunger=5;
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

        public List<Pesutapa> dummypesutavat = new List<Pesutapa>();

        Pesutapa pesu1 = new Pesutapa("hopeashampoo", 7);
        Pesutapa sieni = new Pesutapa("pesusieni", 5);
        Pesutapa harja = new Pesutapa("harja", 5);
        Pesutapa kylpy = new Pesutapa("vaahtokylpy", 10);
        Pesutapa suihku = new Pesutapa("suihku", 5);
        

        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Pesutapa> pesut = new List<Pesutapa>();
        public List<Leikki> leikit = new List<Leikki>();

        public Lemmikki()
        {
            TeeDummyLista();

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

            Leikki pallo = new Leikki("potki palloa", 8);
            Leikki kutitus = new Leikki("kutita", 7);
            leikit.Add(kutitus);
            leikit.Add(pallo);


            for (int i = 0; i < 2; i++)
            {
                int arvottuhygieniatuote = rnd.Next(0, dummypesutavat.Count);
                pesut.Add(dummypesutavat[arvottuhygieniatuote]);
                dummypesutavat.Remove(dummypesutavat[arvottuhygieniatuote]);
            }
        }

        public void TeeDummyLista()
        {
            dummypesutavat.Add(pesu1);
            dummypesutavat.Add(sieni);
            dummypesutavat.Add(harja);
            dummypesutavat.Add(kylpy);
            dummypesutavat.Add(suihku);
        }

        public int LaskeOverall()
        {
            OverAllHealth = hygiene + mieliala + hunger;
            return OverAllHealth;
        }

        public void Pese(string pesu)
        {
            int indeksi = 0;
            for (int i = 0; i < pesut.Count; i++)
            {
                if (pesut[i].Nimi.Equals(pesu))
                {
                    indeksi = i;
                }

            }
            Hygiene += pesut[indeksi].Pisteet;
            LaskeOverall();

        }

        public void Syötä(string ruoka)
        {
            for (int i = 0; i < ruoat.Count; i++)
            {
                if (ruoat[i].ruoanNimi.Equals(ruoka))
                {
                    Hunger += ruoat[i].pisteet;
                    ruoat.Remove(ruoat[i]);
                    LaskeOverall();
                    break;
                }
            }
        }

        internal void Leiki()
        {
            Mieliala += leikit[0].pisteet;
            LaskeOverall();

        }

        internal void Paijaa()
        {
            Mieliala += 3;
            LaskeOverall();

        }
    }
}