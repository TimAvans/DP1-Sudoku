using SudokuDP1.Builder;
using SudokuDP1.Factory;
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
        private IFactory<IBuilder<ISudoku>> factory;
        private ConcreteParser parser;

        public ISudoku Sudoku { get; set; }

        public Game()
        {
            parser = new ConcreteParser();
            factory = new BuilderFactory();
        }

        public void MakeSudoku(string location)
        {
            IBuilder<ISudoku> builder = factory.Create(parser.FileReader.GetSudokuType(location));

            builder.BuildSudoku(parser.FileReader.GetSudokuType(location));
            builder.BuildCells(parser.Parse(location));
            builder.BuildCompounds();

            Sudoku = builder.GetResult();
        }
    }
}
