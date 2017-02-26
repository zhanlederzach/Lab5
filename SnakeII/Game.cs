using System;
using System.Threading;

namespace SnakeII {
	[Serializable]
	public class Game {
		public static int SPEED = 200;
		public static int HEIGTH = 35;
		public static int WIDTH = 70;
		public static int score, totalScore;

		public static Food food;
		public static Worm worm;
		public static Wall wall;

		public static bool inGame = true;

		public static void Init() {
			food = new Food();
			worm = new Worm();
			wall = new Wall();
		}

		public static void Generate() {
			food.Generate();
			worm.Generate();
		}

		public static void CanEat() {
			if (worm.points[0].Equals(food.points[0])) {
				worm.points.Add(new Point(-1, -1));
				score++;
				++totalScore;
				if (score == 4) {
					score = 0;
					wall.nextLevel();
				}
				food.points.Clear();
				food.newFood();
			}
		}

		public static void Draw() {
			food.Draw();
			wall.Draw();
			worm.Draw();
		}

		public static void saveGame() {
			wall.Save();
			worm.Save();
			food.Save();
		}

		public static void loadGame() {
			wall.Clear();
			worm.Clear();
			food.Clear();
			wall = wall.Load() as Wall;
			worm = worm.Load() as Worm;
			food = food.Load() as Food;
			Console.Clear();
			wall.Draw();
			worm.Draw();
			food.Draw();
		}

		public static void Clear() {
			worm.Clear();
			food.Clear();
			wall.Clear();
		}
	}
}