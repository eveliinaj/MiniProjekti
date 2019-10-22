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

        private int mieliala;
        public int Mieliala
        {
            get { return mieliala; }
            set
            {
                if (value > 30)
                    value = 30;

                mieliala = value;
            }
        }
        private int hygiene;
        public int Hygiene
        {
            get { return hygiene; }
            set
            {
                if (value > 30)
                    value = 30;

                hygiene = value;
            }
        }
        private int hunger;
        public int Hunger
        {
            get { return hunger; }
            set
            {
                if (value > 40)
                    value = 40;

                hunger = value;
            }
        }

        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Harjat> harjat = new List<Harjat>();
        public List<Pesutapa> pesut = new List<Pesutapa>();
        public List<Leikki> leikit = new List<Leikki>();

        public Lemmikki()
        {

            this.OverAllHealth = hygiene + hunger + Mieliala;

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

            Harjat harja = new Harjat("harja", 5);
            harjat.Add(harja);
            Pesutapa pesu1 = new Pesutapa("silvershampoo", 7);
            Pesutapa sieni = new Pesutapa("pesusieni", 5);
            pesut.Add(sieni);
            pesut.Add(pesu1);
            Leikki pallo = new Leikki("potki palloa", 8);
            Leikki kutitus = new Leikki("kutita", 7);
            leikit.Add(kutitus);
            leikit.Add(pallo);

        }
        public void Harjaa(string harja)
        {
            int indeksi = 0;
            for (int i = 0; i < harjat.Count; i++)
            {
                if (harjat[i].harja.Equals(harja))
                {
                    indeksi = i;
                }
                
            }
            hygiene += harjat[indeksi].pisteet;
            LaskeOverall();
        }

        public void LaskeOverall()
        {
            OverAllHealth = hygiene + mieliala + hunger;

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
            hygiene += pesut[indeksi].Pisteet;
            LaskeOverall();

        }

        public void Syötä(string ruoka)
        {
            int indeksi = 0;
            for (int i = 0; i < ruoat.Count; i++)
            {
                if (ruoat[i].ruoanNimi.Equals(ruoka))
                {
                    indeksi = i;
                }

            }
            hunger += ruoat[indeksi].pisteet;
            LaskeOverall();

        }

        internal void Leiki()
        {
            Mieliala += leikit[0].pisteet;
            LaskeOverall();

        }

        internal void Paijaa()
        {
            mieliala += 3;
            LaskeOverall();

        }
    }
}