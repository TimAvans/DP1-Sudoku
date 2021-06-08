using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class JigsawSudoku : ISudoku
    {
        public const string Type = "jigsaw";
        public List<Cell> Cells { get; set; }

        //Children = Rows, Regions, Columns
        public List<IValidatable> Children { get; set; }

        string ISudoku.Type()
        {
            return "jigsaw";
        }

        public ISudoku Clone()
        {
            return (JigsawSudoku)MemberwiseClone();
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.DoForJigsawSudoku(this);
        }
    }
}
