using System;
using System.Collections.Generic;

namespace Peli
{
    public class Lemmikki
    {
        public string name;
        public int health;
        public List<Ruoka> ruoat = new List<Ruoka>();
        public List<Harjat> harjat = new List<Harjat>();

        public Lemmikki()
        {
            this.health = 50;

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

    }
}