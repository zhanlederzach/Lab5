using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Wall:GameObject
    {
        public Wall()
        {
            this.sign = '#';
        }
        public void Generate()
        {
            this.points.Add(new Point(new Random().Next(0, 40), new Random().Next(0, 30)));
        }
    }
}
