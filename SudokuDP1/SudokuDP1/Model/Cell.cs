using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class Cell
    {
        public int value { get; set; }

        public int region { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Cell(int value) 
        {
            this.value = value;
        }

    }
}
