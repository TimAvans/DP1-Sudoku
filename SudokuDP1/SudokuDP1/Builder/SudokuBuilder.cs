using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    class SudokuBuilder : IBuilder
    {
        private Sudoku sudoku;

        public void BuildCells(List<int[]> cell_data)
        {
            List<Cell> cells = new List<Cell>();
            foreach (int[] data in cell_data)
            {
                cells.Add(new Cell(data[0], data[1], data[2], data[3]));
            }
            this.sudoku.Size = (int)Math.Sqrt(cells.Count());
            this.sudoku.Cells = cells;
        }

        public void Reset()
        {
            this.sudoku = new Sudoku();
        }

        public Sudoku GetResult()
        {
            return this.sudoku;
        }
    }
}
