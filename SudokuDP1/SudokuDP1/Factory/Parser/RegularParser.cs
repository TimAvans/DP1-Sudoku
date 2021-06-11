using SudokuDP1.Model;
using System;
using System.Collections.Generic;


namespace SudokuDP1.Factory.Parser
{
    public class RegularParser : IParser
    {
        public const string TYPE = "regular";

        public RegularParser() { }

        public IParser Clone()
        {
            return (IParser)MemberwiseClone();
        }

        public List<Dictionary<string, int>> Parse(List<string> file)
        {
            //Grid array
            // -> subrosters -> cells
            double gridWidth = Math.Sqrt(file[0].Length);
            double amt_regionrow = gridWidth / (gridWidth / Math.Floor(Math.Sqrt(gridWidth)));
            double regionrowsize = gridWidth / amt_regionrow;

            int regBegin = 0;
            int regY = 0; //Y in region
            int regX = -1; //X in region
            int currX = -1; //X in total

            int sudokuY = 0;
            int sudokuX = -1;

            int regNumber = 0;

            List<Dictionary<string, int>> cell_data = new List<Dictionary<string, int>>();

            foreach (char c in file[0])
            {
                //gridwidth behaald, regeltje omlaag
                if (currX >= gridWidth - 1) //Ga row naar beneden
                {
                    sudokuY++;
                    sudokuX = 0;
                    if (regY >= amt_regionrow-1)
                    {//regio omlaag
                        regX = 0;
                        currX = 0;
                        regY = 0;
                        regNumber++;
                        regBegin = regNumber;
                    }
                    else //regio naar links
                    {
                        regX = 0;
                        currX = 0;
                        regY++;
                        regNumber = regBegin;
                    }
                }
                else
                {
                    if (regX >= regionrowsize - 1) //regio naar rechts
                    {
                        regX = -1;
                        regNumber++;
                    }
                    regX++;
                    currX++;
                    sudokuX++;
                }

                cell_data.Add(new Dictionary<string, int>
                {
                    { "value", (int)Char.GetNumericValue(c) },
                    { "region", regNumber},
                    { "superregion", 0 },
                    { "x", sudokuX },
                    { "y", sudokuY }
                });
            }

            //foreach (Cell cell in cells)
            //{
            //    Console.WriteLine(cell.value + ": " + cell.X + " " + cell.Y + "-----" + cell.region);
            //}

            return cell_data;
        }

        public string Type()
        {
            return TYPE;
        }
    }
}
