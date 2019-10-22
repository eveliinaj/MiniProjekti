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
            //Random rnd = new Random();
            Ruoka ruoka = new Ruoka("omena", 2);

        }

    }
}