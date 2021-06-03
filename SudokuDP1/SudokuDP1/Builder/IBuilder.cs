using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    public interface IBuilder
    {
        void BuildCells(List<int[]> cell_data);
        Sudoku GetResult();
        void Reset();

    }
}
