using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Visitor
{
    public interface IVisitable
    {
        void AcceptVisitor(IVisitor visitor);
    }
}
