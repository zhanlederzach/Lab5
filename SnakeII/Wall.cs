using System;
using System.Collections.Generic;
using System.IO;

namespace SnakeII {
	[Serializable]
	public class Wall : GameObject {
		private int level;
		public Wall() {
			sign = '#';
			level = 1;
			loadLevel(level);
		}

		public void loadLevel(int level) {
			FileStream fileStream = new FileStream($@"levels/{level}.level", FileMode.Open, FileAccess.Read);
			StreamReader streamReader = new StreamReader(fileStream);
			string[] s = streamReader.ReadToEnd().Split('\n');
			points = new List<Point>();
			for (var i = 0; i < s.Length; ++i) {
				for (var j = 0; j < s[i].Length; ++j) {
					if (s[i][j] == sign) {
						points.Add(new Point(j, i));
					}
				}
			}
			streamReader.Close();
			fileStream.Close();
		}

		public void nextLevel() {
			Clear();
			++level;
			loadLevel(level);
		}
	}
}
