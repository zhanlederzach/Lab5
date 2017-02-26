using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII {
	[Serializable]
	public class Worm : GameObject {
		public int dx;
		public int dy;

		public Worm() {
			sign = '*';
			dx = 0;
			dy = 0;
		}

		public void Generate() {
			points.Add(new Point(10, 10));
		}

		public void changeDirection(int v1, int v2) {
			dx = v1;
			dy = v2;
		}

		public bool CollisionWithWall() {
			for (int i = 0; i < Game.wall.points.Count; i++)
				if (points[0].Equals(Game.wall.points[i]))
					return true;
			return false;
		}

		public bool CollisionWithSelf() {
			for (int i = 0; i < points.Count; ++i) {
				for (int j = 0; j < points.Count; ++j) {
					if (i == j)
						continue;
					if (points[i].Equals(points[j])) return true;
				}
			}
			return false;
		}
	}
}
