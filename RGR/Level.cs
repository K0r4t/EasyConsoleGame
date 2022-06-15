using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    //  ###############
    //  #             #  -- рівень
    //  #             #
    //  #             #
    //  #             #
    //  #             #         15x7
    //  ###############


    // + -- вражина
    // & -- герой
    public class Level
    {
        private string[,] map;
        int hor, vert;


        public void Setlevel(int hor, int vert)
        {
            this.hor = hor; this.vert = vert;

            map = new string[hor, vert];

            for (int i = 0; i < hor; i++)
            {
                for(int j = 0; j<vert; j++)
                {
                    if (i == 0 || i == hor - 1 || j == 0 || j == vert - 1) map[i, j] = "#";
                    else map[i, j] = " ";
                }
            }

            for (int j = 0; j < vert; j++)
            {
                for (int i = 0; i < hor; i++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        

        public void Showlevel()
        {
                Console.Clear();
                for (int j = 0; j < vert; j++)
                {
                    for (int i = 0; i < hor; i++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
        }


        public string[,] ReturnMap()
        {
            return map;
        }
    }
}
