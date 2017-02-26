using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Food : GameObject
    {
        public Food()
        {
            this.sign = '$';
        }
        
        public bool foodInWall()
        {
            for(int i = 0; i < Game.wall.points.Count; i++)
            {
                if (points[0].Equals(Game.wall.points[i]))
                    return true;
            }
            return false;
        }
        public bool foodInWorm()
        {
            for (int i = 0; i < Game.worm.points.Count; i++)
            {
                if (points[0].Equals(Game.worm.points[i]))
                    return true;
            }
            return false;
        }

        public void newFood()
        {
            while (foodInWall() || foodInWorm())
            {
                points.Clear();
                Generate();
            }
        }
        public void Generate()
        {
            this.points.Add(new Point(new Random().Next(0, 30), new Random().Next(0, 25)));
        }
    }
}
