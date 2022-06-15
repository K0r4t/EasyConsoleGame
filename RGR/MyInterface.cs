using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public class MyInterface
    {
        Level level;

        private string[,] map;

        public MyInterface(Level l)
        {
            level = l;
        }

        int hp, gold, power;
        bool ifis;

        public void display(int hp, int gold, int power)
        {
            this.ifis = ifis;
            this.hp = hp;
            this.gold = gold;
            this.power = power;             

            level.Showlevel();

            Console.WriteLine("\n" + "Current HP = " + hp + "  Current Gold = " + gold + "  Current Power = " + power);
        }
    }
}