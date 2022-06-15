using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public class Enemy : IEnemy
    {
        private readonly Level level;
        private readonly MyInterface myinterface;
        private readonly Random random;

        private string[,] map;
        public int x, y, hp, gold, power, hor, vert, enemyhp = 3;
        int i = 1;              // для респавну
        bool ifis = true;
        string r;

        public Enemy(Level l, MyInterface mi, Random r) //конструктор
        {
            random = r;
            level = l;
            myinterface = mi;
            map = l.ReturnMap();
        }

        public void Spawn(int hor, int vert)
        {
            this.hor = hor;
            this.vert = vert;
            x = hor - (hor / 3) - 1;
            y = vert - (vert / 3) - 1;
            map[x, y] = "+";
            myinterface.display(hp, gold, power);
        }

        public void Respawn()
        {
            if (i == 1)
            {
                x = (hor / 3);
                y = (vert / 3);
            }
            else if (i == 2)
            {
                x = hor - (hor / 3) - 1;
                y = (vert / 3);
            }
            else if (i == 3)
            {
                x = (hor / 3);
                y = vert - (vert / 3) - 1;
            }
            else if (i == 4)
            {
                x = hor - (hor / 3) - 1;
                y = vert - (vert / 3) - 1;
            }

            map[x, y] = "+";

            if (i != 4)
                i++;
            else if (i == 4)
                i = 1;
        }

        public bool TakeDamage(int power)
        {
            enemyhp-=power;
            if (enemyhp <= 0)
            {
                enemyhp = 3;
                return false;
            }
            else
                return true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        int randomnumber;

        public void EnemyMove()
        {
            randomnumber = random.Next(1, 5);
            string r;

            //if (map[x, y + 1] != "#" && map[x, y + 1] != "&") down = true;
            //if (map[x + 1, y] != "#" && map[x + 1, y] != "&") right = true;
            //if (map[x - 1, y] != "#" && map[x - 1, y] != "&") left = true;
            //if (map[x, y - 1] != "#" && map[x, y - 1] != "&") up = true;

            if (randomnumber == 1)       //down
            {
                if (map[x, y + 1] != "#" && map[x, y + 1] != "&")
                {
                    r = map[x, y];
                    map[x, y] = map[x, y + 1];
                    map[x, y + 1] = r;
                    y++;
                }                          
            }
            if (randomnumber == 2) //вправо
            {
                if (map[x + 1, y] != "#" && map[x + 1, y] != "&")
                {
                    r = map[x, y];
                    map[x, y] = map[x + 1, y];
                    map[x + 1, y] = r;
                    x++;
                }
            }
            if (randomnumber == 3)  //left
            {
                if (map[x - 1, y] != "#" && map[x - 1, y] != "&")
                {
                    r = map[x, y];
                    map[x, y] = map[x - 1, y];
                    map[x - 1, y] = r;
                    x--;
                }
            }
            if (randomnumber == 4)   // right
            {
                if (map[x, y - 1] != "#" && map[x, y - 1] != "&") 
                {
                    r = map[x, y];
                    map[x, y] = map[x, y - 1];
                    map[x, y - 1] = r;
                    y--;
                }
            }
        }
    }
}