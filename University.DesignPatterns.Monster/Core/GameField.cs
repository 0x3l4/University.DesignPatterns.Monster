using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Monster.Core
{
    public class GameField
    {
        public List<List<Cell>> Area;

        public int Width { get; }
        public int Height { get; }

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            Area = new List<List<Cell>>(Height);
            for (int i = 0; i < Area.Count; i++)
            {
                Area[i] = new List<Cell>(Width);
            }
        }
    }
}
