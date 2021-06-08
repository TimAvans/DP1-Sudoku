using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model 
{ 
    public class Region : IValidatable
    {

        public Region(List<Cell> cells)
        {
            Cells = cells;
        }

        public List<Cell> Cells { get; set; }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForRegion(this);
        }
    }
}
