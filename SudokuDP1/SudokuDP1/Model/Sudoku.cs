using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class Sudoku
    {
        public List<Cell> Cells { get; set; }
        public int Size { get; set; }

        public Sudoku()
        {
            Size = 0;
        }



    }
}
