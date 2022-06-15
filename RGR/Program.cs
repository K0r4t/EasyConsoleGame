using System.Windows.Input;
using System.Threading;

namespace exit_console_application { }

namespace RGR
{
    class Program
    {
        static void Main()
        {
            Level level = new Level();
            Random random = new Random();

            int hor;
            int vert;
            bool isNumeric=false;

            Console.WriteLine("Enter level size: ");

            Console.WriteLine("Horizontal size: ");
            do
            {
                string temphor = Console.ReadLine();
                isNumeric = int.TryParse(temphor, out hor);
                if (isNumeric == true)
                {
                    hor = Convert.ToInt32(temphor);
                }
                else Console.WriteLine("Enter a number:");
            } while (isNumeric == false);
            isNumeric = true;

            Console.WriteLine("Vertical size: ");
            do
            {
                string temphor = Console.ReadLine();
                isNumeric = int.TryParse(temphor, out vert);
                if (isNumeric == true)
                {
                    vert = Convert.ToInt32(temphor);
                }
                else Console.WriteLine("Enter a number:");
            } while (isNumeric == false);
            isNumeric = true;


            //hor = 7;
            //vert = 7;
            hor += 2;
            vert += 2;                    //Для вводу значень всередені рівня, а не поза ним або в ньому
            level.Setlevel(hor, vert);    //Задається розмір рівня

            MyInterface myinterface = new MyInterface(level);

            Enemy enemy = new Enemy(level, myinterface, random);
            Hero hero = new Hero(level, myinterface, enemy);

            hero.Spawn();
            enemy.Spawn(hor, vert);

            ConsoleKeyInfo button;
            do
            {
                //Thread.Sleep(20);
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.W || button.Key == ConsoleKey.UpArrow)
                {
                    hero.Moveup();
                    enemy.EnemyMove();
                    hero.HeroShow();
                }
                if (button.Key == ConsoleKey.A || button.Key == ConsoleKey.LeftArrow)
                {
                    hero.Moveleft();
                    enemy.EnemyMove();
                    hero.HeroShow();
                }
                if (button.Key == ConsoleKey.S || button.Key == ConsoleKey.DownArrow)
                {
                    hero.Movedown();
                    enemy.EnemyMove();
                    hero.HeroShow();
                }
                if (button.Key == ConsoleKey.D || button.Key == ConsoleKey.RightArrow)
                {
                    hero.Moveright();
                    enemy.EnemyMove();
                    hero.HeroShow();
                }
            } while (button.Key != ConsoleKey.Escape);
        }
    }
}
