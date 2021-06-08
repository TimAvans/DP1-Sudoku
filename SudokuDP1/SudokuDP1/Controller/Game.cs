using SudokuDP1.Builder;
using SudokuDP1.Factory.Parser;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Controller
{
    //Class to handle everything
    public class Game
    {
        private IBuilder<ISudoku> builder;
        private ConcreteParser parser;

        public ISudoku Sudoku { get; set; }

        public Game()
        {
            builder = new SudokuBuilder();
            parser = new ConcreteParser();
        }

        public void MakeSudoku(string location)
        {
            builder.BuildSudoku(parser.FileReader.GetSudokuType(location));
            builder.BuildCells(parser.Parse(location));
            builder.BuildRows();
            builder.BuildColumns();
            builder.BuildRegions();

            Sudoku = builder.GetResult();
        }
    }
}
