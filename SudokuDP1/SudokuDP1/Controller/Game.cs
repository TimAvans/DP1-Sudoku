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
        private IBuilder builder;
        private ConcreteParser parser;

        public Sudoku Sudoku { get; set; }

        public Game()
        {
            builder = new SudokuBuilder();
            parser = new ConcreteParser();
        }

        public void MakeSudoku(string location)
        {
            builder.Reset();
            builder.BuildCells(parser.Parse(location));

            Sudoku = builder.GetResult();
        }
    }
}
