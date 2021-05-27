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
            double regionsize = Math.Sqrt(file[0].Length);
            double nrows = regionsize / (regionsize / Math.Floor(Math.Sqrt(regionsize)));
            double regionrowsize = regionsize / nrows;

            int regY = 0;
            int regX = 0;
            int currX = 0;
            int currY = 0;

            Dictionary<int, Region> grid = new Dictionary<int, Region>();

            foreach (var c in file[0])
            {
                if (currX > regionrowsize)
                {
                    if (currX > regionsize)
                    {
                        if (currY < nrows)
                        {
                            currY++;
                            currX++;
                        }
                        else
                        {
                            currY = 0;
                            regY++;
                        }
                        currX = 0;
                    }
                    else
                    {
                        regX++;
                    }
                }
                currX++;
            }
        }

        string IParser.Type()
        {
            return Type;
        }
    }
}
