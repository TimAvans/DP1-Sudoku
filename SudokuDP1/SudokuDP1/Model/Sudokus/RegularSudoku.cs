using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class RegularSudoku : ISudoku
    {
        public List<Cell> Cells { get; set; }

        public const string Type = "regular";
        public List<IValidatable> Children { get; set; }

        public RegularSudoku()
        {
            Children = new List<IValidatable>();
        }

        public int Size { get { return (int)Math.Sqrt(Cells.Count()); } }


        string ISudoku.Type()
        {
            return "regular";
        }

        public ISudoku Clone()
        {
            return (RegularSudoku)MemberwiseClone();
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForRegularSudoku(this);
        }
    }
}
