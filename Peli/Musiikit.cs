using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    public class Musiikit
    {
        public string Musiikki { get; set; }
        public Musiikit()
        {
            
        }

        public void VoittoMusa()
        {
            Console.Beep(2500, 400);
            Console.Beep(2500, 200);
            Console.Beep(2500, 200);
            Console.Beep(3200, 300);
            //Console.Beep(3200, 200);
            //Console.Beep(3200, 200);
            Console.Beep(3200, 400);
            Console.Beep(3200, 300);
            Console.Beep(2500, 200);
            Console.Beep(2500, 200);
            //Console.Beep(3200, 400);
            //Console.Beep(2500, 500);
            //Console.Beep(2500, 300);
            Console.Beep(2500, 300);
            Console.Beep(3200, 1000);
        }
        public void VakioPerusMusa()
        {
            Console.Beep(3200, 140);
            Console.Beep(3200, 140);
            Console.Beep(3200, 700);
        }

        public void Alle20Musa()
        {
            Console.Beep(2500, 300);
            Console.Beep(2500, 300);
            Console.Beep(2000, 300);
            Console.Beep(2500, 300);
            Console.Beep(2500, 300);
            Console.Beep(2000, 300);
            Console.Beep(2000, 300);
            Console.Beep(2500, 300);
            Console.Beep(2500, 300);
        }
        public void GameOverMusa()
        {
            Console.Beep(200, 800);
            Console.Beep(150, 800);
            Console.Beep(90, 1500);
        }
    }
}
