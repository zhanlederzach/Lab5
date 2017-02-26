using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII {
	class Program {
		public static Thread toMove = new Thread(new ThreadStart(callingMove));
		public static Thread pressedKeys = new Thread(new ThreadStart(play));

		static void Main(string[] args) {
			Console.Clear();
			Console.CursorVisible = false;
			Console.SetWindowSize(Game.WIDTH, Game.HEIGTH);
			Game.Init();
			pressedKeys.Start();
		}

		public static void play() {
			Game.Generate();
			toMove.Start();
			Game.Draw();
			while (Game.inGame) {
				Game.Draw();
				ConsoleKeyInfo button = Console.ReadKey(true);

				switch (button.Key) {
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
					case ConsoleKey.Q:
						Game.saveGame();
						break;
					case ConsoleKey.W:
						Game.loadGame();
						break;
				}
				Game.worm.Clear();
			}
		}

		public static void callingMove() {
			while (Game.inGame) {
				Thread.Sleep(Game.SPEED);
				Game.Clear();

				for (int i = Game.worm.points.Count - 1; i > 0; --i) {
					Game.worm.points[i].x = Game.worm.points[i - 1].x;
					Game.worm.points[i].y = Game.worm.points[i - 1].y;
				}

				Game.worm.points[0].x = (Game.worm.points[0].x + Game.worm.dx + Game.WIDTH) % Game.WIDTH;
				Game.worm.points[0].y = (Game.worm.points[0].y + Game.worm.dy + Game.HEIGTH) % Game.HEIGTH;
				Game.Draw();
				Game.CanEat();
				if (Game.worm.CollisionWithWall() || Game.worm.CollisionWithSelf()) {
					Console.Clear();
					Console.WriteLine($"Your score is {Game.totalScore}");
					Console.WriteLine($"Your score is {Game.totalScore}");
					Console.WriteLine($"Your score is {Game.totalScore}");
					for (int i = 0; i < 10; ++i) {
						Console.WriteLine("Game OVER");
					}
					Game.inGame = false;
				}
			}
		}
	}
}
