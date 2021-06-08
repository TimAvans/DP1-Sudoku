using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class SamuraiSudoku : ISudoku
    {
        public List<Cell> Cells { get; set; }
        public List<IValidatable> Children { get; set; }

        public const string Type = "samurai";

        string ISudoku.Type()
        {
            return "samurai";
        }

        public ISudoku Clone()
        {
            return (SamuraiSudoku)MemberwiseClone();
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForSamuraiSudoku(this);
        }
    }
}
