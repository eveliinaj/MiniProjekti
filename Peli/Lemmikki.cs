using System;
using System.Collections.Generic;

namespace Peli
{
    public class Lemmikki
    {
        public string name;
        public int OverAllHealth;
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
                if (value > 70)
                    value = 70;

                hunger = value;
            }
        }


        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Harjat> harjat = new List<Harjat>();

        public Lemmikki()
        {

            this.OverAllHealth = hygiene + hunger;


            Random rnd = new Random();
            int ruoanmäärä = rnd.Next(2, 5);

            Ruoka ruoka = new Ruoka("omena", 2);

            for (int i = 0; i <= ruoanmäärä; i++)
            {
                ruoat.Add(ruoka);
            }

            Harjat harja = new Harjat("harja", 5);
            harjat.Add(harja);

        }
        public void Harjaa()
        {
            hygiene += harjat[0].pisteet;
        }

    }
}