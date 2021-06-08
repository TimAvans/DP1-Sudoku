using SudokuDP1.Visitor;
using System.Collections.Generic;

namespace SudokuDP1.Model
{
    public class Row : IValidatable
    {
        public List<Cell> Cells { get; set; }
        public Row(List<Cell> cells)
        {
            Cells = cells;
        }
        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForRow(this);
        }
    }
}