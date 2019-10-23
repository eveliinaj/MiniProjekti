using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    public class Kartta
    {
        public KoordinaattiMääreet Sijainti { get; set; }

        public List<Ruoka> randomruoat = new List<Ruoka>();
        public List<Ruoka> löydetyt = new List<Ruoka>();

        int palkinto = 0;

        public void RandomRuokaa()
        {
            Ruoka ruoka = new Ruoka("omena", 2);
            randomruoat.Add(ruoka);
            Ruoka siemen = new Ruoka("siemen", 1);
            randomruoat.Add(siemen);
            Ruoka salmiakki = new Ruoka("salmiakki", 3);
            randomruoat.Add(salmiakki);




            
        }




        public List<Ruoka> NäytäKartta()
        {
            RandomRuokaa();
            Console.WindowHeight = 26;
            Console.WindowWidth = 64;
            int näytönleveys = Console.WindowWidth;
            int näytönkorkeus = Console.WindowHeight;

            Random randomnumber = new Random();

            int itemix = randomnumber.Next(0, näytönleveys);
            int itemiy = randomnumber.Next(0, näytönkorkeus);
            int itemisumma = 0;

            do
            {
                Peli();
            }
            while (itemisumma < 3);

            void Peli()
            {
                Taustaväri();
                Itemit();

                Sijainti = new KoordinaattiMääreet()
                {
                    X = 0,
                    Y = 0
                };

                Liikkuminen(0, 0);

                ConsoleKeyInfo Näppäimet;
                while ((Näppäimet = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (Näppäimet.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Liikkuminen(0, -1);
                            break;

                        case ConsoleKey.RightArrow:
                            Liikkuminen(1, 0);
                            break;

                        case ConsoleKey.DownArrow:
                            Liikkuminen(0, 1);
                            break;

                        case ConsoleKey.LeftArrow:
                            Liikkuminen(-1, 0);
                            break;
                    }

                    if (itemix == Sijainti.X && itemiy == Sijainti.Y)
                    {

                        itemix = randomnumber.Next(1, näytönleveys - 2);
                        itemiy = randomnumber.Next(1, näytönkorkeus - 2);
                        itemisumma++;

                        Random random = new Random();
                        palkinto = random.Next(0, randomruoat.Count);

                        löydetyt.Add(randomruoat[palkinto]);

                        Itemit();

                        return;
                    }
                }

                void Itemit()
                {
                    Console.SetCursorPosition(itemix, itemiy);
                    Console.BackgroundColor = ConsoleColor.Red; // taustaväri itemin alle
                    Console.Write("X"); // kuva joka piirtyy itemin päälle
                }
            }
            return löydetyt;
        }

        public void Liikkuminen(int x, int y)
        {
            KoordinaattiMääreet newSijainti = new KoordinaattiMääreet()
            {
                X = Sijainti.X + x,
                Y = Sijainti.Y + y
            };

            if (Liiku(newSijainti))
            {
                PolkuPerässä();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(newSijainti.X, newSijainti.Y);
                Console.Write("■"); // Tässä määritellään kuva lemmikin päällä

                Sijainti = newSijainti;
            }
        }

        public void PolkuPerässä() // PolkuPerässä Piirtää väriä ja reittiä lemmikin perässä
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(Sijainti.X, Sijainti.Y);
            Console.Write(" ");
        }

        public bool Liiku(KoordinaattiMääreet koordinaatti) // Liikkuminen kartalla
        {
            if (koordinaatti.X < 0 || koordinaatti.X >= Console.WindowWidth)
                return false;

            if (koordinaatti.Y < 0 || koordinaatti.Y >= Console.WindowHeight)
                return false;

            return true;
        }

        public void Taustaväri()
        {
            Console.BackgroundColor = ConsoleColor.Green; // Määrittelee koko konsolisivun/kartan taustavärin
            Console.Clear(); //Tärkeä!
        }
    }

    public class KoordinaattiMääreet
    {
        public int X { get; set; } //VASEN koordinaatti property
        public int Y { get; set; } //YLÖS koordinaatti property
    }




}

