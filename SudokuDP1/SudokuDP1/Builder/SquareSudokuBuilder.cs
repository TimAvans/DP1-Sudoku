using SudokuDP1.Factory;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    public class SquareSudokuBuilder : BaseSudokuBuilder
    {
        public const string TYPE = "regular";

        public SquareSudokuBuilder() : base() { }

        public override IBuilder<ISudoku> Clone()
        {
            return (SquareSudokuBuilder)MemberwiseClone();
        }

        public override string Type()
        {
            return TYPE;
        }
    }
}
