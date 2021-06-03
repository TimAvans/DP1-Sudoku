using SudokuDP1.Model;
using System;
using System.Collections.Generic;


namespace SudokuDP1.Factory.Parser
{
    public class RegularParser : IParser
    {
        public const string Type = "regularparser";

        public RegularParser() { }

        public IParser Clone()
        {
            return (IParser)MemberwiseClone();
        }

        public void Parse(List<string> file)
        {
            //Grid array
            // -> subrosters -> cells
            double gridWidth = Math.Sqrt(file[0].Length);
            double amt_regionrow = gridWidth / (gridWidth / Math.Floor(Math.Sqrt(gridWidth)));
            double regionrowsize = gridWidth / amt_regionrow;

            int regY = 0; //Y in region
            int regX = -1; //X in region
            int currX = -1; //Y in total
            int currY = 0; //X in total

            int regNumber = 0;

            //Dictionary<int, Region> grid = new Dictionary<int, Region>();
            List<Cell> cells = new List<Cell>();

            foreach (var c in file[0])
            {
                Cell cell = new Cell(c);
                //gridwidth behaald, regeltje omlaag
                if (currX >= gridWidth-1) //Ga row naar beneden
                {
                    regY++;
                    regX = 0;
                    currX = 0;
                } else
                {
                    if(regX >= regionrowsize-1)
                    {
                        regX = -1;
                    }
                    regX++;
                    currX++;
                }

                cell.X = regX;
                cell.Y = regY;
                cells.Add(cell);
            }

            foreach(Cell cell in cells)
            {
                Console.WriteLine(cell.value + ": " + cell.X + " " + cell.Y);
            }
        }

        string IParser.Type()
        {
            return Type;
        }
    }
}
