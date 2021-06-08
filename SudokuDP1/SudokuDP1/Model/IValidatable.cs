using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public interface IValidatable
    {
     List<Cell> Cells { get; set; }
     void AcceptVisitor(IVisitor visitor);
    }
}
