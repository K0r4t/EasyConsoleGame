using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public class Hero : IHero
    {
        private readonly Level level;
        private readonly MyInterface myinterface;
        private readonly IEnemy enemy;

        private string[,] map;
        public int x = 1, y = 1;
        bool ifis = true;
        string r;

        public int hp = 10, gold = 0, power = 1;

        public Hero(Level l, MyInterface mi, IEnemy e) //конструктор
        {
            level = l;
            myinterface = mi;
            enemy = e;
            map = l.ReturnMap();
        }

        public void Spawn()
        {
            map[x, y] = "&";                        // (спавн)
            int rows = map.GetUpperBound(0) + 1;    // рядки
            int columns = map.Length / rows;        // стовбці
        }

        public void Movedown()
        {
            if (map[x, y + 1] != "#" && map[x, y + 1] != "+")
            {
                r = map[x, y];
                map[x, y] = map[x, y + 1];
                map[x, y + 1] = r;
                y++;
            }
            else if (map[x, y + 1] == "+")
            {
                if (enemy.TakeDamage(power) == false)
                {
                    map[x, y + 1] = " ";
                    AddGold();
                    AddPower();
                    enemy.Respawn();
                }
                AddHP();
            }
        }

        public void Moveright()
        {
            if (map[x + 1, y] != "#" && map[x + 1, y] != "+")
            {
                r = map[x, y];
                map[x, y] = map[x + 1, y];
                map[x + 1, y] = r;
                x++;
                //ifis = true;
            }
            else if (map[x + 1, y] == "+")
            {
                if (enemy.TakeDamage(power) == false)
                {
                    map[x + 1, y] = " ";
                    AddGold();
                    AddPower();
                    enemy.Respawn();
                }
                AddHP();
            }
        }

        public void Moveleft()
        {
            if (map[x - 1, y] != "#" && map[x - 1, y] != "+")
            {
                r = map[x, y];
                map[x, y] = map[x - 1, y];
                map[x - 1, y] = r;
                x--;
            }
            else if (map[x - 1, y] == "+")
            {
                if (enemy.TakeDamage(power) == false)
                {
                    map[x - 1, y] = " ";
                    AddGold();
                    AddPower();
                    enemy.Respawn();
                }
                AddHP();
            }
            //myinterface.display(ifis, hp, gold, power);
        }

        public void Moveup()        /////////////////////////////////////////////////////////////////////////////
        {
            if (map[x, y - 1] != "#" && map[x, y - 1] != "+")
            {
                r = map[x, y];
                map[x, y] = map[x, y - 1];
                map[x, y - 1] = r;
                y--;
            }
            else if (map[x, y - 1] == "+")
            {
                if (enemy.TakeDamage(power) == false)
                {
                    map[x, y - 1] = " ";
                    AddGold();
                    AddPower();
                    enemy.Respawn();
                }
                    AddHP();
            }
            //myinterface.display(ifis, hp, gold, power);
        }

        public void HeroShow()
        {
            myinterface.display(hp, gold, power);
        }

        public void AddGold()        //хп, голда, дамаг і тд
        {
            gold += 10;
        }

        public void AddHP()
        {
            if (hp - 1 != 0)
                hp -= 1;
            else
            {
                myinterface.display(hp - 1, gold, power);
                Console.WriteLine("You are dead");
                Environment.Exit(0);
            }
        }
        public void AddPower()
        {
            power += 1;
        }
    }
}