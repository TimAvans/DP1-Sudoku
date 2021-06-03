using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class Cell
    {
        public int Value { get; set; }

        public string Valuestr { get { return Value.ToString(); } set { Value = int.Parse(value); } }

        public int Region { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Cell(int value, int reg, int x, int y) 
        {
            this.Value = value;
            this.Region = reg;
            this.X = x;
            this.Y = y;
        }

    }
}
