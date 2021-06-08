using SudokuDP1.Visitor;
using System.Collections.Generic;

namespace SudokuDP1.Model
{
    public class Column : IValidatable
    {
        public List<Cell> Cells { get; set; }

        public Column(List<Cell> cells)
        {
            this.Cells = cells;
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForColumn(this);
        }
    }
}