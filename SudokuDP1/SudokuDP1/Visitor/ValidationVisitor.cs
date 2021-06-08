using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Visitor
{
    public class ValidationVisitor : IVisitor
    {
        public void DoForRegularSudoku(RegularSudoku sudoku)
        {
            Console.WriteLine("regular");
            foreach (IValidatable v in sudoku.Children)
            {
                v.AcceptVisitor(this);
            }
        }

        public void DoForJigsawSudoku(JigsawSudoku sudoku)
        {
            Console.WriteLine("jigsaw");
        }

        public void DoForSamuraiSudoku(SamuraiSudoku sudoku)
        {
            Console.WriteLine("samurai");
        }

        public void DoForRegion(Region region)
        {
            for(int i = 0; i < region.Cells.Count; i++)
            {
                for(int t = i + 1; t < region.Cells.Count; t++)
                {
                    if (region.Cells[i].Value == region.Cells[t].Value)
                    {
                        Console.WriteLine("Found a double in the region: " + region.Cells[i].Region + "; value: " + region.Cells[i].Value + "-" + region.Cells[t].Value);
                        return;
                    }
                }
            }
            Console.WriteLine("Found no doubles in a region");

        }

        public void DoForRow(Row row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                for (int t = i + 1; t < row.Cells.Count; t++)
                {
                    if (row.Cells[i].Value == row.Cells[t].Value)
                    {
                        Console.WriteLine("Found a double in the row: " + row.Cells[i].Y + "; value: " + row.Cells[i].Value + "-" + row.Cells[t].Value);
                        return;
                    }
                }
            }
            Console.WriteLine("Found no doubles in a row");
        }

        public void DoForColumn(Column column)
        {
            for (int i = 0; i < column.Cells.Count; i++)
            {
                for (int t = i + 1; t < column.Cells.Count; t++)
                {
                    if (column.Cells[i].Value == column.Cells[t].Value)
                    {
                        Console.WriteLine("Found a double in the column: " + column.Cells[i].X + "; value: " + column.Cells[i].Value + "-" + column.Cells[t].Value);
                        return;
                    }
                }
            }
            Console.WriteLine("Found no doubles in a column");
        }
    }
}
