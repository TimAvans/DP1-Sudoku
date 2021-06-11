using SudokuDP1.Model.Sudokus;
using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class RegularSudoku : BaseSudoku
    {

        public const string TYPE = "regular";

        public RegularSudoku() : base(){}

        public int Size { get { return (int)Math.Sqrt(Cells.Count()); } }

        public override string Type()
        {
            return "regular";
        }

        public override ISudoku Clone()
        {
            return (RegularSudoku)MemberwiseClone();
        }
    }
}
