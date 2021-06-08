using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Visitor
{
    public interface IVisitor
    {
        void DoForRegularSudoku(RegularSudoku sudoku);

        void DoForJigsawSudoku(JigsawSudoku sudoku);

        void DoForSamuraiSudoku(SamuraiSudoku sudoku);

        void DoForRegion(Region region);

        void DoForRow(Row row);

        void DoForColumn(Column row);
    }
}
