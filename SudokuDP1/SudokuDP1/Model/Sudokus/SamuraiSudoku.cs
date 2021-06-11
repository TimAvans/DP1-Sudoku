using SudokuDP1.Model.Sudokus;
using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class SamuraiSudoku : BaseSudoku
    {

        public const string TYPE = "samurai";

        public SamuraiSudoku() : base(){}

        public override string Type()
        {
            return TYPE;
        }

        public override ISudoku Clone()
        {
            return (SamuraiSudoku)MemberwiseClone();
        }
    }
}
