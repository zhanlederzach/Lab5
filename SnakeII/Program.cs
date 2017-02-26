using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII
{
    class Program
    {
        public static Thread toMove = new Thread(new ThreadStart(callingMove));
        public static Thread pressedKeys = new Thread(new ThreadStart(play));
       
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new SnakeII.Game();
            Program.pressedKeys.Start();
        }

        public static void play()
        {
            Game.food.Generate();
            Game.wall.Generate();
            Game.worm.Generate();
            toMove.Start();
            Game.food.Draw();
            Game.wall.Draw();
            Game.worm.Draw();
            while (Game.inGame)
            {
                Game.wall.Draw();
                Game.food.Draw();
                Game.worm.Draw();
                ConsoleKeyInfo button = Console.ReadKey(true);

                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.worm.changeDirection(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.worm.changeDirection(0, 1);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.worm.changeDirection(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.worm.changeDirection(-1, 0);
                        break;
                    case ConsoleKey.F1:
                        break;
                }
                Game.worm.Clear();
            }
        }

        public static void callingMove()
        {
            while (Game.inGame)
            {
                Thread.Sleep(Game.SPEED);
                Game.worm.Clear();

                for (int i = Game.worm.points.Count - 1; i > 0; --i)
                {
                    Game.worm.points[i].x = Game.worm.points[i - 1].x;
                    Game.worm.points[i].y = Game.worm.points[i - 1].y;
                }

                if (Game.worm.points[0].x + Game.worm.dx < 0)// for x
                    Game.worm.points[0].x = 50;
                else
                    if (Game.worm.points[0].x + Game.worm.dx > Game.WIDTH)
                        Game.worm.points[0].x = 0;
                    else
                    Game.worm.points[0].x = Game.worm.points[0].x + Game.worm.dx;

                if (Game.worm.points[0].y + Game.worm.dy < 0) // for y
                    Game.worm.points[0].y = 30;
                else
                    if (Game.worm.points[0].y + Game.worm.dy > Game.HEIGTH)
                         Game.worm.points[0].y = 0;
                    else
                    Game.worm.points[0].y = Game.worm.points[0].y + Game.worm.dy;

                Game.worm.Draw();
                Game.worm.game.CanEat();
                if (Game.worm.Collision())
                    Game.inGame = false;
            }
        }

    }
}
