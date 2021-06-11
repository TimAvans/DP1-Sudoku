using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public interface ISudoku : IValidatable
    {
        List<Cell> Cells { get; set; }
        List<CompoundValidatable> Regions { get; set; }
        string Type();
        ISudoku Clone();

        void AcceptForRegions(IVisitor visitor);
    }
}
