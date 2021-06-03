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

        public List<int[]> Parse(List<string> file)
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

            int regNumber = 0;

            List<int[]> cell_data = new List<int[]>();

            foreach (char c in file[0])
            {
                //gridwidth behaald, regeltje omlaag
                if (currX >= gridWidth - 1) //Ga row naar beneden
                {
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
                }

                int val = (int)Char.GetNumericValue(c);
                cell_data.Add(new int[4] { (int)Char.GetNumericValue(c), regNumber, regX, regY });
            }

            //foreach (Cell cell in cells)
            //{
            //    Console.WriteLine(cell.value + ": " + cell.X + " " + cell.Y + "-----" + cell.region);
            //}

            return cell_data;
        }

        string IParser.Type()
        {
            return Type;
        }
    }
}
