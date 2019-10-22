using System;
using System.Collections.Generic;

namespace Peli
{
    public class Lemmikki
    {
        public string name;
        public int OverAllHealth;
        private int hygiene;

        private int mieliala;
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
        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Harjat> harjat = new List<Harjat>();
        public List<Pesutapa> pesut = new List<Pesutapa>();
        public List<Leikki> leikit = new List<Leikki>();

        public Lemmikki()
        {

            this.OverAllHealth = hygiene + hunger+ Mieliala;

            Random rnd = new Random();
            int ruoanmäärä = rnd.Next(2, 5);

            Ruoka ruoka = new Ruoka("omena", 2);

            for (int i = 0; i <= ruoanmäärä; i++)
            {
                ruoat.Add(ruoka);
            }

            Harjat harja = new Harjat("harja", 5);
            harjat.Add(harja);
            Pesutapa pesu1 = new Pesutapa("silvershampoo", 3);
            pesut.Add(pesu1);
            Leikki pallo = new Leikki("Potki palloa", 3);
            leikit.Add(pallo);

        }
        public void Harjaa()
        {
            hygiene += harjat[0].pisteet;
        }

        public void Pese()
        {
            hygiene += pesut[0].Pisteet;
        }

        public void Syötä()
        {
            hunger += ruoat[0].pisteet;
        }

        internal void Leiki()
        {
            Mieliala +=leikit[0].pisteet;
        }

        internal void Paijaa()
        {
            Mieliala += 3;
        }
    }
}